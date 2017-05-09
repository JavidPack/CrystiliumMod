using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Tiles
{
	public class FountainBlock : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			this.minPick = 999;
			Main.tileLighted[Type] = false;
			SetModTree(new CrystalTree());
			dustType = mod.DustType("Sparkle");
			soundType = 27;
			soundStyle = 2;
			drop = mod.ItemType<Items.Placeable.CrystalBlock>();
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
					WorldGen.PlaceObject(i, j - 1, mod.TileType<Crystal>());
				}
				if (Main.rand.Next(2) == 0)
				{
					WorldGen.PlaceObject(i, j - 1, mod.TileType<CrystalSapling>());
				}
			}
			if (Main.rand.Next(10) == 0)
			{
				WorldGen.PlaceObject(i, j - 1, mod.TileType<CrystalSapling>());
			}
		}

		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return mod.TileType<CrystalSapling>();
		}

		public override bool KillSound(int i, int j)
		{
			Main.PlaySound(2, i * 16, j * 16, 27);
			return false;
		}
	}
}