using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class CrystalGrenade : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal Grenade");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Grenade);
			Item.damage = 35;
			Item.useTime = 60;
			Item.value = 1000;
			Item.useAnimation = 60;
			Item.rare = 3;
			Item.shoot = ModContent.ProjectileType<Projectiles.CrystalGrenadeProj>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(5);
			recipe.AddIngredient(ItemID.Grenade, 5);
			recipe.AddIngredient(ModContent.ItemType<ShinyGemstone>());
			recipe.Register();
		}
	}
}