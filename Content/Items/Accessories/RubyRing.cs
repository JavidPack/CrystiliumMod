using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Accessories
{
	public class RubyRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ruby Ring");
			// Tooltip.SetDefault("Your melee weapon flickers with heat");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.value = Item.sellPrice(0, 0, 85, 0);
			Item.rare = 1;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			// 20% chance of having Magma Stone effect each frame, equivalent of 20% chance of fire each strike
			if (Main.rand.Next(5) == 0)
				player.magmaStone = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 4);
			recipe.AddIngredient(ItemID.Ruby, 3);
			recipe.Register();
		}
	}
}