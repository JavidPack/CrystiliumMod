using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class CrystalBottleWater : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystal Water Bottle";
			item.width = 20;
			item.height = 20;
			item.maxStack = 30;
			AddTooltip("The water glows a strange hue");
			item.value = 2500;
			item.rare = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Items.CrystalBottle>());
			recipe.AddTile(mod.TileType<Tiles.Fountain>());
			recipe.SetResult(mod.ItemType<Items.CrystalBottleWater>()); // todo, what's up with the duplicate in the Mod class?
			recipe.AddRecipe();
		}
	}
}