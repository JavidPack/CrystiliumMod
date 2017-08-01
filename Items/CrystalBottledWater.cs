using Terraria.ModLoader;

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
			recipe.AddIngredient(mod.ItemType<Items.CrystalBottle>());
			recipe.AddTile(mod.TileType<Tiles.Fountain>());
			recipe.SetResult(mod.ItemType<Items.CrystalBottleWater>());
			recipe.AddRecipe();
		}
	}
}