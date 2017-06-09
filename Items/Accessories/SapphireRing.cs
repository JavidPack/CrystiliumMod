using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Accessories
{
	public class SapphireRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sapphire Ring");
			Tooltip.SetDefault("5% increased melee speed");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = Item.sellPrice(0, 0, 70, 0);
			item.rare = 1;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeSpeed += .05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TungstenBar, 4);
			recipe.AddIngredient(ItemID.Sapphire, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBar, 4);
			recipe.AddIngredient(ItemID.Sapphire, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}