using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Walls
{
	public class CrystalWoodWall : ModWall
	{
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = true;
			DustType = ModContent.DustType<Dusts.Sparkle>();
			AddMapEntry(new Color(150, 150, 150));
		}
	}
}
