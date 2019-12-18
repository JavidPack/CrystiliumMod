using CrystiliumMod.Items.Weapons;
using CrystiliumMod.Projectiles.CrystalKing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;

namespace CrystiliumMod.NPCs.Bosses
{
	[AutoloadBossHead]
	public class CrystalKing : ModNPC
	{
		private int timer = 0;
		private int timer2 = 0;
		private int timer3 = 0;
		private int timer4 = 0;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal King");
			Main.npcFrameCount[npc.type] = 8;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.width = 184;
			npc.height = 170;
			npc.damage = 87;
			npc.defense = 58;
			npc.lifeMax = 46500;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 60000f;
			bossBag = ItemType<Items.CrystalBag>();
			npc.knockBackResist = 0f;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/CrystalKing");
			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.boss = true;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				//spawn all gores once
				for (int i = 1; i <= 10; i++)
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KingGore" + i));
				}
			}
		}

		public override void AI()
		{
			// TODO: Huge multiplayer syncing issues.

			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				npc.velocity.Y = -50;
				timer = 0;
				timer2 = 0;
				timer3 = 0;
				timer4 = 0;
			}
			timer++;
			if (timer <= 900)
			{
				timer2++;
			}
			if (timer <= 900)
			{
				timer3++;
			}
			if (timer >= 900)
			{
				timer4++;
			}

			//start of movement
			if (timer == 3 || timer == 100 || timer == 200 || timer == 300 || timer == 400 || timer == 500)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				npc.velocity.Y = direction.Y * 12f;
				npc.velocity.X = direction.X * 12f;
			}

			if (timer == 75 || timer == 175 || timer == 275 || timer == 375 || timer == 475)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				npc.velocity.Y = direction.Y * 6f;
				npc.velocity.X = direction.X * 6f;
			}

			if (timer >= 600 && timer <= 900)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				npc.velocity.Y = direction.Y * 8f;
				npc.velocity.X = direction.X * 8f;
			}

			if (timer >= 900)
			{
				npc.velocity.Y = 0;
				npc.velocity.X = 0;
				if (Main.rand.Next(70) == 0)
				{
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCType<CrystalCultist>());
				}
			}

			//end of move
			if (timer == 1100)
			{
				timer = 0;
			}

			if (timer2 == 50)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 10f, direction.Y * 10f, ProjectileType<Slasher>(), 50, 1, Main.myPlayer, 0, 0);
				timer2 = 0;
			}

			if (timer3 == 225)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				direction.X *= 17f;
				direction.Y *= 17f;
				timer3 = 0;
				int amountOfProjectiles = Main.rand.Next(10, 15);
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float A = (float)Main.rand.Next(-150, 150) * 0.01f;
					float B = (float)Main.rand.Next(-150, 150) * 0.01f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, ProjectileType<CultistFire>(), 60, 1, Main.myPlayer, 0, 0);
				}
			}

			if (timer4 >= 25 && Main.expertMode)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				Vector2 newVect = direction.RotatedBy(System.Math.PI / 13);
				Vector2 newVect2 = direction.RotatedBy(-System.Math.PI / 13);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 20f, direction.Y * 20f, ProjectileType<Kingwave>(), 55, 1, Main.myPlayer, 0, 0);
				if (npc.life <= 46500)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, newVect.X * 20f, newVect.Y * 20f, ProjectileType<Kingwave>(), 55, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, newVect2.X * 20f, newVect2.Y * 20f, ProjectileType<Kingwave>(), 55, 1, Main.myPlayer, 0, 0);
				}
				timer4 = 0;
			}

			if (timer4 >= 50 && !Main.expertMode)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				Vector2 newVect = direction.RotatedBy(System.Math.PI / 20);
				Vector2 newVect2 = direction.RotatedBy(-System.Math.PI / 20);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 20f, direction.Y * 20f, ProjectileType<Projectiles.CrystalKing.Kingwave>(), 50, 1, Main.myPlayer, 0, 0);
				if (npc.life <= 23250)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, newVect.X * 20f, newVect.Y * 20f, ProjectileType<Kingwave>(), 50, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, newVect2.X * 20f, newVect2.Y * 20f, ProjectileType<Kingwave>(), 50, 1, Main.myPlayer, 0, 0);
				}

				timer4 = 0;
			}
		}

		public override void FindFrame(int frameHeight)
		{
			int frameWidth = 184; // I'm just hardcoding this, since this is the frame width of one frame along the X axis.
			npc.spriteDirection = npc.direction;

			// Now if you want to animate, you can do:
			npc.frameCounter++;
			if (npc.frameCounter >= 4)
			{
				npc.frame.Y += frameHeight;
				if (npc.frame.Y >= 1360)
				{
					npc.frame.Y = 0;
					npc.frame.X = (npc.frame.X + frameWidth) % (2 * frameWidth);
				}

				npc.frameCounter = 0;
			}

			npc.frame.Width = frameWidth;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);

			Vector2 drawPos = new Vector2(
				npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
				npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);

			SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);

			return false; // We return false, since we don't want vanilla drawing to execute.
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Placeable.KingTrophy>());
			}
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Armor.CrystalMask>());
				}
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.CrystiliumBar>(), Main.rand.Next(13, 20));

				var ChoiceChooser = new WeightedRandom<int>();
				ChoiceChooser.Add(ItemType<Cryst>());
				ChoiceChooser.Add(ItemType<Callandor>());
				ChoiceChooser.Add(ItemType<QuartzSpear>());
				ChoiceChooser.Add(ItemType<ShiningTrigger>());
				ChoiceChooser.Add(ItemType<Slamborite>());
				ChoiceChooser.Add(ItemType<Shimmer>());
				ChoiceChooser.Add(ItemType<Shatterocket>());
				ChoiceChooser.Add(ItemType<RoyalShredder>());
				int Choice = ChoiceChooser;
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Choice);
			}
			if (!CrystalWorld.downedCrystalKing)
			{
				CrystalWorld.downedCrystalKing = true;
				if(Main.netMode == NetmodeID.Server)
					NetMessage.SendData(MessageID.WorldData);
			}
		}
	}
}