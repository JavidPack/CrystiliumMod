using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.NPCs
{
	public class CrystalMimic : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Mimic");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BigMimicHallow];
		}

		public override void SetDefaults()
		{
			npc.width = 17;
			npc.height = 21;
			npc.damage = 49;
			npc.defense = 8;
			npc.lifeMax = 5000;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 20000f;
			npc.knockBackResist = .30f;
			npc.aiStyle = 87;
			aiType = NPCID.Zombie;
			animationType = NPCID.BigMimicHallow;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			//only spawn in hardmode AND after any mech boss
			if (Main.hardMode && NPC.downedMechBossAny)
				return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == TileType<Tiles.CrystalBlock>() ? 3f : 0f;
			return 0f;
		}

		public override void NPCLoot()
		{
			//TODO, this use to reference an item called CrystalCharm, was it suppose to be CrystiliumHelmet? Also, old commented out code had GEM but didn't have PrismaticBoomstick or "CrystalCharm"/CrystiliumHelmet
			int[] lootTable = { ItemType<Items.Accessories.CrystalMonocle>(), ItemType<Items.Weapons.PrismBlade>(), ItemType<Items.Weapons.Gemshot>(),
				ItemType<Items.Weapons.Crystishae>(), ItemType<Items.Weapons.QuartzBlade>(), ItemType<Items.Weapons.DiamondSceptor>(),
				ItemType<Items.Weapons.ManaDrainer>(), ItemType<Items.Armor.CrystiliumHelmet>(), ItemType<Items.Weapons.PrismaticBoomstick>()};
			int loot = lootTable[Main.rand.Next(lootTable.Length)];
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, loot);
		}
	}
}