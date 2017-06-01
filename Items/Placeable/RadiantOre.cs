using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Placeable
{
	public class RadiantOre : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Radiant Ore";
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			AddTooltip("It's convulsing with mana");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType<Tiles.RadiantOre>();
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
		}
	}
}