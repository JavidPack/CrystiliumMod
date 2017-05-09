using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class RadiantPrism : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Radiant Prism";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("It's vibrating intensely");
			item.value = 3000;
			item.rare = 3;
		}

		public override DrawAnimation GetAnimation()
		{
			return new DrawAnimationVertical(4, 4);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RadiantOre", 3);
			recipe.AddTile(17);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}

		/*	public override void AddRecipes()
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.DirtBlock);
				recipe.SetResult(this, 999);
				recipe.AddRecipe();
				recipe = new ModRecipe(mod);
				recipe.AddCraftGroup(null, "ExampleItem");
				recipe.SetResult(this, 999);
				recipe.AddRecipe();
			} */
	}
}