using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.NPCs
{
	public class Prismancer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prismancer");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.width = 40;
			NPC.height = 54;
			NPC.damage = 62;
			NPC.defense = 22;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.lifeMax = 234;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 300f;
			NPC.knockBackResist = 0.5f;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode) //restrict spawning to Hardmode
				return Main.tile[(int)(spawnInfo.SpawnTileX), (int)(spawnInfo.SpawnTileY)].TileType == ModContent.TileType<Tiles.CrystalBlock>() ? 13f : 0f;
			return 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				//spawn shard gores (6 of them, 3 of each)
				for (int i = 0; i < 3; i++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.Sparkle>(), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
				}
			}
		}

		public override void OnKill()
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Items.EnchantedGeode>());
			}
		}

		public override void AI()
		{
			if (NPC.localAI[0] == 0f)
			{
				NPC.localAI[0] = NPC.Center.Y;
			}
			if (NPC.Center.Y >= NPC.localAI[0])
			{
				NPC.localAI[1] = -1f;
			}
			if (NPC.Center.Y <= NPC.localAI[0] - 40f)
			{
				NPC.localAI[1] = 1f;
			}
			NPC.velocity.Y = MathHelper.Clamp(NPC.velocity.Y + 0.05f * NPC.localAI[1], -2f, 2f);

			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(NPC.position + NPC.velocity, NPC.width - (Main.rand.Next(NPC.width)), 1, Mod.Find<ModDust>("CrystalDust").Type, (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
			}
			NPC.TargetClosest();
			float Xdis = Main.player[NPC.target].Center.X - NPC.Center.X;  // change myplayer to nearest player in full version
			float Ydis = Main.player[NPC.target].Center.Y - NPC.Center.Y; // change myplayer to nearest player in full version
			float Angle = (float)Math.Atan(Xdis / Ydis);
			float TrajectoryX = (float)(Math.Sin(Angle));
			float TrajectoryY = (float)(Math.Cos(Angle));
			if (Main.rand.Next(450) == 0)
			{
				if (Main.player[NPC.target].Center.Y <= NPC.Center.Y)
				{
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, 0 - (TrajectoryX * 7), 0 - (TrajectoryY * 7), ModContent.ProjectileType<Projectiles.CrystalKing.CultistFire>(), 40, 0f, NPC.target);
				}
				else if (Main.player[NPC.target].Center.Y > NPC.Center.Y)
				{
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, (TrajectoryX * 7), TrajectoryY * 7, ModContent.ProjectileType<Projectiles.CrystalKing.CultistFire>(), 40, 0f, NPC.target);
				}
			}

			NPC.ai[0]++;
			if (NPC.ai[0] % 8 == 0)
			{
				NPC.frame.Y = (int)(NPC.height * NPC.frameCounter);
				NPC.frameCounter = (NPC.frameCounter + 1) % 3;
			}
			Vector3 RGB = new(2.0f, 0.75f, 1.5f);
			NPC.TargetClosest();
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
			Lighting.AddLight(NPC.position, RGB.X, RGB.Y, RGB.Z);
			if (Main.rand.Next(575) == 0)
			{
				for (int i = 0; i < 20; i++)
				{
					Dust.NewDust(NPC.position, NPC.width - (Main.rand.Next(NPC.width)), NPC.height - (Main.rand.Next(NPC.height)), Mod.Find<ModDust>("CrystalDust").Type, (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
				do
				{  //Keep teleporting if too close to player
					NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
					NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
				} while (NPC.Distance(Main.player[NPC.target].position) < 40);
			}
		}
	}
}