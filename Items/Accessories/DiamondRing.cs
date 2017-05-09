using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace CrystiliumMod.Items.Accessories
{
	public class DiamondRing : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			base.SetDefaults(item);
			if (item.type == ItemID.DiamondRing)
			{
				item.toolTip = "5% increased critical strike chance";
				item.value = Item.sellPrice(0, 0, 85, 0); //item is now worth less because craftable
				item.vanity = false; //allows use of modifiers
				item.rare = 1;
			}
		}

		public override void UpdateAccessory(Item item, Player player, bool hideVisual)
		{
			base.UpdateAccessory(item, player, hideVisual);
			if (item.type == ItemID.DiamondRing)
			{
				player.magicCrit += 5;
				player.meleeCrit += 5;
				player.thrownCrit += 5;
				player.rangedCrit += 5;
			}
		}
	}
}