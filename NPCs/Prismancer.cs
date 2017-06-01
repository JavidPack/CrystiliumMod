using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.NPCs
{
	public class Prismancer : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Prismancer";
			npc.displayName = "Prismancer";
			npc.width = 40;
			npc.height = 54;
			npc.damage = 62;
			npc.defense = 22;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.lifeMax = 234;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 300f;
			npc.knockBackResist = 0.5f;
			Main.npcFrameCount[npc.type] = 3;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode) //restrict spawning to Hardmode
				return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == mod.TileType<Tiles.CrystalBlock>() ? 13f : 0f;
			return 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				//spawn shard gores (6 of them, 3 of each)
				for (int i = 0; i < 3; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<Dusts.Sparkle>(), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
				}
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Items.EnchantedGeode>());
			}
		}

		public override void AI()
		{
			if (npc.localAI[0] == 0f)
			{
				npc.localAI[0] = npc.Center.Y;
			}
			if (npc.Center.Y >= npc.localAI[0])
			{
				npc.localAI[1] = -1f;
			}
			if (npc.Center.Y <= npc.localAI[0] - 40f)
			{
				npc.localAI[1] = 1f;
			}
			npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y + 0.05f * npc.localAI[1], -2f, 2f);

			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(npc.position + npc.velocity, npc.width - (Main.rand.Next(npc.width)), 1, mod.DustType("CrystalDust"), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
			}
			npc.TargetClosest();
			float Xdis = Main.player[npc.target].Center.X - npc.Center.X;  // change myplayer to nearest player in full version
			float Ydis = Main.player[npc.target].Center.Y - npc.Center.Y; // change myplayer to nearest player in full version
			float Angle = (float)Math.Atan(Xdis / Ydis);
			float TrajectoryX = (float)(Math.Sin(Angle));
			float TrajectoryY = (float)(Math.Cos(Angle));
			if (Main.rand.Next(450) == 0)
			{
				if (Main.player[npc.target].Center.Y <= npc.Center.Y)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0 - (TrajectoryX * 7), 0 - (TrajectoryY * 7), mod.ProjectileType<Projectiles.CrystalKing.CultistFire>(), 40, 0f, npc.target);
				}
				else if (Main.player[npc.target].Center.Y > npc.Center.Y)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (TrajectoryX * 7), TrajectoryY * 7, mod.ProjectileType<Projectiles.CrystalKing.CultistFire>(), 40, 0f, npc.target);
				}
			}

			npc.ai[0]++;
			if (npc.ai[0] % 8 == 0)
			{
				npc.frame.Y = (int)(npc.height * npc.frameCounter);
				npc.frameCounter = (npc.frameCounter + 1) % 3;
			}
			Vector3 RGB = new Vector3(2.0f, 0.75f, 1.5f);
			npc.TargetClosest();
			float multiplier = 1;
			float max = 2.25f;
			float min = 1.0f;
			RGB *= multiplier;
			if (RGB.X > max)
			{
				multiplier = 0.5f;
			}
			if (RGB.X < min)
			{
				multiplier = 1.5f;
			}
			Lighting.AddLight(npc.position, RGB.X, RGB.Y, RGB.Z);
			if (Main.rand.Next(575) == 0)
			{
				for (int i = 0; i < 20; i++)
				{
					Dust.NewDust(npc.position, npc.width - (Main.rand.Next(npc.width)), npc.height - (Main.rand.Next(npc.height)), mod.DustType("CrystalDust"), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
				do
				{  //Keep teleporting if too close to player
					npc.position.X = (Main.player[npc.target].position.X - 500) + Main.rand.Next(1000);
					npc.position.Y = (Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000);
				} while (npc.Distance(Main.player[npc.target].position) < 40);
			}
		}
	}
}