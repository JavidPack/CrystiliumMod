using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace CrystiliumMod.Items
{
    public class DustbreakPotion : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Dustbreak Potion";
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30;
            item.consumable = true;
            item.width = 12;
            item.height = 30;
            item.toolTip = "Increases critical strike damage";
            item.value = 3000;
            item.rare = 0;
            item.buffType = mod.BuffType("Dustbreak");
            item.buffTime = 10000;
            return;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CrystalBottleWater", 1);
            recipe.AddIngredient(null, "RadiantPrism", 1);
            recipe.AddIngredient(ItemID.GoldOre, 1);
            recipe.AddIngredient(ItemID.Amber, 1);
			recipe.AddIngredient(ItemID.Blinkroot, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}