using System;
using CrystiliumMod.Content.Projectiles.CrystalKing;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.NPCs.Bosses
{
	public class CrystalCultist : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Cultist");
			Main.npcFrameCount[NPC.type] = 7;
		}

		public override void SetDefaults()
		{
			NPC.damage = 25;
			NPC.noTileCollide = true;
			NPC.defense = 30;
			NPC.boss = false;
			NPC.height = 54;
			NPC.width = 35;
			NPC.lifeMax = 1200;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.noGravity = true;
			NPC.value = 60f;
			NPC.knockBackResist = 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			//Putting gores in HitEffect prevents gores when scripting NPC death (setting life to 0)
			if (NPC.life <= 0)
			{
				//spawn initial set
				for (int i = 1; i <= 3; i++)
				{
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/Crystal_Cultist_Gore_" + i).Type);
				}
				//spawn the remaining arm
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/Crystal_Cultist_Gore_1").Type);
			}
		}

		public override void AI()
		{
			//Leave when there are no CKs
			bool CKActive = false;
			foreach (NPC npc in Main.npc)
			{
				if (npc.active && npc.type == ModContent.NPCType<CrystalKing>())
				{
					CKActive = true;
					break;
				}
			}
			if (!CKActive)
			{
				NPC.active = false;
			}

			NPC.ai[0]++;
			if (NPC.ai[0] % 8 == 0)
			{
				NPC.frame.Y = (int)(NPC.height * NPC.frameCounter);
				NPC.frameCounter = (NPC.frameCounter + 1) % 5;
			}

			NPC.TargetClosest();
			float Xdis = Main.player[NPC.target].Center.X - NPC.Center.X;  // change myplayer to nearest player in full version
			float Ydis = Main.player[NPC.target].Center.Y - NPC.Center.Y; // change myplayer to nearest player in full version
			float Angle = (float)Math.Atan(Xdis / Ydis);
			float TrajectoryX = (float)(Math.Sin(Angle));
			float TrajectoryY = (float)(Math.Cos(Angle));
			if (Main.rand.Next(250) == 0)
			{
				if (Main.player[NPC.target].Center.Y <= NPC.Center.Y)
				{
					Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 0 - (TrajectoryX * 7), 0 - (TrajectoryY * 7), ModContent.ProjectileType<Slasher>(), 40, 0f, NPC.target);
				}
				else if (Main.player[NPC.target].Center.Y > NPC.Center.Y)
				{
					Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, (TrajectoryX * 7), TrajectoryY * 7, ModContent.ProjectileType<Slasher>(), 40, 0f, NPC.target);
				}
			}
			Vector3 RGB = new(2.0f, 0.75f, 1.5f);
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
			if (Main.rand.Next(160) == 5)
			{
				do
				{  //Keep teleporting if too close to player
					NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
					NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
				} while (NPC.Distance(Main.player[NPC.target].position) < 40);
			}
		}
	}
}