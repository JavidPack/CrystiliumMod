using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
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
			frame = (frame + 1) % 6;
			frameCounter = 0;
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
			Main.LocalPlayer.showItemIcon2 = mod.ItemType<Items.CrypticCrystal>();
		}

		public override void RightClick(int i, int j)
		{
			//don't bother if there's already a Crystal King in the world
			for (int x = 0; x < Main.npc.Length; x++)
			{
				if (Main.npc[x].active && Main.npc[x].type == mod.NPCType<NPCs.Bosses.CrystalKing>()) return;
			}

			//check if player has a Cryptic Crystal
			if (Main.LocalPlayer.HasItem(mod.ItemType<Items.CrypticCrystal>()))
			{
				// TODO, someone said this didn't work. Migrate to Main.LocalPlayer.ConsumeItem() and check MP code.
				//now to search for it
				Item[] inventory = Main.LocalPlayer.inventory;
				for (int k = 0; k < inventory.Length; k++)
				{
					if (inventory[k].type == mod.ItemType<Items.CrypticCrystal>())
					{
						//consume it, and summon the Crystal King!
						inventory[k].stack--;
						if (inventory[k].stack == 0)
						{
							inventory[k].TurnToAir();
						}
						if (Main.netMode == NetmodeID.MultiplayerClient)
						{
							ModPacket packet = mod.GetPacket();
							packet.Write((byte)CrystiliumModMessageType.SpawnBossSpecial);
							packet.Send();
						}
						else
						{
							NPC.SpawnOnPlayer(Main.myPlayer, mod.NPCType<NPCs.Bosses.CrystalKing>());
						}

						//and don't spam crystal kings if the player didn't ask for it :P
						return;
					}
				}
			}
		}
	}
}