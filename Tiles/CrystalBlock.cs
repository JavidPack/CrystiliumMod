using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Tiles
{
	public class CrystalBlock : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			SetModTree(new CrystalTree());
			dustType = DustType<Dusts.Sparkle>();
			soundType = 27;
			soundStyle = 2;
			drop = ItemType<Items.Placeable.CrystalBlock>();
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
			if (Framing.GetTileSafely(i, j - 1).type == 0 && Framing.GetTileSafely(i, j - 2).type == 0)
			{
				if (Main.rand.Next(2) == 0)
				{
					if (Main.rand.Next(5) == 0)
					{
						WorldGen.PlaceObject(i - 1, j - 1, TileType<Crystal>());
						NetMessage.SendObjectPlacment(-1, i - 1, j - 1, TileType<Crystal>(), 0, 0, -1, -1);
					}
					else
					{
						WorldGen.PlaceObject(i, j - 1, TileType<CrystalSapling>());
						NetMessage.SendObjectPlacment(-1, i, j - 1, TileType<CrystalSapling>(), 0, 0, -1, -1);
					}
				}
			}
		}

		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return TileType<CrystalSapling>();
		}

		public override bool KillSound(int i, int j)
		{
			Main.PlaySound(2, i * 16, j * 16, 27);
			return false;
		}
	}
}