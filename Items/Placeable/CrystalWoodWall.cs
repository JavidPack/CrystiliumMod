using Terraria.ModLoader;

namespace CrystiliumMod.Items.Placeable
{
	public class CrystalWoodWall : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystal Wood Wall";
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			AddTooltip("This is a crystal wood wall.");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = 1;
			item.consumable = true;
			item.createWall = mod.WallType("CrystalWoodWall");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CrystalWood");
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}