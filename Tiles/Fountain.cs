using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace CrystiliumMod.Tiles
{
	public class Fountain : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			minPick = 999;
			TileObjectData.newTile.Height = 6;
			TileObjectData.newTile.Width = 6;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.addTile(Type);
			animationFrameHeight = 108;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Crystal Fountain");
			AddMapEntry(new Color(200, 200, 200), name);
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		//		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		//		{
		//			r = 3.45f;
		//			 g = 0.75f;
		//			b = 4.5f;
		//		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Main.PlaySound(2, i * 16, j * 16, 27);
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			if (++frameCounter >= 5) {
				frameCounter = 0;
				frame = ++frame % 6;
			}
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (Vector2.Distance(Main.LocalPlayer.Center, new Vector2(i * 16, j * 16)) < 16 * 5)
			{
				CrystalPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CrystalPlayer>();
				modPlayer.crystalFountain = true;
			}
		}

		public override void MouseOver(int i, int j)
		{
			//shows the Cryptic Crystal icon while mousing over this tile
			Main.LocalPlayer.showItemIcon = true;
			Main.LocalPlayer.showItemIcon2 = ItemType<Items.CrypticCrystal>();
		}

		public override bool NewRightClick(int i, int j)
		{
			//don't bother if there's already a Crystal King in the world
			if(NPC.AnyNPCs(NPCType<NPCs.Bosses.CrystalKing>()))
				return true;

			//check if player has a Cryptic Crystal
			if (Main.LocalPlayer.ConsumeItem(ItemType<Items.CrypticCrystal>())) {
				if (Main.netMode == NetmodeID.MultiplayerClient) {
					ModPacket packet = mod.GetPacket();
					packet.Write((byte)CrystiliumModMessageType.SpawnBossSpecial);
					packet.Send();
				}
				else {
					NPC.SpawnOnPlayer(Main.myPlayer, NPCType<NPCs.Bosses.CrystalKing>());
				}
			}
			return true;
		}
	}
}