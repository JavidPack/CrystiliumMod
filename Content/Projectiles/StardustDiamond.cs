using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class StardustDiamond : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("StardustDiamond");
			Main.projFrames[Projectile.type] = 8;
		}

		public override void SetDefaults()
		{
			Projectile.width = 48;
			Projectile.height = 58;
			Projectile.timeLeft = 1500;
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.minion = true;
			Projectile.light = 0.75f;
			Projectile.minionSlots = 0;
		}

		//How the projectile works
		//AI ARRAY INFO: 0 - NUFFIN  |  1 - TARGET
		public override void AI()
		{
			if (Projectile.timeLeft == 1500 || Projectile.timeLeft == 1)
			{
				for (int i = 0; i < 15; i++)
				{
					Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("StardustDust").Type, (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
				}
			}
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 8)
			{
				Projectile.frameCounter = 0;
				Projectile.frame = (Projectile.frame + 1) % 8;
			}
			//CONFIG INFO
			int range = 50;	//How many tiles away the projectile targets NPCs
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
					float dist = Projectile.Distance(npc.Center);
					if (dist / 16 < range)
					{
						//if npc is closer than closest found npc
						if (dist < lowestDist)
						{
							lowestDist = dist;

							//target this npc
							Projectile.ai[1] = npc.whoAmI;
						}
					}
				}
			}
			NPC target = (Main.npc[(int)Projectile.ai[1]] ?? new NPC());
			//fire!!
			if (Main.rand.Next(25) == 0 && target.active && Projectile.Distance(target.Center) / 16 < range)
			{
				//spawn the arrow centered on the bow (this code aligns the centers :3)
				Vector2 vel = Projectile.DirectionTo(target.Center);
				int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X * 10, vel.Y * 10, ModContent.ProjectileType<StardustCrystal>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
				Projectile newProj = Main.projectile[proj];
				newProj.position += Projectile.Center - newProj.Center;

				SoundEngine.PlaySound(SoundID.Item5, Projectile.Center);  //make bow shooty sound
			}
		}

		public override void Kill(int timeLeft)
		{
			if (timeLeft <= 1)
			{
				SoundEngine.PlaySound(SoundID.Item27, Projectile.Center);
			}
		}
	}
}