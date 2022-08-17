using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;

namespace CrystiliumMod.Content.NPCs
{
	public class CrystalZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal Zombie");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
		}

		public override void SetDefaults()
		{
			NPC.width = 18;
			NPC.height = 40;
			NPC.damage = 21;
			NPC.defense = 12;
			NPC.lifeMax = 120;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 300f;
			NPC.knockBackResist = 0.75f;
			NPC.aiStyle = 3;
			AIType = NPCID.Skeleton;
			AnimationType = NPCID.Zombie;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				CrystiliumMod.SpawnCondition,
				new FlavorTextBestiaryInfoElement("Mods.CrystiliumMod.Bestiary.CrystalZombie"),
				// new FlavorTextBestiaryInfoElement("An ordinary undead overtaken by crystals. Slivers of sharp crystal constantly split off from its body, infecting new hosts."),
			});
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Main.tile[(int)(spawnInfo.SpawnTileX), (int)(spawnInfo.SpawnTileY)].TileType == ModContent.TileType<Tiles.CrystalBlock>() ? 8f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				//spawn initial set
				for (int i = 1; i <= 3; i++)
				{
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Crystal_Zombie_Gore_" + i).Type);
				}
				//spawn a couple extra bits
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Crystal_Zombie_Gore_1").Type);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Crystal_Zombie_Gore_1").Type);
			}
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.ShinyGemstone>(), 2));
		}

		public override void AI()
		{
			Vector3 RGB = new(0f, 0.75f, 1.5f);
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
			if (Main.rand.Next(150) == 0)
			{
				for (int h = 0; h < 3; h++)
				{
					Vector2 vel = new(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y + 20, vel.X, vel.Y, Mod.Find<ModProjectile>("ShatterEnemy" + (1 + Main.rand.Next(0, 3))).Type, 18, 0, Main.myPlayer);
				}
			}
		}
	}
}