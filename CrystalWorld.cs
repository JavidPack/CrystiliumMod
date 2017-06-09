using CrystiliumMod.Tiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace CrystiliumMod
{
	public class CrystalWorld : ModWorld
	{
		public static int CrystalTiles = 0;
		private static List<Point> BiomeCenters;

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			BiomeCenters = new List<Point>();

			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				// Shinies pass removed by some other mod.
				return;
			}
			tasks.Insert(ShiniesIndex + 1, new PassLegacy("CrystalBiomeGen", delegate (GenerationProgress progress)
			{
				progress.Message = "Polishing crystals";
				// 4200 1200
				// 8400 2400
				// 3 in small
				// 6 large
				for (int i = 0; i < (int)Main.maxTilesX / 1400; i++)
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


					/*bool placeSuccessful = false;
					Tile tileResult;
					int x;
					int y;
					int maxTries = 10000;
					int tries = 0;
					int successes = 0;

					WorldGen.digTunnel(Xvalue + 400, Yvalue + 400, 0, 0, WorldGen.genRand.Next(15, 18), WorldGen.genRand.Next(14, 17), false);
					while(tries < maxTries && successes < 5)
					{
						x = Xvalue + WorldGen.genRand.Next(350, 450);
						y = Yvalue + WorldGen.genRand.Next(350, 450);
						WorldGen.PlaceChest(x, y, (ushort)mod.TileType<Tiles.CrystalChest>(), false, 2);
						tileResult = Main.tile[x, y];
						placeSuccessful = tileResult.active() && tileResult.type == mod.TileType<Tiles.CrystalChest>();
						if (placeSuccessful) successes++;
						tries++;
					}*/

					int x;
					int y;
					int maxTries = 20000;
					int tries = 0;
					int successes = 0;

					WorldGen.digTunnel(Xvalue + 400, Yvalue + 400, 0, 0, WorldGen.genRand.Next(15, 18), WorldGen.genRand.Next(14, 17), false);
					while (tries < maxTries && successes < 5)
					{
						x = Xvalue + WorldGen.genRand.Next(350, 450);
						y = Yvalue + WorldGen.genRand.Next(350, 450);
						if (WorldGen.PlaceChest(x, y, (ushort)mod.TileType<Tiles.CrystalChest>(), false, 2) != -1)
						{
							successes++;
						}
						tries++;
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
					for (int trees = 0; trees < 50000; trees++)
					{
						int E = Xvalue + WorldGen.genRand.Next(340, 460);
						int F = Yvalue + WorldGen.genRand.Next(340, 460);
						Tile tile = Framing.GetTileSafely(E, F);
						if (tile.type == mod.TileType<CrystalBlock>() || tile.type == mod.TileType<FountainBlock>())
						{
							WorldGen.GrowTree(E, F);
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


					BiomeCenters.Add(new Point(XvalueMid, YvalueMid));
				}
			}));

			int LihzahrdAltarsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Lihzahrd Altars"));
			if (LihzahrdAltarsIndex == -1)
			{
				// Lihzahrd Altars pass removed by some other mod.
				return;
			}
			tasks.Insert(LihzahrdAltarsIndex, new PassLegacy("CrystalBiomeGenFountain", delegate (GenerationProgress progress)
			{
				progress.Message = "Polishing more crystals";

				if (BiomeCenters != null)
				{
					foreach (var center in BiomeCenters)
					{
						int XvalueMid = center.X;
						int YvalueMid = center.Y;

						for (int X1 = -4; X1 < 10; X1++)
						{
							for (int Y1 = 0; Y1 < 7; Y1++)
							{
								WorldGen.KillTile(XvalueMid + X1, YvalueMid - Y1);
							}
							WorldGen.PlaceTile(XvalueMid + X1, YvalueMid, mod.TileType<FountainBlock>(), forced: true);
						}
						for (int X1 = -2; X1 < 8; X1++)
						{
							WorldGen.PlaceTile(XvalueMid + X1, YvalueMid + 1, mod.TileType<CrystalBlock>());
						}
						for (int X1 = -1; X1 < 7; X1++)
						{
							WorldGen.PlaceTile(XvalueMid + X1, YvalueMid + 2, mod.TileType<CrystalBlock>());
						}
						WorldGen.PlaceObject(XvalueMid, YvalueMid - 6, mod.TileType<Fountain>());
						WorldGen.PlaceObject(XvalueMid - 1, YvalueMid - 1, TileID.Lamps, false, 5); // Style 5 Lamp is FrozenLamp
						WorldGen.PlaceObject(XvalueMid - 4, YvalueMid - 1, mod.TileType<Crystal>());
						WorldGen.PlaceObject(XvalueMid + 7, YvalueMid - 1, mod.TileType<Crystal>());
						WorldGen.PlaceObject(XvalueMid + 6, YvalueMid - 1, TileID.Lamps, false, 5);
					}
				}
			}));
		}

		// TODO, this is ugly code, overwriting the first choice.
		public override void PostWorldGen()
		{
			// place 3 or 4 items in each crystal chest
			int upperLimit = Main.rand.Next(3, 5);
			for (int i = 0; i < upperLimit; i++)
			{
				int[] itemsToPlaceInGlassChestsSecondary = new int[] { mod.ItemType<Items.CrystalBottle>(), mod.ItemType<Items.ShinyGemstone>(), mod.ItemType<Items.RadiantPrism>(), mod.ItemType<Items.GeodeItem>(), ItemID.GoldCoin };
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
			// is this suppose to be an additional item?
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
			CrystalPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CrystalPlayer>();
			modPlayer.crystalFountain = false;
			CrystalTiles = 0;
		}

		public override void TileCountsAvailable(int[] tileCounts)
		{
			CrystalTiles = tileCounts[mod.TileType<CrystalBlock>()];
		}
	}
}