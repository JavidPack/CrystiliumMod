using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;

namespace CrystiliumMod.Content.NPCs
{
	public class CrystalSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal Slime");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.width = 30;
			NPC.height = 50;
			NPC.damage = 24;
			NPC.defense = 9;
			NPC.lifeMax = 130;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 200f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 1;
			AIType = 1;
			AnimationType = NPCID.BlueSlime;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				CrystiliumMod.SpawnCondition,
				new FlavorTextBestiaryInfoElement("Mods.CrystiliumMod.Bestiary.CrystalSlime"),
				// new FlavorTextBestiaryInfoElement("Each time a slime lands on enchanted crystal, a small amount sticks to the surface. These slimes will release these jagged shards to cut prey down to size."),
			});
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Main.tile[(int)(spawnInfo.SpawnTileX), (int)(spawnInfo.SpawnTileY)].TileType == ModContent.TileType<Tiles.CrystalBlock>() ? 10f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				//spawn gore set
				for (int i = 1; i <= 4; i++)
				{
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Crystal_Slime_Gore_" + i).Type);
				}
			}
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.ShinyGemstone>(), 2));
		}

		public override void AI()
		{
			Vector3 RGB = new(2.0f, 0.75f, 1.5f);
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
		}
	}
}