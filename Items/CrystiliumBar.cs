using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class CrystiliumBar : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystilium Bar";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("`Enchanted with the magic of an entire world`");
			item.value = 10000;
			item.rare = 7;
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