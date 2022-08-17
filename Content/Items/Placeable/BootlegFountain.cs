using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Placeable
{
	public class BootlegFountain : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bootleg Crystal Fountain");
			// Tooltip.SetDefault("'Looks the same, but is illegal in 48 states'");
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 22;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 500;
			Item.createTile = ModContent.TileType<Tiles.BootlegFountain>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ShinyGemstone>(), 15);
			recipe.AddIngredient(ModContent.ItemType<RadiantPrism>(), 10);
			recipe.Register();
		}
	}
}