using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.NPCs
{
	public class GeodeMonster : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Geode Mutant");
			Main.npcFrameCount[NPC.type] = 8;
		}

		public override void SetDefaults()
		{
			NPC.damage = 54;
			NPC.defense = 18;
			NPC.height = 56;
			NPC.width = 70;
			NPC.lifeMax = 350;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.height = 56;
			NPC.value = 550f;
			NPC.knockBackResist = 0.75f;
			NPC.aiStyle = NPCID.GoblinPeon;
			AIType = NPCID.GoblinPeon;
			AnimationType = NPCID.SolarDrakomire;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode) //restrict spawning to Hardmode
				return Main.tile[(int)(spawnInfo.SpawnTileX), (int)(spawnInfo.SpawnTileY)].TileType == TileType<Tiles.CrystalBlock>() ? 13f : 0f;
			return 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				//spawn initial set
				for (int i = 1; i <= 4; i++)
				{
					Gore.NewGore(NPC.position, NPC.velocity, Mod.GetGoreSlot("Gores/Geode_Monster_Gore_" + i));
				}
				//spawn rest of the legs
				for (int i = 0; i < 3; i++)
				{
					Gore.NewGore(NPC.position, NPC.velocity, Mod.GetGoreSlot("Gores/Geode_Monster_Gore_2"));
				}
			}
		}

		public override void OnKill()
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemType<Items.EnchantedGeode>());
			}
		}

		public override void AI()
		{
			Vector3 RGB = new Vector3(0f, 0.75f, 1.5f);
			float multiplier = 1;
			float max = 2.25f;
			float min = 1.0f;
			RGB *= multiplier;
			if (RGB.X > max)
			{
				multiplier = 0.5f;
			}
			if (RGB.X < min)
			{
				multiplier = 1.5f;
			}
			Lighting.AddLight(NPC.position, RGB.X, RGB.Y, RGB.Z);
			if (Main.rand.Next(50) == 0)
			{
				for (int h = 0; h < 10; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y + 20, vel.X, vel.Y, Mod.Find<ModProjectile>("ShatterEnemy" + (1 + Main.rand.Next(0, 3))).Type, 25, 0, Main.myPlayer);
				}
			}
		}
	}
}