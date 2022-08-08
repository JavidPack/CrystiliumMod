using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles.Minions
{
	public class SpiritBow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Bow");
			Main.projFrames[Projectile.type] = 9;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.width = 48;
			Projectile.height = 58;
			Projectile.timeLeft = 600;
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.minion = true;
			Projectile.sentry = true;
			Projectile.timeLeft = Projectile.SentryLifeTime;
		}

		public override bool PreDraw(ref Color lightColor)
		{
			//custom drawing, used to make bow not upside down when facing left
			//also draws the animation PROPERLY, because vanilla is too dumb to do it right
			if (Projectile.rotation > Math.PI / 2 && Projectile.rotation < Math.PI * 3 / 2)
			{
				Main.spriteBatch.Draw(ModContent.Request<Texture2D>(Texture).Value, Projectile.Center - Main.screenPosition, new Rectangle(0, (Projectile.height + 1) * Projectile.frame, Projectile.width, Projectile.height), lightColor, Projectile.rotation, new Vector2(Projectile.width / 2, Projectile.height / 2), Projectile.scale, SpriteEffects.FlipVertically, 0f);
			}
			else
			{
				Main.spriteBatch.Draw(ModContent.Request<Texture2D>(Texture).Value, Projectile.Center - Main.screenPosition, new Rectangle(0, (Projectile.height + 1) * Projectile.frame, Projectile.width, Projectile.height), lightColor, Projectile.rotation, new Vector2(Projectile.width / 2, Projectile.height / 2), Projectile.scale, SpriteEffects.None, 0f);
			}
			return false;
		}

		NPC target;
		//How the projectile works
		//AI ARRAY INFO: 0 - NUFFIN  |  1 - TARGET
		public override void AI()
		{
			//CONFIG INFO
			int range = 50;	//How many tiles away the projectile targets NPCs
			float rotSpeed = (float)(Math.PI / 10); //speed of rotation (in radians per frame)
			int animSpeed = 2;  //how many game frames per frame :P note: firing anims are twice as fast currently
			int targetingMax = 20; //how many frames allowed to target nearest instead of shooting
			float shootVelocity = 16f; //magnitude of the shoot vector (speed of arrows shot)

			Player player = Main.player[Projectile.owner];
			player.UpdateMaxTurrets();

			if (ClosestNPC(ref target, range*16, Projectile.Center, false, player.MinionAttackTargetNPC))
			{
				Vector2 dirToTarget = Projectile.DirectionTo(target.Center);
				float rotToTarget = dirToTarget.ToRotation();
				Projectile.rotation = SlowRotation(Projectile.rotation, rotToTarget, rotSpeed);
			}

			//ANIMATION HANDLING
			//loading arrow
			if ((Projectile.frame >= 0 && Projectile.frame < 5))
			{
				Projectile.frameCounter++;
				if (Projectile.frameCounter % animSpeed == 0)
				{
					Projectile.frame++;
				}
				if (Projectile.frame == 5) Projectile.frameCounter = 0;
			}
			//waiting for fire
			else if (Projectile.frame == 5)
			{
				//do nuffin... until target in range
				if (target != null && target.active && Projectile.Distance(target.Center) / 16 < range)
				{
					Projectile.frameCounter++;
					//proceed if rotated in the right direction
					if (Projectile.rotation == Projectile.DirectionTo(target.position).ToRotation() && Projectile.frameCounter % 4 > 0)
					{
						Projectile.frame++;
						Projectile.frameCounter = 0;
					}
					//proceed if still haven't locked on (targets change too quickly, etc)
					else if (Projectile.frameCounter >= targetingMax)
					{
						Projectile.frame++;
						Projectile.frameCounter = 0;
					}
				}
				else Projectile.frameCounter = 0;
			}
			//firing
			else if (Projectile.frame == 6)
			{
				Projectile.frameCounter++;
				//fire!!
				if (Projectile.frameCounter % animSpeed == 0)
				{
					//spawn the arrow centered on the bow (this code aligns the centers :3)
					Vector2 vel = new Vector2(shootVelocity, 0f).RotatedBy(Projectile.rotation);
					int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<SpiritArrow>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
					Projectile newProj = Main.projectile[proj];
					newProj.position += Projectile.Center - newProj.Center;

					SoundEngine.PlaySound(SoundID.Item5, Projectile.Center);  //make bow shooty sound

					Projectile.frame++;
				}
			}
			//finish firing anim, revert back to 0
			else if (Projectile.frame > 6)
			{
				Projectile.frameCounter++;
				if (Projectile.frameCounter % animSpeed == 0)
				{
					Projectile.frame++;
				}
				if (Projectile.frame == 9)
				{
					Projectile.frame = 0;
					Projectile.frameCounter = 0;
				}
			}
			if (Projectile.timeLeft == Projectile.SentryLifeTime)
			{
				for (int i = 0; i < 15; i++)
				{
					Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.Sparkle>(), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item27, Projectile.Center);
			for (int i = 0; i < 15; i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.Sparkle>(), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
			}
		}

		//I ported these two methods straight from Qwerty's Bosses and Items
		static float SlowRotation(float currentRotation, float targetAngle, float speed)
		{
			int f = 1; //this is used to switch rotation direction
			float actDirection = new Vector2((float)Math.Cos(currentRotation), (float)Math.Sin(currentRotation)).ToRotation();
			targetAngle = new Vector2((float)Math.Cos(targetAngle), (float)Math.Sin(targetAngle)).ToRotation();

			//this makes f 1 or -1 to rotate the shorter distance
			if (Math.Abs(actDirection - targetAngle) > Math.PI)
			{
				f = -1;
			}
			else
			{
				f = 1;
			}

			if (actDirection <= targetAngle + speed * 2 && actDirection >= targetAngle - speed * 2)
			{
				actDirection = targetAngle;
			}
			else if (actDirection <= targetAngle)
			{
				actDirection += (speed) * f;
			}
			else if (actDirection >= targetAngle)
			{
				actDirection -= (speed) * f;
			}
			actDirection = new Vector2((float)Math.Cos(actDirection), (float)Math.Sin(actDirection)).ToRotation();

			return actDirection;
		}
		static bool ClosestNPC(ref NPC target, float maxDistance, Vector2 position, bool ignoreTiles = false, int overrideTarget = -1)
		{
			bool foundTarget = false;
			if (overrideTarget != -1)
			{
				if ((Main.npc[overrideTarget].Center - position).Length() < maxDistance)
				{
					target = Main.npc[overrideTarget];
					return true;
				}

			}
			for (int k = 0; k < Main.npc.Length; k++)
			{
				NPC possibleTarget = Main.npc[k];
				float distance = (possibleTarget.Center - position).Length();
				if (distance < maxDistance && possibleTarget.active && possibleTarget.chaseable && !possibleTarget.dontTakeDamage && !possibleTarget.friendly && possibleTarget.lifeMax > 5 && !possibleTarget.immortal && (Collision.CanHit(position, 0, 0, possibleTarget.Center, 0, 0) || ignoreTiles))
				{
					target = Main.npc[k];
					foundTarget = true;


					maxDistance = (target.Center - position).Length();
				}

			}
			return foundTarget;
		}
	}
}