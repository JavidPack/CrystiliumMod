using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class ShinyGemstone : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Shining Gemstone";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("Infused with mana");
			item.value = 2500;
            item.rare = 3;
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