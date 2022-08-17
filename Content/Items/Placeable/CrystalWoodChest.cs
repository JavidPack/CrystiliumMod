using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Placeable
{
	public class CrystalWoodChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal Wood Chest");
			// Tooltip.SetDefault("A chest");
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
			Item.createTile = ModContent.TileType<Tiles.CrystalWoodChest>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CrystalWood>(), 10);
			recipe.AddTile(ModContent.TileType<Tiles.CrystalWoodWorkbench>());
			recipe.Register();
		}
	}
}