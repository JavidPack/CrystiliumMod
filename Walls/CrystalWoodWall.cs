using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Walls
{
	public class CrystalWoodWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			dustType = mod.DustType<Dusts.Sparkle>();
			AddMapEntry(new Color(150, 150, 150));
		}
	}
}
