using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Tiles
{
	public class FountainBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			DustType = ModContent.DustType<Dusts.Sparkle>();
			HitSound = SoundID.Shatter;
			ItemDrop = ModContent.ItemType<Items.Placeable.CrystalBlock>();
			MinPick = 999;
			AddMapEntry(new Color(19, 163, 189));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.00f;
			g = 0.75f;
			b = 1.75f;
		}

		public override void RandomUpdate(int i, int j)
		{
			if (Main.tile[i, j - 1] == null || Main.tile[i, j - 2] == null || Main.tile[i + 1, j] == null || Main.tile[i + 1, j - 2] == null || Main.tile[i + 2, j - 1] == null || Main.tile[i + 2, j - 2] == null)
			{
				if (Main.rand.Next(10) == 0)
				{
					WorldGen.PlaceObject(i, j - 1, ModContent.TileType<Crystal>());
				}
				if (Main.rand.Next(2) == 0)
				{
					WorldGen.PlaceObject(i, j - 1, ModContent.TileType<CrystalSapling>());
				}
			}
			if (Main.rand.Next(10) == 0)
			{
				WorldGen.PlaceObject(i, j - 1, ModContent.TileType<CrystalSapling>());
			}
		}
	}
}