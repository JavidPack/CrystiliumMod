using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Placeable
{
	public class PolishedCrystal : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Polished Crystal Block";
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("PolishedCrystal");
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CrystalBlock", 2);
			recipe.AddTile(16);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}