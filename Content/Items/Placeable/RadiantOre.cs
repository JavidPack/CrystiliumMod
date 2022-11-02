using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Placeable
{
	public class RadiantOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Radiant Ore");
			// Tooltip.SetDefault("It's convulsing with mana");
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
			Item.createTile = ModContent.TileType<Tiles.RadiantOre>();
		}
	}
}