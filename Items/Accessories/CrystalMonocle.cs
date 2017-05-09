using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace CrystiliumMod.Items.Accessories
{
	public class CrystalMonocle : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystal Monocle";
			item.width = 40;
			item.height = 40;
			item.toolTip = "+10% Magic and ranged damage and Crit chance";
			item.toolTip2 = "+10% Magic and ranged critical strike chance";
			item.toolTip2 = "'Colorful distortion'";
			item.value = 30000;
			item.rare = 3;
			item.defense = 3;
			item.accessory = true;
		}
	
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicCrit += 10;
			player.rangedCrit += 10;
			player.magicDamage *= 1.10f;
			player.rangedDamage *= 1.10f;
		}
	}
}