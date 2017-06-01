using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Placeable
{
	public class CrystalWoodChair : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystal Wood Chair";
			item.width = 12;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType<Tiles.CrystalWoodChair>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenChair);
			recipe.AddIngredient(mod.ItemType<CrystalWood>(), 10);
			recipe.AddTile(mod.TileType<Tiles.CrystalWoodWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}