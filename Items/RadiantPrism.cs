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
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 3000;
			item.rare = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Placeable.RadiantOre>(), 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}