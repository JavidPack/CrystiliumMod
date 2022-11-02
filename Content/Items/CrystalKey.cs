using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items
{
	public class CrystalKey : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal Key");
			// Tooltip.SetDefault("Unlocks the secrets of the shining caves");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 100000;
			Item.rare = 3;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ShinyGemstone>(), 5);
			recipe.AddIngredient(ItemID.GoldenKey);
			recipe.Register();
		}
	}
}