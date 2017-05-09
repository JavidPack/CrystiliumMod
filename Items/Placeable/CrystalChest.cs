using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Placeable
{
	public class CrystalChest : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystal Chest";
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 500;
			item.createTile = mod.TileType<Tiles.CrystalChest>();
		}
	}
}