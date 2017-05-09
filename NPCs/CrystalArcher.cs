using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.NPCs
{
	public class CrystalArcher : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Crystal Archer";
			npc.displayName = "Crystal Archer";
			npc.width = 30;
			npc.height = 50;
			npc.damage = 3;
			npc.defense = 4;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 300f;
			npc.knockBackResist = 0.5f;
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[110];
			animationType = 110;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return Main.tile[(int)(spawnInfo.spawnTileX),(int)(spawnInfo.spawnTileY)].type == mod.TileType("CrystalBlock") ? 10f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if(npc.life <= 0) {
				//spawn initial set
				for(int i = 1; i <= 3; i++) {
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Archer_Gore_" + i));
				}
				//spawn a couple extra bits
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Archer_Gore_4"));
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Archer_Gore_4"));
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShinyGemstone"));
			}
		}
		
		public override void AI()
		{
			bool noXVelocity = false;
			if(npc.velocity.X == 0f) noXVelocity = true;
			if(npc.justHit) noXVelocity = false;
			int num68 = 60;
			bool walking = false;
			if(npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0))) {
				walking = true;
			}
			if((npc.position.X == npc.oldPosition.X || npc.ai[3] >= (float)num68) | walking) {
				npc.ai[3] += 1f;
			} else if((double)Math.Abs(npc.velocity.X) > 0.9 && npc.ai[3] > 0f) {
				npc.ai[3] -= 1f;
			}
			if(npc.ai[3] > (float)(num68 * 10)) {
				npc.ai[3] = 0f;
			}
			if(npc.justHit) {
				npc.ai[3] = 0f;
			}
			if(npc.ai[3] == (float)num68) {
				npc.netUpdate = true;
			}
			if(Main.rand.Next(1000) == 0) {
				Main.PlaySound(14, (int)npc.position.X, (int)npc.position.Y, 1);
			}
			npc.TargetClosest(true);
			float num113 = 1f;
			if(npc.velocity.X < -num113 || npc.velocity.X > num113) {
				if(npc.velocity.Y == 0f) {
					npc.velocity *= 0.8f;
				}
			} 
			else if(npc.velocity.X < num113 && npc.direction == 1) {
				npc.velocity.X = npc.velocity.X + 0.07f;
				if(npc.velocity.X > num113) {
					npc.velocity.X = num113;
				}
			} 
			else if(npc.velocity.X > -num113 && npc.direction == -1) {
				npc.velocity.X = npc.velocity.X - 0.07f;
				if(npc.velocity.X < -num113) {
					npc.velocity.X = -num113;
				}
			}
			if(npc.confused)
				npc.ai[2] = 0f;
			else {
				if(npc.ai[1] > 0f)
					npc.ai[1] -= 1f;
				if(npc.justHit) {
					npc.ai[1] = 30f;
					npc.ai[2] = 0f;
				}
				if(npc.ai[2] > 0f) {
					if(true) {
						npc.TargetClosest(true);
					}
					if(npc.ai[1] == 35) {
						Vector2 centerVect = npc.Center;
						float num181 = Main.player[npc.target].Center.X - npc.Center.X;
						float num182 = Math.Abs(num181) * 0.1f;
						float num183 = Main.player[npc.target].Center.Y - npc.Center.Y - num182;
						num181 += (float)Main.rand.Next(-40, 41);
						num183 += (float)Main.rand.Next(-40, 41);
						float num184 = (float)Math.Sqrt((double)(num181 * num181 + num183 * num183));
						npc.netUpdate = true;
						num184 = 11 / num184;
						num181 *= num184;
						num183 *= num184;
						int num186 = mod.ProjectileType("CrystalArrow");
						centerVect.X += num181;
						centerVect.Y += num183;
						if(Main.netMode != 1) {
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num181, num183, num186, 20, 0f, Main.myPlayer, 0f, 0f);
						}
						if(Math.Abs(num183) > Math.Abs(num181) * 2f) {
							if(num183 > 0f) {
								npc.ai[2] = 1f;
							} else {
								npc.ai[2] = 5f;
							}
						} else if(Math.Abs(num181) > Math.Abs(num183) * 2f) {
							npc.ai[2] = 3f;
						} else if(num183 > 0f) {
							npc.ai[2] = 2f;
						} else {
							npc.ai[2] = 4f;
						}
					}
					if((npc.velocity.Y != 0f && true) || npc.ai[1] <= 0f) {
						npc.ai[2] = 0f;
						npc.ai[1] = 0f;
					} else {
						npc.velocity.X = npc.velocity.X * 0.9f;
						npc.spriteDirection = npc.direction;
					}
				}
				if((npc.ai[2] <= 0f | false) && (npc.velocity.Y == 0f | false) && npc.ai[1] <= 0f && !Main.player[npc.target].dead) {
					bool flag22 = Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height);
					if(Main.player[npc.target].stealth == 0f && Main.player[npc.target].itemAnimation == 0) {
						flag22 = false;
					}
					if(flag22) {
						float num190 = 10f;
						Vector2 vector28 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
						float num191 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector28.X;
						float num192 = Math.Abs(num191) * 0.1f;
						float num193 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector28.Y - num192;
						num191 += (float)Main.rand.Next(-40, 41);
						num193 += (float)Main.rand.Next(-40, 41);
						float num194 = (float)Math.Sqrt((double)(num191 * num191 + num193 * num193));
						float num195 = 700f;
						if(num194 < num195) {
							npc.netUpdate = true;
							npc.velocity.X = npc.velocity.X * 0.5f;
							num194 = num190 / num194;
							num191 *= num194;
							num193 *= num194;
							npc.ai[2] = 3f;
							npc.ai[1] = (float)70;
							if(Math.Abs(num193) > Math.Abs(num191) * 2f) {
								if(num193 > 0f) {
									npc.ai[2] = 1f;
								} else {
									npc.ai[2] = 5f;
								}
							} else if(Math.Abs(num191) > Math.Abs(num193) * 2f) {
								npc.ai[2] = 3f;
							} else if(num193 > 0f) {
								npc.ai[2] = 2f;
							} else {
								npc.ai[2] = 4f;
							}
						}
					}
				}
				if(npc.ai[2] <= 0f) {
					float num196 = 1f;
					float num197 = 0.07f;
					float scaleFactor6 = 0.8f;
					bool flag23 = false;
					if((npc.velocity.X < -num196 || npc.velocity.X > num196) | flag23) {
						if(npc.velocity.Y == 0f) {
							npc.velocity *= scaleFactor6;
						}
					} else if(npc.velocity.X < num196 && npc.direction == 1) {
						npc.velocity.X = npc.velocity.X + num197;
						if(npc.velocity.X > num196) {
							npc.velocity.X = num196;
						}
					} else if(npc.velocity.X > -num196 && npc.direction == -1) {
						npc.velocity.X = npc.velocity.X - num197;
						if(npc.velocity.X < -num196) {
							npc.velocity.X = -num196;
						}
					}
				}
			}
			bool flag24 = false;
			if(npc.velocity.Y == 0f) {
				int num201 = (int)(npc.position.Y + (float)npc.height + 7f) / 16;
				int num202 = (int)npc.position.X / 16;
				int num203 = (int)(npc.position.X + (float)npc.width) / 16;
				int num;
				for(int num204 = num202; num204 <= num203; num204 = num + 1) {
					if(Main.tile[num204, num201] == null) {
						return;
					}
					if(Main.tile[num204, num201].nactive() && Main.tileSolid[(int)Main.tile[num204, num201].type]) {
						flag24 = true;
						break;
					}
					num = num204;
				}
			}
			if(npc.velocity.Y >= 0f) {
				int direction = 0;
				if(npc.velocity.X < 0f) {
					direction = -1;
				}
				if(npc.velocity.X > 0f) {
					direction = 1;
				}
				Vector2 position2 = npc.position;
				position2.X += npc.velocity.X;
				int tileX = (int)((position2.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 1) * direction)) / 16f);
				int tileY = (int)((position2.Y + (float)npc.height - 1f) / 16f);
				if(Main.tile[tileX, tileY] == null) {
					Main.tile[tileX, tileY] = new Tile();
				}
				if(Main.tile[tileX, tileY - 1] == null) {
					Main.tile[tileX, tileY - 1] = new Tile();
				}
				if(Main.tile[tileX, tileY - 2] == null) {
					Main.tile[tileX, tileY - 2] = new Tile();
				}
				if(Main.tile[tileX, tileY - 3] == null) {
					Main.tile[tileX, tileY - 3] = new Tile();
				}
				if(Main.tile[tileX, tileY + 1] == null) {
					Main.tile[tileX, tileY + 1] = new Tile();
				}
				if(Main.tile[tileX - direction, tileY - 3] == null) {
					Main.tile[tileX - direction, tileY - 3] = new Tile();
				}
				if((float)(tileX * 16) < position2.X + (float)npc.width && (float)(tileX * 16 + 16) > position2.X && ((Main.tile[tileX, tileY].nactive() && !Main.tile[tileX, tileY].topSlope() && !Main.tile[tileX, tileY - 1].topSlope() && Main.tileSolid[(int)Main.tile[tileX, tileY].type] && !Main.tileSolidTop[(int)Main.tile[tileX, tileY].type]) || (Main.tile[tileX, tileY - 1].halfBrick() && Main.tile[tileX, tileY - 1].nactive())) && (!Main.tile[tileX, tileY - 1].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 1].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 1].type] || (Main.tile[tileX, tileY - 1].halfBrick() && (!Main.tile[tileX, tileY - 4].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 4].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 4].type]))) && (!Main.tile[tileX, tileY - 2].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 2].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 2].type]) && (!Main.tile[tileX, tileY - 3].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 3].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 3].type]) && (!Main.tile[tileX - direction, tileY - 3].nactive() || !Main.tileSolid[(int)Main.tile[tileX - direction, tileY - 3].type])) {
					float num208 = (float)(tileY * 16);
					if(Main.tile[tileX, tileY].halfBrick()) {
						num208 += 8f;
					}
					if(Main.tile[tileX, tileY - 1].halfBrick()) {
						num208 -= 8f;
					}
					if(num208 < position2.Y + (float)npc.height) {
						float num209 = position2.Y + (float)npc.height - num208;
						float num210 = 16.1f;
						if(num209 <= num210) {
							npc.gfxOffY += npc.position.Y + (float)npc.height - num208;
							npc.position.Y = num208 - (float)npc.height;
							if(num209 < 9f) {
								npc.stepSpeed = 1f;
							} else {
								npc.stepSpeed = 2f;
							}
						}
					}
				}
			}
			if(flag24) {
				int tileX = (int)((npc.position.X + (float)(npc.width / 2) + (float)(15 * npc.direction)) / 16f);
				int tileY = (int)((npc.position.Y + (float)npc.height - 15f) / 16f);
				if(Main.tile[tileX, tileY] == null) {
					Main.tile[tileX, tileY] = new Tile();
				}
				if(Main.tile[tileX, tileY - 1] == null) {
					Main.tile[tileX, tileY - 1] = new Tile();
				}
				if(Main.tile[tileX, tileY - 2] == null) {
					Main.tile[tileX, tileY - 2] = new Tile();
				}
				if(Main.tile[tileX, tileY - 3] == null) {
					Main.tile[tileX, tileY - 3] = new Tile();
				}
				if(Main.tile[tileX, tileY + 1] == null) {
					Main.tile[tileX, tileY + 1] = new Tile();
				}
				if(Main.tile[tileX + npc.direction, tileY - 1] == null) {
					Main.tile[tileX + npc.direction, tileY - 1] = new Tile();
				}
				if(Main.tile[tileX + npc.direction, tileY + 1] == null) {
					Main.tile[tileX + npc.direction, tileY + 1] = new Tile();
				}
				if(Main.tile[tileX - npc.direction, tileY + 1] == null) {
					Main.tile[tileX - npc.direction, tileY + 1] = new Tile();
				}
				Main.tile[tileX, tileY + 1].halfBrick();
				int spriteDirection = npc.spriteDirection;
				if((npc.velocity.X < 0f && spriteDirection == -1) || (npc.velocity.X > 0f && spriteDirection == 1)) {
					if(npc.height >= 32 && Main.tile[tileX, tileY - 2].nactive() && Main.tileSolid[(int)Main.tile[tileX, tileY - 2].type]) {
						if(Main.tile[tileX, tileY - 3].nactive() && Main.tileSolid[(int)Main.tile[tileX, tileY - 3].type]) {
							npc.velocity.Y = -8f;
							npc.netUpdate = true;
						} else {
							npc.velocity.Y = -7f;
							npc.netUpdate = true;
						}
					} else if(Main.tile[tileX, tileY - 1].nactive() && Main.tileSolid[(int)Main.tile[tileX, tileY - 1].type]) {
						npc.velocity.Y = -6f;
						npc.netUpdate = true;
					} else if(npc.position.Y + (float)npc.height - (float)(tileY * 16) > 20f && Main.tile[tileX, tileY].nactive() && !Main.tile[tileX, tileY].topSlope() && Main.tileSolid[(int)Main.tile[tileX, tileY].type]) {
						npc.velocity.Y = -5f;
						npc.netUpdate = true;
					} else if(npc.directionY < 0 && (!Main.tile[tileX, tileY + 1].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY + 1].type]) && (!Main.tile[tileX + npc.direction, tileY + 1].nactive() || !Main.tileSolid[(int)Main.tile[tileX + npc.direction, tileY + 1].type])) {
						npc.velocity.Y = -8f;
						npc.velocity.X = npc.velocity.X * 1.5f;
						npc.netUpdate = true;
					}
					if((npc.velocity.Y == 0f & noXVelocity) && npc.ai[3] == 1f) {
						npc.velocity.Y = -5f;
					}
				}
			}
		}
	}
}