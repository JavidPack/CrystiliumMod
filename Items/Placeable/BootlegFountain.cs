using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Placeable
{
	public class BootlegFountain : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bootleg Crystal Fountain");
			Tooltip.SetDefault("'Looks the same, but is illegal in 48 states'");
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
			Item.createTile = TileType<Tiles.BootlegFountain>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<ShinyGemstone>(), 15);
			recipe.AddIngredient(ItemType<RadiantPrism>(), 10);
			recipe.Register();
		}
	}
}