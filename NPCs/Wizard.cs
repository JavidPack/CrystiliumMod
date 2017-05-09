using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.NPCs
{
	public class Wizard : GlobalNPC
	{
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Wizard)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.CrystalBottle>());
				nextSlot++;
			}
		}
	}
}
