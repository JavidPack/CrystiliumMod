using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items
{
	public class CrystalBottleWater : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal Water Bottle");
			// Tooltip.SetDefault("The water glows a strange hue");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 30;
			Item.value = 2500;
			Item.rare = 3;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Items.CrystalBottleWater>());
			recipe.AddIngredient(ModContent.ItemType<Items.CrystalBottle>());
			recipe.AddTile(ModContent.TileType<Tiles.Fountain>());
			recipe.Register();
		}
	}
}