using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace CrystiliumMod.Items.Accessories
{
	public class SapphireRing : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Sapphire Ring";
			item.width = 40;
			item.height = 40;
			item.toolTip = "5% increased melee speed";
			item.value = Item.sellPrice(0, 0, 70, 0);
			item.rare = 1;
			item.accessory = true;
		}
	
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeSpeed += .05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TungstenBar, 4);
			recipe.AddIngredient(ItemID.Sapphire, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBar, 4);
			recipe.AddIngredient(ItemID.Sapphire, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}