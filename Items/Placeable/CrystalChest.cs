using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Placeable
{
	public class CrystalChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Chest");
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 22;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 500;
			Item.createTile = TileType<Tiles.CrystalChest>();
		}
	}
}