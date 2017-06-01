using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.NPCs
{
	public class CrystalElemental : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Crystal Elemental";
			npc.displayName = "Crystal Elemental";
			npc.width = 30;
			npc.height = 50;
			npc.damage = 21;
			npc.defense = 9;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.lifeMax = 90;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 300f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 22;
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Wraith];
			aiType = NPCID.Wraith;
			animationType = NPCID.Wraith;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == mod.TileType<Tiles.CrystalBlock>() ? 4f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				//spawn shard gores (6 of them, 3 of each)
				for (int i = 0; i < 3; i++)
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Element_Gore_1"));
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Element_Gore_2"));
				}
				//spawn core gore
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Element_Gore_3"));
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Items.ShinyGemstone>());
			}
		}

		public override void AI()
		{
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
			if (Main.rand.Next(500) == 5)
			{
				for (int i = 0; i < 20; i++)
				{
					Dust.NewDust(npc.position, npc.width - (Main.rand.Next(npc.width)), npc.height - (Main.rand.Next(npc.height)), mod.DustType<Dusts.CrystalDust>(), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
				do
				{  //Keep teleporting if too close to player
					npc.position.X = (Main.player[npc.target].position.X - 500) + Main.rand.Next(1000);
					npc.position.Y = (Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000);
				} while (npc.Distance(Main.player[npc.target].position) < 40);
				for (int i = 0; i < 20; i++)
				{
					Dust.NewDust(npc.position, npc.width - (Main.rand.Next(npc.width)), npc.height - (Main.rand.Next(npc.height)), mod.DustType<Dusts.CrystalDust>(), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
			}
		}
	}
}