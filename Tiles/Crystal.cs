using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace CrystiliumMod.Tiles
{
	public class Crystal : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			//TileObjectData.addTile(Type);
			Main.tileCut[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			DustType = DustType<Dusts.Sparkle>();
			ItemDrop = ItemType<Items.Placeable.GlowingCrystal>();
			AddMapEntry(new Color(200, 200, 200));

			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16
			};

			TileObjectData.addTile(Type);
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override int SaplingGrowthType(ref int style)/* tModPorter Note: Removed. Use ModTree.SaplingGrowthType */
		{
			style = 0;
			return TileType<CrystalSapling>();
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.0f;
			g = 0.0f;
			b = 2.5f;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			SoundEngine.PlaySound(SoundID.Item27, new Vector2(i * 16, j * 16));
		}
	}
}