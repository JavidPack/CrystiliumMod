using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Tiles
{
	public class RadiantOre : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			this.minPick = 65;
			Main.tileLighted[Type] = false;
			dustType = DustType<Dusts.Sparkle>();
			drop = ItemType<Items.Placeable.RadiantOre>();
			AddMapEntry(new Color(255, 93, 245));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 1.50f;
			g = 0.75f;
			b = 1.25f;
		}

		public override bool KillSound(int i, int j)
		{
			Main.PlaySound(2, i * 16, j * 16, 27);
			return false;
		}
	}
}