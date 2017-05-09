using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Tiles
{
	public class CrystalWood : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			SetModTree(new CrystalTree());
			dustType = mod.DustType("Sparkle");
			soundType = 27;
			soundStyle = 2;
			drop = mod.ItemType<Items.Placeable.CrystalWood>();
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
	}
}