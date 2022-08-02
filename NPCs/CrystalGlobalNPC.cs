using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.NPCs
{
	public class CrystalGlobalNPC : GlobalNPC
	{
		/*	public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
			{
				if (player.GetModPlayer<CrystalPlayer>().ZoneCrystal)
				{
					spawnRate = (int)(spawnRate * 0.65f);
					maxSpawns = (int)(maxSpawns * 1.45f);
				}
			}*/

		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.GetModPlayer<CrystalPlayer>().ZoneCrystal)
			{
				pool.Clear(); //remove ALL spawns here
				pool.Add(NPCType<CrystalElemental>(), 4f); // a modded enemy
				pool.Add(NPCType<CrystalArcher>(), 10f); // a modded enemy
				pool.Add(NPCType<CrystalSlime>(), 10f); // a modded enemy
				pool.Add(NPCType<CrystalZombie>(), 8f); // a modded enemy

				if (Main.hardMode)
				{
					pool.Add(NPCType<CrystalMimic>(), 0.1f); // another modded enemy
					pool.Add(NPCType<GeodeMonster>(), 13f); // another modded enemy
					pool.Add(NPCType<Prismancer>(), 13f); // another modded enemy
				}
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			Player player = Main.LocalPlayer;
			if (type == NPCID.Cyborg)
			{
				if (player.HasItem(ItemType<Items.Weapons.Shatterocket>()))
				{
					shop.item[nextSlot].SetDefaults(ItemType<Items.RPC>());
					nextSlot++;
				}
			}
		}
	}
}