using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using CrystiliumMod.Tiles;

namespace CrystiliumMod
{
	public class CrystalWorld : ModWorld
	{
		public static int CrystalTiles = 0;
		public int Num;

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				// Shinies pass removed by some other mod.
				return;
			}
			tasks.Insert(ShiniesIndex + 1, new PassLegacy("CrystalBiomeGen", delegate (GenerationProgress progress)
		   {
			   progress.Message = "Polishing crystals";

			   for (int i = 0; i < (int)Main.maxTilesX / 900; i++)
			   {
				   int Xvalue = WorldGen.genRand.Next(50, Main.maxTilesX - 700);
				   int Yvalue = WorldGen.genRand.Next((int)WorldGen.rockLayer - 200, Main.maxTilesY - 700);
				   int XvalueHigh = Xvalue + 800;
				   int YvalueHigh = Yvalue + 800;
				   int XvalueMid = Xvalue + 400;
				   int YvalueMid = Yvalue + 400;

				   WorldGen.TileRunner(XvalueMid, YvalueMid, (double)WorldGen.genRand.Next(300, 300), 1, mod.TileType<Tiles.CrystalBlock>(), false, 0f, 0f, true, true); //c = x, d = y
																																										 /*		for (int A = Xvalue; A < XvalueHigh; A++)
																																												 {
																																													 for (int B = Yvalue; B < YvalueHigh; B++)
																																													 {
																																														 if (Main.tile[A,B] != null)
																																														 {
																																															 if (Main.tile[A,B].type ==  mod.TileType<Tiles.CrystalBlock>()) // A = x, B = y.
																																															 { 
																																																 WorldGen.KillWall(A, B);
																																																 WorldGen.PlaceWall(A, B, mod.WallType("CrystalWall"));
																																															 }
																																														 }
																																													 }
																																												 }*/

				   WorldGen.digTunnel(Xvalue + 400, Yvalue + 400, 0, 0, WorldGen.genRand.Next(15, 18), WorldGen.genRand.Next(14, 17), false);
				   for (int C = 0; C < 400; C++)
				   {
					   WorldGen.PlaceChest(Xvalue + WorldGen.genRand.Next(350, 450), Yvalue + WorldGen.genRand.Next(350, 450), (ushort)mod.TileType<Tiles.CrystalChest>(), false, 2);
				   }
				   for (int C = 0; C < 40; C++)
				   {
					   int E = Xvalue + WorldGen.genRand.Next(340, 460);
					   int F = Yvalue + WorldGen.genRand.Next(340, 460);
					   WorldGen.PlaceTile(E, F, mod.TileType<GlowingCrystal2>());
				   }
				   for (int C = 0; C < 35; C++)
				   {
					   int E = Xvalue + WorldGen.genRand.Next(340, 460);
					   int F = Yvalue + WorldGen.genRand.Next(340, 460);
					   if (Main.tile[E, F] != null)
					   {
						   WorldGen.PlaceTile(E, F, mod.TileType<GlowingCrystal>());
					   }
				   }
				   for (int Ore = 0; Ore < 650; Ore++)
				   {
					   int Xore = XvalueMid + Main.rand.Next(-300, 300);
					   int Yore = YvalueMid + Main.rand.Next(-300, 300);
					   if (Main.tile[Xore, Yore].type == mod.TileType<CrystalBlock>()) // A = x, B = y.
					   {
						   WorldGen.TileRunner(Xore, Yore, (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), mod.TileType<RadiantOre>(), false, 0f, 0f, false, true);
					   }
				   }
				   for (int X1 = -4; X1 < 10; X1++)
				   {
					   for (int Y1 = 0; Y1 < 7; Y1++)
					   {
						   WorldGen.KillTile(XvalueMid + X1, YvalueMid - Y1);
						   WorldGen.PlaceTile(XvalueMid + X1, YvalueMid, mod.TileType<FountainBlock>());
					   }
				   }
				   for (int X1 = -2; X1 < 8; X1++)
				   {
					   WorldGen.PlaceTile(XvalueMid + X1, YvalueMid + 1, mod.TileType<CrystalBlock>());
				   }
				   for (int X1 = -1; X1 < 7; X1++)
				   {
					   WorldGen.PlaceTile(XvalueMid + X1, YvalueMid + 2, mod.TileType<CrystalBlock>());
				   }
				   WorldGen.PlaceObject(XvalueMid, YvalueMid - 1, mod.TileType<Fountain>());
				   WorldGen.PlaceObject(XvalueMid, YvalueMid - 6, mod.TileType<Fountain>());
				   WorldGen.PlaceObject(XvalueMid + 1, YvalueMid - 6, mod.TileType<Fountain>());
				   WorldGen.PlaceObject(XvalueMid - 1, YvalueMid - 1, 93, false, 5);
				   WorldGen.PlaceObject(XvalueMid - 4, YvalueMid - 1, mod.TileType<Crystal>());
				   WorldGen.PlaceObject(XvalueMid + 7, YvalueMid - 1, mod.TileType<Crystal>());
				   WorldGen.PlaceObject(XvalueMid + 6, YvalueMid - 1, 93, false, 5);

			   }
		   }));
		}

		public override void PostWorldGen()
		{


			for (int i = 1; i < Main.rand.Next(4, 6); i++)
			{
				int[] itemsToPlaceInGlassChestsSecondary = new int[] { mod.ItemType<Items.CrystalBottle>(), mod.ItemType<Items.ShinyGemstone>(), mod.ItemType<Items.RadiantPrism>(), mod.ItemType<Items.GeodeItem>(), 73 };
				int itemsToPlaceInGlassChestsSecondaryChoice = 0;
				for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
				{
					Chest chest = Main.chest[chestIndex];
					if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType<CrystalChest>())
					{
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == 0)
							{
								itemsToPlaceInGlassChestsSecondaryChoice = Main.rand.Next(itemsToPlaceInGlassChestsSecondary.Length);
								chest.item[inventoryIndex].SetDefaults(itemsToPlaceInGlassChestsSecondary[itemsToPlaceInGlassChestsSecondaryChoice]); //the error is at this line
								chest.item[inventoryIndex].stack = Main.rand.Next(1, 7);
								//itemsToPlaceInGlassChestsSecondaryChoice = (itemsToPlaceInGlassChestsSecondaryChoice + 1) % itemsToPlaceInGlassChestsSecondary.Length;
								break;
							}
						}
					}
				}
			}
			int[] itemsToPlaceInGlassChests = new int[] { mod.ItemType<Items.Weapons.CrystalStaff>(), mod.ItemType<Items.Weapons.CrystalEdge>(), mod.ItemType<Items.Weapons.GemFury>(), mod.ItemType<Items.Weapons.Geode>(), mod.ItemType<Items.Weapons.PrismCast>(), mod.ItemType<Items.Weapons.Glowstrike>(), mod.ItemType<Items.Weapons.Sharpoon>() };
			int itemsToPlaceInGlassChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].type/*.frameX == 47 * 36*/ == mod.TileType<CrystalChest>()) // if glass chest
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						itemsToPlaceInGlassChestsChoice = Main.rand.Next(itemsToPlaceInGlassChests.Length);
						chest.item[0].SetDefaults(itemsToPlaceInGlassChests[itemsToPlaceInGlassChestsChoice]);
						//itemsToPlaceInGlassChestsChoice = (itemsToPlaceInGlassChestsChoice + 1) % itemsToPlaceInGlassChests.Length;
						break;
					}
				}
			}
		}
		public override void ResetNearbyTileEffects()
		{
			CrystalPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<CrystalPlayer>(mod);
			modPlayer.crystalFountain = false;
		}

		public override void TileCountsAvailable(int[] tileCounts)
		{
			CrystalTiles = tileCounts[mod.TileType<CrystalBlock>()];
		}
	}
}
