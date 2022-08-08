using System;
using CrystiliumMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.NPCs
{
	public class CrystalArcher : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Archer");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.SkeletonArcher];
		}

		public override void SetDefaults()
		{
			NPC.width = 30;
			NPC.height = 50;
			NPC.damage = 3;
			NPC.defense = 4;
			NPC.lifeMax = 100;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 300f;
			NPC.knockBackResist = 0.5f;
			AnimationType = NPCID.SkeletonArcher;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Main.tile[(int)(spawnInfo.SpawnTileX), (int)(spawnInfo.SpawnTileY)].TileType == ModContent.TileType<Tiles.CrystalBlock>() ? 10f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				//spawn initial set
				for (int i = 1; i <= 3; i++)
				{
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/Crystal_Archer_Gore_" + i).Type);
				}
				//spawn a couple extra bits
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/Crystal_Archer_Gore_4").Type);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/Crystal_Archer_Gore_4").Type);
			}
		}

		public override void OnKill()
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Items.ShinyGemstone>());
			}
		}

		public override void AI()
		{
			bool noXVelocity = false;
			if (NPC.velocity.X == 0f) noXVelocity = true;
			if (NPC.justHit) noXVelocity = false;
			int num68 = 60;
			bool walking = false;
			if (NPC.velocity.Y == 0f && ((NPC.velocity.X > 0f && NPC.direction < 0) || (NPC.velocity.X < 0f && NPC.direction > 0)))
			{
				walking = true;
			}
			if ((NPC.position.X == NPC.oldPosition.X || NPC.ai[3] >= (float)num68) | walking)
			{
				NPC.ai[3] += 1f;
			}
			else if ((double)Math.Abs(NPC.velocity.X) > 0.9 && NPC.ai[3] > 0f)
			{
				NPC.ai[3] -= 1f;
			}
			if (NPC.ai[3] > (float)(num68 * 10))
			{
				NPC.ai[3] = 0f;
			}
			if (NPC.justHit)
			{
				NPC.ai[3] = 0f;
			}
			if (NPC.ai[3] == (float)num68)
			{
				NPC.netUpdate = true;
			}
			if (Main.rand.Next(1000) == 0)
			{
				SoundEngine.PlaySound(SoundID.ZombieMoan, NPC.position);
			}
			NPC.TargetClosest(true);
			float num113 = 1f;
			if (NPC.velocity.X < -num113 || NPC.velocity.X > num113)
			{
				if (NPC.velocity.Y == 0f)
				{
					NPC.velocity *= 0.8f;
				}
			}
			else if (NPC.velocity.X < num113 && NPC.direction == 1)
			{
				NPC.velocity.X = NPC.velocity.X + 0.07f;
				if (NPC.velocity.X > num113)
				{
					NPC.velocity.X = num113;
				}
			}
			else if (NPC.velocity.X > -num113 && NPC.direction == -1)
			{
				NPC.velocity.X = NPC.velocity.X - 0.07f;
				if (NPC.velocity.X < -num113)
				{
					NPC.velocity.X = -num113;
				}
			}
			if (NPC.confused)
				NPC.ai[2] = 0f;
			else
			{
				if (NPC.ai[1] > 0f)
					NPC.ai[1] -= 1f;
				if (NPC.justHit)
				{
					NPC.ai[1] = 30f;
					NPC.ai[2] = 0f;
				}
				if (NPC.ai[2] > 0f)
				{
					if (true)
					{
						NPC.TargetClosest(true);
					}
					if (NPC.ai[1] == 35)
					{
						Vector2 centerVect = NPC.Center;
						float num181 = Main.player[NPC.target].Center.X - NPC.Center.X;
						float num182 = Math.Abs(num181) * 0.1f;
						float num183 = Main.player[NPC.target].Center.Y - NPC.Center.Y - num182;
						num181 += (float)Main.rand.Next(-40, 41);
						num183 += (float)Main.rand.Next(-40, 41);
						float num184 = (float)Math.Sqrt((double)(num181 * num181 + num183 * num183));
						NPC.netUpdate = true;
						num184 = 11 / num184;
						num181 *= num184;
						num183 *= num184;
						int num186 = ModContent.ProjectileType<CrystalArrow>();
						centerVect.X += num181;
						centerVect.Y += num183;
						if (Main.netMode != 1)
						{
							Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, num181, num183, num186, 20, 0f, Main.myPlayer, 0f, 0f);
						}
						if (Math.Abs(num183) > Math.Abs(num181) * 2f)
						{
							if (num183 > 0f)
							{
								NPC.ai[2] = 1f;
							}
							else
							{
								NPC.ai[2] = 5f;
							}
						}
						else if (Math.Abs(num181) > Math.Abs(num183) * 2f)
						{
							NPC.ai[2] = 3f;
						}
						else if (num183 > 0f)
						{
							NPC.ai[2] = 2f;
						}
						else
						{
							NPC.ai[2] = 4f;
						}
					}
					if ((NPC.velocity.Y != 0f && true) || NPC.ai[1] <= 0f)
					{
						NPC.ai[2] = 0f;
						NPC.ai[1] = 0f;
					}
					else
					{
						NPC.velocity.X = NPC.velocity.X * 0.9f;
						NPC.spriteDirection = NPC.direction;
					}
				}
				if ((NPC.ai[2] <= 0f | false) && (NPC.velocity.Y == 0f | false) && NPC.ai[1] <= 0f && !Main.player[NPC.target].dead)
				{
					bool flag22 = Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height);
					if (Main.player[NPC.target].stealth == 0f && Main.player[NPC.target].itemAnimation == 0)
					{
						flag22 = false;
					}
					if (flag22)
					{
						float num190 = 10f;
						Vector2 vector28 = new(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
						float num191 = Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width * 0.5f - vector28.X;
						float num192 = Math.Abs(num191) * 0.1f;
						float num193 = Main.player[NPC.target].position.Y + (float)Main.player[NPC.target].height * 0.5f - vector28.Y - num192;
						num191 += (float)Main.rand.Next(-40, 41);
						num193 += (float)Main.rand.Next(-40, 41);
						float num194 = (float)Math.Sqrt((double)(num191 * num191 + num193 * num193));
						float num195 = 700f;
						if (num194 < num195)
						{
							NPC.netUpdate = true;
							NPC.velocity.X = NPC.velocity.X * 0.5f;
							num194 = num190 / num194;
							num191 *= num194;
							num193 *= num194;
							NPC.ai[2] = 3f;
							NPC.ai[1] = (float)70;
							if (Math.Abs(num193) > Math.Abs(num191) * 2f)
							{
								if (num193 > 0f)
								{
									NPC.ai[2] = 1f;
								}
								else
								{
									NPC.ai[2] = 5f;
								}
							}
							else if (Math.Abs(num191) > Math.Abs(num193) * 2f)
							{
								NPC.ai[2] = 3f;
							}
							else if (num193 > 0f)
							{
								NPC.ai[2] = 2f;
							}
							else
							{
								NPC.ai[2] = 4f;
							}
						}
					}
				}
				if (NPC.ai[2] <= 0f)
				{
					float num196 = 1f;
					float num197 = 0.07f;
					float scaleFactor6 = 0.8f;
					bool flag23 = false;
					if ((NPC.velocity.X < -num196 || NPC.velocity.X > num196) | flag23)
					{
						if (NPC.velocity.Y == 0f)
						{
							NPC.velocity *= scaleFactor6;
						}
					}
					else if (NPC.velocity.X < num196 && NPC.direction == 1)
					{
						NPC.velocity.X = NPC.velocity.X + num197;
						if (NPC.velocity.X > num196)
						{
							NPC.velocity.X = num196;
						}
					}
					else if (NPC.velocity.X > -num196 && NPC.direction == -1)
					{
						NPC.velocity.X = NPC.velocity.X - num197;
						if (NPC.velocity.X < -num196)
						{
							NPC.velocity.X = -num196;
						}
					}
				}
			}
			bool flag24 = false;
			if (NPC.velocity.Y == 0f)
			{
				int num201 = (int)(NPC.position.Y + (float)NPC.height + 7f) / 16;
				int num202 = (int)NPC.position.X / 16;
				int num203 = (int)(NPC.position.X + (float)NPC.width) / 16;
				int num;
				for (int num204 = num202; num204 <= num203; num204 = num + 1)
				{
					if (Main.tile[num204, num201] == null)
					{
						return;
					}
					if (Main.tile[num204, num201].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[num204, num201].TileType])
					{
						flag24 = true;
						break;
					}
					num = num204;
				}
			}
			if (NPC.velocity.Y >= 0f)
			{
				int direction = 0;
				if (NPC.velocity.X < 0f)
				{
					direction = -1;
				}
				if (NPC.velocity.X > 0f)
				{
					direction = 1;
				}
				Vector2 position2 = NPC.position;
				position2.X += NPC.velocity.X;
				int tileX = (int)((position2.X + (float)(NPC.width / 2) + (float)((NPC.width / 2 + 1) * direction)) / 16f);
				int tileY = (int)((position2.Y + (float)NPC.height - 1f) / 16f);
				if (Main.tile[tileX, tileY] == null)
				{
					Main.tile[tileX, tileY] = new Tile();
				}
				if (Main.tile[tileX, tileY - 1] == null)
				{
					Main.tile[tileX, tileY - 1] = new Tile();
				}
				if (Main.tile[tileX, tileY - 2] == null)
				{
					Main.tile[tileX, tileY - 2] = new Tile();
				}
				if (Main.tile[tileX, tileY - 3] == null)
				{
					Main.tile[tileX, tileY - 3] = new Tile();
				}
				if (Main.tile[tileX, tileY + 1] == null)
				{
					Main.tile[tileX, tileY + 1] = new Tile();
				}
				if (Main.tile[tileX - direction, tileY - 3] == null)
				{
					Main.tile[tileX - direction, tileY - 3] = new Tile();
				}
				if ((float)(tileX * 16) < position2.X + (float)NPC.width && (float)(tileX * 16 + 16) > position2.X && ((Main.tile[tileX, tileY].HasUnactuatedTile && !Main.tile[tileX, tileY].TopSlope && !Main.tile[tileX, tileY - 1].TopSlope && Main.tileSolid[(int)Main.tile[tileX, tileY].TileType] && !Main.tileSolidTop[(int)Main.tile[tileX, tileY].TileType]) || (Main.tile[tileX, tileY - 1].IsHalfBlock && Main.tile[tileX, tileY - 1].HasUnactuatedTile)) && (!Main.tile[tileX, tileY - 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX, tileY - 1].TileType] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 1].TileType] || (Main.tile[tileX, tileY - 1].IsHalfBlock && (!Main.tile[tileX, tileY - 4].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX, tileY - 4].TileType] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 4].TileType]))) && (!Main.tile[tileX, tileY - 2].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX, tileY - 2].TileType] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 2].TileType]) && (!Main.tile[tileX, tileY - 3].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX, tileY - 3].TileType] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 3].TileType]) && (!Main.tile[tileX - direction, tileY - 3].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX - direction, tileY - 3].TileType]))
				{
					float num208 = (float)(tileY * 16);
					if (Main.tile[tileX, tileY].IsHalfBlock)
					{
						num208 += 8f;
					}
					if (Main.tile[tileX, tileY - 1].IsHalfBlock)
					{
						num208 -= 8f;
					}
					if (num208 < position2.Y + (float)NPC.height)
					{
						float num209 = position2.Y + (float)NPC.height - num208;
						float num210 = 16.1f;
						if (num209 <= num210)
						{
							NPC.gfxOffY += NPC.position.Y + (float)NPC.height - num208;
							NPC.position.Y = num208 - (float)NPC.height;
							if (num209 < 9f)
							{
								NPC.stepSpeed = 1f;
							}
							else
							{
								NPC.stepSpeed = 2f;
							}
						}
					}
				}
			}
			if (flag24)
			{
				int tileX = (int)((NPC.position.X + (float)(NPC.width / 2) + (float)(15 * NPC.direction)) / 16f);
				int tileY = (int)((NPC.position.Y + (float)NPC.height - 15f) / 16f);
				if (Main.tile[tileX, tileY] == null)
				{
					Main.tile[tileX, tileY] = new Tile();
				}
				if (Main.tile[tileX, tileY - 1] == null)
				{
					Main.tile[tileX, tileY - 1] = new Tile();
				}
				if (Main.tile[tileX, tileY - 2] == null)
				{
					Main.tile[tileX, tileY - 2] = new Tile();
				}
				if (Main.tile[tileX, tileY - 3] == null)
				{
					Main.tile[tileX, tileY - 3] = new Tile();
				}
				if (Main.tile[tileX, tileY + 1] == null)
				{
					Main.tile[tileX, tileY + 1] = new Tile();
				}
				if (Main.tile[tileX + NPC.direction, tileY - 1] == null)
				{
					Main.tile[tileX + NPC.direction, tileY - 1] = new Tile();
				}
				if (Main.tile[tileX + NPC.direction, tileY + 1] == null)
				{
					Main.tile[tileX + NPC.direction, tileY + 1] = new Tile();
				}
				if (Main.tile[tileX - NPC.direction, tileY + 1] == null)
				{
					Main.tile[tileX - NPC.direction, tileY + 1] = new Tile();
				}
				Main.tile[tileX, tileY + 1].IsHalfBlock;
				int spriteDirection = NPC.spriteDirection;
				if ((NPC.velocity.X < 0f && spriteDirection == -1) || (NPC.velocity.X > 0f && spriteDirection == 1))
				{
					if (NPC.height >= 32 && Main.tile[tileX, tileY - 2].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[tileX, tileY - 2].TileType])
					{
						if (Main.tile[tileX, tileY - 3].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[tileX, tileY - 3].TileType])
						{
							NPC.velocity.Y = -8f;
							NPC.netUpdate = true;
						}
						else
						{
							NPC.velocity.Y = -7f;
							NPC.netUpdate = true;
						}
					}
					else if (Main.tile[tileX, tileY - 1].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[tileX, tileY - 1].TileType])
					{
						NPC.velocity.Y = -6f;
						NPC.netUpdate = true;
					}
					else if (NPC.position.Y + (float)NPC.height - (float)(tileY * 16) > 20f && Main.tile[tileX, tileY].HasUnactuatedTile && !Main.tile[tileX, tileY].TopSlope && Main.tileSolid[(int)Main.tile[tileX, tileY].TileType])
					{
						NPC.velocity.Y = -5f;
						NPC.netUpdate = true;
					}
					else if (NPC.directionY < 0 && (!Main.tile[tileX, tileY + 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX, tileY + 1].TileType]) && (!Main.tile[tileX + NPC.direction, tileY + 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX + NPC.direction, tileY + 1].TileType]))
					{
						NPC.velocity.Y = -8f;
						NPC.velocity.X = NPC.velocity.X * 1.5f;
						NPC.netUpdate = true;
					}
					if ((NPC.velocity.Y == 0f & noXVelocity) && NPC.ai[3] == 1f)
					{
						NPC.velocity.Y = -5f;
					}
				}
			}
		}
	}
}