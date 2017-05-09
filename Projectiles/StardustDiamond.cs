using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class StardustDiamond : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "StardustDiamond";
			projectile.width = 48;
			projectile.height = 58;
			projectile.timeLeft = 1500;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.minion = true;
			projectile.light = 0.75f;
			projectile.minionSlots = 0;
			Main.projFrames[projectile.type] = 8;
		}

		//How the projectile works
		//AI ARRAY INFO: 0 - NUFFIN  |  1 - TARGET
		public override void AI()
		{
			if (projectile.timeLeft == 1500 || projectile.timeLeft == 1)
			{
				for (int I = 0; I < 15; I++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("StardustDust"), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
				}
			}
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 8;
			}
			//CONFIG INFO
			int range = 50;   //How many tiles away the projectile targets NPCs
							  //int targetingMax = 20; //how many frames allowed to target nearest instead of shooting
							  //float shootVelocity = 16f; //magnitude of the shoot vector (speed of arrows shot)

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
			NPC target = (Main.npc[(int)projectile.ai[1]] ?? new NPC());
			//fire!!
			if (Main.rand.Next(25) == 6 && target.active && projectile.Distance(target.Center) / 16 < range)
			{
				//spawn the arrow centered on the bow (this code aligns the centers :3)
				Vector2 vel = projectile.DirectionTo(target.Center);
				int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X * 10, vel.Y * 10, mod.ProjectileType<StardustCrystal>(), projectile.damage, projectile.knockBack, projectile.owner);
				Projectile newProj = Main.projectile[proj];
				newProj.position += projectile.Center - newProj.Center;

				Main.PlaySound(2, projectile.Center, 5);  //make bow shooty sound
			}
		}

		public override void Kill(int timeLeft)
		{
			if (timeLeft <= 1)
			{
				Main.PlaySound(2, projectile.Center, 27);
			}
		}
	}
}