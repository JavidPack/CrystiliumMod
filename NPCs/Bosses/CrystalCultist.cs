using Terraria;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using CrystiliumMod.Projectiles.CrystalKing;

namespace CrystiliumMod.NPCs.Bosses
{
	public class CrystalCultist : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Crystal Cultist";
			npc.displayName = "Crystal Cultist";
			npc.damage = 25;
			npc.noTileCollide = true;
			npc.defense = 30;
			npc.boss = false;
			npc.height = 54;
			npc.width = 35;
			npc.lifeMax = 1200;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.noGravity = true;
			npc.value = 60f;
			npc.knockBackResist = 0f;
			Main.npcFrameCount[npc.type] = 7;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			//Putting gores in HitEffect prevents gores when scripting NPC death (setting life to 0)
			if (npc.life <= 0)
			{
				//spawn initial set
				for (int i = 1; i <= 3; i++)
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Cultist_Gore_" + i));
				}
				//spawn the remaining arm
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Cultist_Gore_1"));
			}
		}

		public override void AI()
		{
			//Leave when there are no CKs
			bool CKActive = false;
			foreach (NPC npc in Main.npc)
			{
				if (npc.active && npc.type == mod.NPCType<CrystalKing>())
				{
					CKActive = true;
					break;
				}
			}
			if (!CKActive)
			{
				npc.active = false;
			}

			npc.ai[0]++;
			if (npc.ai[0] % 8 == 0)
			{
				npc.frame.Y = (int)(npc.height * npc.frameCounter);
				npc.frameCounter = (npc.frameCounter + 1) % 5;
			}

			npc.TargetClosest();
			float Xdis = Main.player[npc.target].Center.X - npc.Center.X;  // change myplayer to nearest player in full version
			float Ydis = Main.player[npc.target].Center.Y - npc.Center.Y; // change myplayer to nearest player in full version
			float Angle = (float)Math.Atan(Xdis / Ydis);
			float TrajectoryX = (float)(Math.Sin(Angle));
			float TrajectoryY = (float)(Math.Cos(Angle));
			if (Main.rand.Next(250) == 5)
			{
				if (Main.player[npc.target].Center.Y <= npc.Center.Y)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0 - (TrajectoryX * 7), 0 - (TrajectoryY * 7), mod.ProjectileType<Slasher>(), 40, 0f, npc.target);
				}
				else if (Main.player[npc.target].Center.Y > npc.Center.Y)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (TrajectoryX * 7), TrajectoryY * 7, mod.ProjectileType<Slasher>(), 40, 0f, npc.target);
				}
			}
			Vector3 RGB = new Vector3(2.0f, 0.75f, 1.5f);
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
			if (Main.rand.Next(160) == 5)
			{
				do
				{  //Keep teleporting if too close to player
					npc.position.X = (Main.player[npc.target].position.X - 500) + Main.rand.Next(1000);
					npc.position.Y = (Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000);
				} while (npc.Distance(Main.player[npc.target].position) < 40);
			}
		}
	}
}
