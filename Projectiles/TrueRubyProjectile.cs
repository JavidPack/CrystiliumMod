using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.IO;

namespace CrystiliumMod.Projectiles
{
	public class TrueRubyProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "True Ruby Gem";
			projectile.friendly = true;
			projectile.magic = true;
			projectile.width = 14;
			projectile.height = 26;
			Main.projFrames[projectile.type] = 4;
			projectile.timeLeft = 240; //Projectile lasts 4 seconds
		}

		//Projectile AI adapted from friendly Lost Soul AI (AKA Spectre Staff projectiles)
		//Note ADAPTED. Code was essentially unreadable and impractical originally.
		public override void AI()
		{
			if (++projectile.frameCounter % 3 == 0)
			{
				if (++projectile.frame > 3) projectile.frame = 0;
			}

			Vector2 targetPos = projectile.Center;
			float targetDist = 250f;
			bool targetAcquired = false;

			//loop through first 200 NPCs in Main.npc
			//this loop finds the closest valid target NPC within the range of targetDist pixels
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(projectile) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
				{
					float dist = projectile.Distance(Main.npc[i].Center);
					if (dist < targetDist)
					{
						targetDist = dist;
						targetPos = Main.npc[i].Center;
						targetAcquired = true;
					}
				}
			}

			//change trajectory to home in on target
			if (targetAcquired)
			{
				float homingSpeedFactor = 6f;
				Vector2 homingVect = targetPos - projectile.Center;
				float dist = projectile.Distance(targetPos);
				dist = homingSpeedFactor / dist;
				homingVect *= dist;

				projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
			}

			//Spawn the dust
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("TrueRubyDust"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
			projectile.rotation = projectile.velocity.ToRotation() + (float)(Math.PI / 2);
		}
	}
}