using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Placeable
{
	public class RadiantOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiant Ore");
			Tooltip.SetDefault("It's convulsing with mana");
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.RadiantOre>();
		}
	}
}