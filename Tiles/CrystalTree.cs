using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Tiles
{
	public class CrystalTree : ModTree
	{
		private Mod mod
		{
			get
			{
				return CrystiliumMod.instance;
			}
		}

		public override bool CanDropAcorn()
		{
			return false;
		}

		public override int CreateDust()
		{
			return DustType<Dusts.CrystalDust>();
		}

		public override int TreeLeaf()
		{
			return mod.GetGoreSlot("Gores/CrystalTreeFX");
		}

		public override int DropWood()
		{
			return ItemType<Items.Placeable.CrystalWood>();
		}

		public override Texture2D GetTexture()
		{
			return mod.GetTexture("Tiles/CrystalTree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
			return mod.GetTexture("Tiles/CrystalTree_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return mod.GetTexture("Tiles/CrystalTree_Branches");
		}
	}
}