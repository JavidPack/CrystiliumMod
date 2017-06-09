using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class CrystalKey : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Key");
			Tooltip.SetDefault("Unlocks the secrets of the shining caves");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100000;
			item.rare = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<ShinyGemstone>(), 5);
			recipe.AddIngredient(ItemID.GoldenKey);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}