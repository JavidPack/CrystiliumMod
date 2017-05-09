using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Placeable
{
	public class CrystalWood : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystal Wood";
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType<Tiles.CrystalWood>();
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
		}
	}
}