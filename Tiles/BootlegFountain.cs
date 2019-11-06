using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace CrystiliumMod.Tiles
{
	public class BootlegFountain : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			this.minPick = 15;
			TileObjectData.newTile.Height = 6;
			TileObjectData.newTile.Width = 6;
			TileObjectData.newTile.Origin = new Point16(0, 0); // Todo: make less annoying.
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.addTile(Type);
			animationFrameHeight = 108;
			AddMapEntry(new Color(200, 200, 200));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		//		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		//		{
		//			r = 3.45f;
		//			 g = 0.75f;
		//			b = 4.5f;
		//		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Main.PlaySound(2, i * 16, j * 16, 27);
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frame = Main.tileFrame[TileType<Fountain>()];
		}
	}
}