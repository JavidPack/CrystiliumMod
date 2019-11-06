using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class CrystalGrenade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Grenade");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Grenade);
			item.damage = 35;
			item.useTime = 60;
			item.value = 1000;
			item.useAnimation = 60;
			item.rare = 3;
			item.shoot = ProjectileType<Projectiles.CrystalGrenadeProj>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Grenade, 5);
			recipe.AddIngredient(ItemType<ShinyGemstone>());
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}