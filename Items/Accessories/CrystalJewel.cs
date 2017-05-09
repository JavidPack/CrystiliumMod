using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace CrystiliumMod.Items.Accessories
{
	public class CrystalJewel : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystal Jewel";
			item.width = 40;
			item.height = 40;
			item.toolTip = "Creates dangerous shards when hit";
			item.expert = true;
			item.value = 100000;
			item.rare = 3;
			item.defense = 3;
			item.accessory = true;
		}
	
		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<CrystalPlayer>(mod).CrystalAcc = true;
		}
	}
}