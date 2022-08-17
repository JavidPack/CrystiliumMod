using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Accessories
{
	public class TopazRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Topaz Ring");
			// Tooltip.SetDefault("5% increased movement speed");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.value = Item.sellPrice(0, 0, 30, 0);
			Item.rare = 1;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += .05f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TinBar, 4);
			recipe.AddIngredient(ItemID.Topaz, 3);
			recipe.Register();
		}
	}
}