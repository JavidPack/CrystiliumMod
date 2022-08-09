using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Tiles
{
	public class RadiantOre : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			this.MinPick = 65;
            Main.tileLighted[Type] = false;
			HitSound = SoundID.Item27;
			DustType = ModContent.DustType<Dusts.Sparkle>();
			ItemDrop = ModContent.ItemType<Items.Placeable.RadiantOre>();
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
	}
}