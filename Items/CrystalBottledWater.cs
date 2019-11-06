using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class CrystalBottleWater : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Water Bottle");
			Tooltip.SetDefault("The water glows a strange hue");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 30;
			item.value = 2500;
			item.rare = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Items.CrystalBottle>());
			recipe.AddTile(TileType<Tiles.Fountain>());
			recipe.SetResult(ItemType<Items.CrystalBottleWater>());
			recipe.AddRecipe();
		}
	}
}