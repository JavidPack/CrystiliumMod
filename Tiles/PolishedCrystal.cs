using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Tiles
{
	public class PolishedCrystal : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			dustType = mod.DustType("Sparkle");
			drop = mod.ItemType<Items.Placeable.PolishedCrystal>();
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
		public override bool KillSound(int i, int j)
		{
			Main.PlaySound(2, i * 16, j * 16, 27);
			return false;
		}
	}
}