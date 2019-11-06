using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.NPCs
{
	public class CrystalZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Zombie");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
		}

		public override void SetDefaults()
		{
			npc.width = 18;
			npc.height = 40;
			npc.damage = 21;
			npc.defense = 12;
			npc.lifeMax = 120;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 300f;
			npc.knockBackResist = 0.75f;
			npc.aiStyle = 3;
			aiType = NPCID.Skeleton;
			animationType = NPCID.Zombie;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == TileType<Tiles.CrystalBlock>() ? 8f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				//spawn initial set
				for (int i = 1; i <= 3; i++)
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Zombie_Gore_" + i));
				}
				//spawn a couple extra bits
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Zombie_Gore_1"));
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Zombie_Gore_1"));
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.ShinyGemstone>());
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
			Lighting.AddLight(npc.position, RGB.X, RGB.Y, RGB.Z);
			if (Main.rand.Next(150) == 0)
			{
				for (int h = 0; h < 3; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("ShatterEnemy" + (1 + Main.rand.Next(0, 3))), 18, 0, Main.myPlayer);
				}
			}
		}
	}
}