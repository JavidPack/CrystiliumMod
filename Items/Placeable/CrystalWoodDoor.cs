using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Placeable
{
	public class CrystalWoodDoor : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crysta lWood Door";
			item.width = 14;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("CrystalWoodDoorClosed");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenDoor);
			recipe.AddIngredient(null, "CrystalWood", 10);
			recipe.AddTile(null, "CrystalWoodWorkbench");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}