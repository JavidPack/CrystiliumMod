using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CrystiliumMod.Tiles
{
    public class Crystal : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            //TileObjectData.addTile(Type);
            Main.tileCut[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = false;
            dustType = mod.DustType("Sparkle");
            drop = mod.ItemType("GlowingCrystal");
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
        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return mod.TileType("CrystalSapling");
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.0f;
            g = 0.0f;
            b = 2.5f;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Main.PlaySound(2, i * 16, j * 16, 27);
        }

    }
}