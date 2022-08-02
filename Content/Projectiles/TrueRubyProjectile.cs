using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class TrueRubyProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Ruby Gem");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.width = 14;
			Projectile.height = 26;
			Projectile.timeLeft = 240; //Projectile lasts 4 seconds
		}

		//Projectile AI adapted from friendly Lost Soul AI (AKA Spectre Staff projectiles)
		//Note ADAPTED. Code was essentially unreadable and impractical originally.
		public override void AI()
		{
			if (++Projectile.frameCounter % 3 == 0)
			{
				if (++Projectile.frame > 3) Projectile.frame = 0;
			}

			Vector2 targetPos = Projectile.Center;
			float targetDist = 250f;
			bool targetAcquired = false;

			//loop through first 200 NPCs in Main.npc
			//this loop finds the closest valid target NPC within the range of targetDist pixels
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(Projectile) && Collision.CanHit(Projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
				{
					float dist = Projectile.Distance(Main.npc[i].Center);
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
				Vector2 homingVect = targetPos - Projectile.Center;
				float dist = Projectile.Distance(targetPos);
				dist = homingSpeedFactor / dist;
				homingVect *= dist;

				Projectile.velocity = (Projectile.velocity * 20 + homingVect) / 21f;
			}

			//Spawn the dust
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, Mod.Find<ModDust>("TrueRubyDust").Type, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + (float)(Math.PI / 2);
		}
	}
}