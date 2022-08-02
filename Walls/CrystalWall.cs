using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Walls
{
	public class CrystalWall : ModWall
	{
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = true;
			DustType = DustType<Dusts.Sparkle>();
			AddMapEntry(new Color(150, 150, 150));
		}

		/*	public override void NumDust(int i, int j, bool fail, ref int num)
			{
				num = fail ? 1 : 3;
			}

			public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
			{
				r = 0f;
				g = 0f;
				b = 2.5f;
			} */
	}
}