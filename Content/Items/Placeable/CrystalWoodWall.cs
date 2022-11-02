using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Placeable
{
	public class CrystalWoodWall : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal Wood Wall");
			// Tooltip.SetDefault("This is a crystal wood wall.");
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 7;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createWall = ModContent.WallType<Walls.CrystalWoodWall>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(4);
			recipe.AddIngredient(ModContent.ItemType<CrystalWood>());
			recipe.Register();
		}
	}
}