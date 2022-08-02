using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Accessories
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
			Item.width = 40;
			Item.height = 40;
			Item.value = Item.sellPrice(0, 0, 70, 0);
			Item.rare = 1;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetAttackSpeed(DamageClass.Melee) += .05f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TungstenBar, 4);
			recipe.AddIngredient(ItemID.Sapphire, 3);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SilverBar, 4);
			recipe.AddIngredient(ItemID.Sapphire, 3);
			recipe.Register();
		}
	}
}