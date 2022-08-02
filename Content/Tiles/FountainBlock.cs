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
			this.MinPick = 999;
			Main.tileLighted[Type] = false;
			SetModTree(new CrystalTree())/* tModPorter Note: Removed. Assign GrowsOnTileId to this tile type in ModTree.SetStaticDefaults instead */;
			DustType = ModContent.DustType<Dusts.Sparkle>();
			HitSound = 27;
			soundStyle/* tModPorter Note: Removed. Integrate into HitSound */ = 2;
			ItemDrop = ModContent.ItemType<Items.Placeable.CrystalBlock>();
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

		public override int SaplingGrowthType(ref int style)/* tModPorter Note: Removed. Use ModTree.SaplingGrowthType */
		{
			style = 0;
			return ModContent.TileType<CrystalSapling>();
		}

		public override bool KillSound(int i, int j)
		{
			SoundEngine.PlaySound(SoundID.Item27, new Vector2(i * 16, j * 16));
			return false;
		}
	}
}