using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Accessories
{
	public class AmethystRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amethyst Ring");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.value = Item.sellPrice(0, 0, 15, 0);
			Item.rare = 1;
			Item.accessory = true;
			Item.defense = 3;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CopperBar, 4);
			recipe.AddIngredient(ItemID.Amethyst, 3);
			recipe.Register();
		}
	}
}