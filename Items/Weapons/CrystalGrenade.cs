using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class CrystalGrenade : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Grenade);
			item.name = "Crystal Grenade";
			item.damage = 35;
			item.toolTip = "";
			item.useTime = 60;
			item.value = 1000;
			item.useAnimation = 60;
			item.rare = 3;
			item.shoot = mod.ProjectileType<Projectiles.CrystalGrenadeProj>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Grenade, 5);
			recipe.AddIngredient(null, "ShinyGemstone", 1);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}