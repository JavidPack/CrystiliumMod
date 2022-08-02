using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class CrystalBottleWater : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Water Bottle");
			Tooltip.SetDefault("The water glows a strange hue");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 30;
			Item.value = 2500;
			Item.rare = 3;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ItemType<Items.CrystalBottleWater>());
			recipe.AddIngredient(ItemType<Items.CrystalBottle>());
			recipe.AddTile(TileType<Tiles.Fountain>());
			recipe.Register();
		}
	}
}