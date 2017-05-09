using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Placeable
{
	public class CrystalWoodChest : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystal Wood Chest";
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			AddTooltip("A chest");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 500;
			item.createTile = mod.TileType("CrystalWoodChest");
		}
		  public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CrystalWood", 10);
            recipe.AddTile(null, "CrystalWoodWorkbench");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}