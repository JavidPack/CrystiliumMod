using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class RadiantPrism : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Radiant Prism";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("It's vibrating intensely");
			item.value = 3000;
			item.rare = 3;
		}

		public override DrawAnimation GetAnimation()
		{
			return new DrawAnimationVertical(4, 4);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Placeable.RadiantOre>(), 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}