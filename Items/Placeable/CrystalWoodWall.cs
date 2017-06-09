using Terraria.ModLoader;

namespace CrystiliumMod.Items.Placeable
{
	public class CrystalWoodWall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Wood Wall");
			Tooltip.SetDefault("This is a crystal wood wall.");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = 1;
			item.consumable = true;
			item.createWall = mod.WallType<Walls.CrystalWoodWall>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<CrystalWood>());
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}