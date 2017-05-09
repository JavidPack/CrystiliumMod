using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Placeable
{
	public class BootlegFountain : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Bootleg Crystal Fountain";
			item.width = 26;
			AddTooltip("'Looks the same, but is illegal in 48 states'");
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 500;
			item.createTile = mod.TileType<Tiles.BootlegFountain>();
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShinyGemstone", 15);
			recipe.AddIngredient(null, "RadiantPrism", 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}