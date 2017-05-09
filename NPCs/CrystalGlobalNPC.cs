using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.NPCs
{
	public class CrystalGlobalNPC : GlobalNPC
	{
		/*	public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
			{
				if (player.GetModPlayer<CrystalPlayer>(mod).ZoneCrystal)
				{
					spawnRate = (int)(spawnRate * 0.65f);
					maxSpawns = (int)(maxSpawns * 1.45f);
				}
			}*/

		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.GetModPlayer<CrystalPlayer>(mod).ZoneCrystal)
				{
					pool.Clear(); //remove ALL spawns here
					pool.Add(mod.NPCType<CrystalElemental>(), 4f); // a modded enemy
					pool.Add(mod.NPCType<CrystalArcher>(), 10f); // a modded enemy
					pool.Add(mod.NPCType<CrystalSlime>(), 10f); // a modded enemy
					pool.Add(mod.NPCType<CrystalZombie>(), 8f); // a modded enemy

					if (Main.hardMode)
					{
						pool.Add(mod.NPCType<CrystalMimic>(), 0.1f); // another modded enemy
						pool.Add(mod.NPCType<GeodeMonster>(), 13f); // another modded enemy
						pool.Add(mod.NPCType<Prismancer>(), 13f); // another modded enemy
					}
				}
				return;
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			Player player = Main.LocalPlayer;
			if (type == NPCID.Cyborg)
			{
				for (int i = 0; i <= 50; i++)
				{
					if (player.inventory[i].type == mod.ItemType<Items.Weapons.Shatterocket>())
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType<Items.RPC>());
						nextSlot++;
						break;
					}
				}
			}
		}
	}
}