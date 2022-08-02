using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class RadiantPrism : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiant Prism");
			Tooltip.SetDefault("It's vibrating intensely");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 4));
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 3000;
			Item.rare = 3;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Placeable.RadiantOre>(), 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}