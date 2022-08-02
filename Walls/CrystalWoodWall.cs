using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Walls
{
	public class CrystalWoodWall : ModWall
	{
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = true;
			DustType = DustType<Dusts.Sparkle>();
			AddMapEntry(new Color(150, 150, 150));
		}
	}
}
