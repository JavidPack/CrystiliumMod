using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles.Minions
{
	public class SpiritBow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Bow");
			Main.projFrames[projectile.type] = 9;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 58;
			projectile.timeLeft = 600;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.minion = true;
			projectile.sentry = true;
			projectile.timeLeft = Projectile.SentryLifeTime;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			//custom drawing, used to make bow not upside down when facing left
			//also draws the animation PROPERLY, because vanilla is too dumb to do it right
			if (projectile.rotation > Math.PI / 2 && projectile.rotation < Math.PI * 3 / 2)
			{
				spriteBatch.Draw(mod.GetTexture("Projectiles/Minions/SpiritBow"), projectile.Center - Main.screenPosition, new Rectangle(0, (projectile.height + 1) * projectile.frame, projectile.width, projectile.height), lightColor, projectile.rotation, new Vector2(projectile.width / 2, projectile.height / 2), projectile.scale, SpriteEffects.FlipVertically, 0f);
			}
			else
			{
				spriteBatch.Draw(mod.GetTexture("Projectiles/Minions/SpiritBow"), projectile.Center - Main.screenPosition, new Rectangle(0, (projectile.height + 1) * projectile.frame, projectile.width, projectile.height), lightColor, projectile.rotation, new Vector2(projectile.width / 2, projectile.height / 2), projectile.scale, SpriteEffects.None, 0f);
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

			Player player = Main.player[projectile.owner];
			player.UpdateMaxTurrets();

			if (ClosestNPC(ref target, range*16, projectile.Center, false, player.MinionAttackTargetNPC))
			{
				Vector2 dirToTarget = projectile.DirectionTo(target.Center);
				float rotToTarget = dirToTarget.ToRotation();
				projectile.rotation = SlowRotation(projectile.rotation, rotToTarget, rotSpeed);
			}

			//ANIMATION HANDLING
			//loading arrow
			if ((projectile.frame >= 0 && projectile.frame < 5))
			{
				projectile.frameCounter++;
				if (projectile.frameCounter % animSpeed == 0)
				{
					projectile.frame++;
				}
				if (projectile.frame == 5) projectile.frameCounter = 0;
			}
			//waiting for fire
			else if (projectile.frame == 5)
			{
				//do nuffin... until target in range
				if (target != null && target.active && projectile.Distance(target.Center) / 16 < range)
				{
					projectile.frameCounter++;
					//proceed if rotated in the right direction
					if (projectile.rotation == projectile.DirectionTo(target.position).ToRotation() && projectile.frameCounter % 4 > 0)
					{
						projectile.frame++;
						projectile.frameCounter = 0;
					}
					//proceed if still haven't locked on (targets change too quickly, etc)
					else if (projectile.frameCounter >= targetingMax)
					{
						projectile.frame++;
						projectile.frameCounter = 0;
					}
				}
				else projectile.frameCounter = 0;
			}
			//firing
			else if (projectile.frame == 6)
			{
				projectile.frameCounter++;
				//fire!!
				if (projectile.frameCounter % animSpeed == 0)
				{
					//spawn the arrow centered on the bow (this code aligns the centers :3)
					Vector2 vel = new Vector2(shootVelocity, 0f).RotatedBy(projectile.rotation);
					int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, ProjectileType<SpiritArrow>(), projectile.damage, projectile.knockBack, projectile.owner);
					Projectile newProj = Main.projectile[proj];
					newProj.position += projectile.Center - newProj.Center;

					Main.PlaySound(2, projectile.Center, 5);  //make bow shooty sound

					projectile.frame++;
				}
			}
			//finish firing anim, revert back to 0
			else if (projectile.frame > 6)
			{
				projectile.frameCounter++;
				if (projectile.frameCounter % animSpeed == 0)
				{
					projectile.frame++;
				}
				if (projectile.frame == 9)
				{
					projectile.frame = 0;
					projectile.frameCounter = 0;
				}
			}
			if (projectile.timeLeft == Projectile.SentryLifeTime)
			{
				for (int i = 0; i < 15; i++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, DustType<Dusts.Sparkle>(), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, projectile.Center, 27);
			for (int i = 0; i < 15; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustType<Dusts.Sparkle>(), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
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