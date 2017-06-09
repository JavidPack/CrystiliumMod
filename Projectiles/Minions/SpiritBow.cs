using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles.Minions
{
	public class SpiritBow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Bow");
			Main.projFrames[projectile.type] = 9;
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
			projectile.minionSlots = 0;
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

			//TARGET NEAREST NPC WITHIN RANGE
			float lowestDist = float.MaxValue;
			foreach (NPC npc in Main.npc)
			{
				//if npc is a valid target (active, not friendly, and not a critter)
				if (npc.active && !npc.friendly && npc.catchItem == 0)
				{
					//if npc is within 50 blocks
					float dist = projectile.Distance(npc.Center);
					if (dist / 16 < range)
					{
						//if npc is closer than closest found npc
						if (dist < lowestDist)
						{
							lowestDist = dist;

							//target this npc
							projectile.ai[1] = npc.whoAmI;
						}
					}
				}
			}

			//ROTATE BOW TOWARDS TARGET
			NPC target = (Main.npc[(int)projectile.ai[1]] ?? new NPC()); //our target
			if (target.active && projectile.Distance(target.Center) / 16 < range)
			{
				Vector2 dirToTarget = projectile.DirectionTo(target.Center);
				float rotToTarget = dirToTarget.ToRotation();

				//handle clockwise rotation
				if (projectile.rotation > rotToTarget)
				{
					//don't jitter
					if (projectile.rotation - rotToTarget < rotSpeed) projectile.rotation = rotToTarget;
					//rotate normally
					else projectile.rotation -= rotSpeed;
				}

				//handling counter-clockwise rotation
				else
				{
					//don't jitter
					if (rotToTarget - projectile.rotation < rotSpeed) projectile.rotation = rotToTarget;
					//rotate normally
					else projectile.rotation += rotSpeed;
				}
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
				if (target.active && projectile.Distance(target.Center) / 16 < range)
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
					int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType<SpiritArrow>(), projectile.damage, projectile.knockBack, projectile.owner);
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
			if (projectile.timeLeft == 600)
			{
				for (int i = 0; i < 15; i++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType<Dusts.Sparkle>(), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, projectile.Center, 27);
			for (int i = 0; i < 15; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType<Dusts.Sparkle>(), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
			}
		}
	}
}