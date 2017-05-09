using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace CrystiliumMod.Items.Accessories
{
	public class EmeraldRing : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Emerald Ring";
			item.width = 40;
			item.height = 40;
			item.toolTip = "5% increased damage";
			item.value = Item.sellPrice(0, 0, 70, 0);
			item.rare = 1;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += .05f;
			player.meleeDamage += .05f;
			player.rangedDamage += .05f;
			player.minionDamage += .05f;
			player.thrownDamage += .05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBar, 4);
			recipe.AddIngredient(ItemID.Emerald, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}