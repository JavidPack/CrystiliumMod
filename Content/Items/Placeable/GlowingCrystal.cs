using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Placeable
{
	public class GlowingCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Glowing Crystal");
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
			Item.createTile = ModContent.TileType<Tiles.GlowingCrystal>();
		}
	}
}