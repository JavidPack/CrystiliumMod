using Terraria.ModLoader;

namespace CrystiliumMod.Items.Placeable
{
	public class KingTrophy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal King Trophy");
			Tooltip.SetDefault("A chest");
		}

		public override void SetDefaults()
		{
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
			item.createTile = mod.TileType<Tiles.KingTrophy>();
		}
	}
}