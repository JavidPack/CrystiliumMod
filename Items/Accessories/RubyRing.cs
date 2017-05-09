using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace CrystiliumMod.Items.Accessories
{
	public class RubyRing : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ruby Ring";
			item.width = 40;
			item.height = 40;
			item.toolTip = "Your melee weapon flickers with heat";
			item.value = Item.sellPrice(0, 0, 85, 0);
			item.rare = 1;
			item.accessory = true;
		}
	
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			// 20% chance of having Magma Stone effect each frame, equivalent of 20% chance of fire each strike
			if(Main.rand.Next(5) == 0)
				player.magmaStone = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 4);
			recipe.AddIngredient(ItemID.Ruby, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}