using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace CrystiliumMod.Content.Tiles
{
	public class CrystalTree : ModTree
	{
		public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
		{
			UseSpecialGroups = true,
			SpecialGroupMinimalHueValue = 11f / 72f,
			SpecialGroupMaximumHueValue = 0.25f,
			SpecialGroupMinimumSaturationValue = 0.88f,
			SpecialGroupMaximumSaturationValue = 1f
		};

		public override void SetStaticDefaults() => GrowsOnTileId = new int[] { ModContent.TileType<CrystalBlock>() };
		public override int CreateDust() => 22;
		public override int TreeLeaf() => GoreID.TreeLeaf_Normal;
		public override int DropWood() => ModContent.ItemType<Items.Placeable.CrystalWood>();
		public override Asset<Texture2D> GetTexture() => ModContent.Request<Texture2D>("CrystiliumMod/Tiles/CrystalTree");
		public override Asset<Texture2D> GetTopTextures() => ModContent.Request<Texture2D>("CrystiliumMod/Tiles/CrystalTree_Tops");
		public override Asset<Texture2D> GetBranchTextures() => ModContent.Request<Texture2D>("CrystiliumMod/Tiles/CrystalTree_Branches");

		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return ModContent.TileType<CrystalSapling>();
		}

		public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
		{
			topTextureFrameWidth = 142;
			topTextureFrameHeight = 114;
			xoffset = 62;
			floorY = 2;
		}
	}
}