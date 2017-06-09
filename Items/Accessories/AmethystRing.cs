using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
			item.width = 40;
			item.height = 40;
			item.value = Item.sellPrice(0, 0, 15, 0);
			item.rare = 1;
			item.accessory = true;
			item.defense = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperBar, 4);
			recipe.AddIngredient(ItemID.Amethyst, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}