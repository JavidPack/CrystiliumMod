using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace CrystiliumMod.Items
{
	public class CrypticCrystal : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cryptic Crystal";
			item.toolTip = "Use at the heart of the Crystal";
            item.toolTip2 = "'Boast of thy Treasures, and Dragons will come...'"; //placeholder cool tip
			item.consumable = true;
            item.rare = 7;
		}

		public override bool CanUseItem(Player player)
		{
			return false;
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient(ItemID.CrystalShard, 10);
			recipe.AddIngredient("EnchantedGeode", 5);
			recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}