using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace CrystiliumMod.Items.Accessories
{
	public class TopazRing : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Topaz Ring";
			item.width = 40;
			item.height = 40;
			item.toolTip = "5% increased movement speed";
			item.value = Item.sellPrice(0, 0, 30, 0);
			item.rare = 1;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += .05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinBar, 4);
			recipe.AddIngredient(ItemID.Topaz, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}