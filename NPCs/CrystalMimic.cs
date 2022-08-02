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
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.BigMimicHallow];
		}

		public override void SetDefaults()
		{
			NPC.width = 17;
			NPC.height = 21;
			NPC.damage = 49;
			NPC.defense = 8;
			NPC.lifeMax = 5000;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 20000f;
			NPC.knockBackResist = .30f;
			NPC.aiStyle = 87;
			AIType = NPCID.Zombie;
			AnimationType = NPCID.BigMimicHallow;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			//only spawn in hardmode AND after any mech boss
			if (Main.hardMode && NPC.downedMechBossAny)
				return Main.tile[(int)(spawnInfo.SpawnTileX), (int)(spawnInfo.SpawnTileY)].TileType == TileType<Tiles.CrystalBlock>() ? 3f : 0f;
			return 0f;
		}

		public override void OnKill()
		{
			//TODO, this use to reference an item called CrystalCharm, was it suppose to be CrystiliumHelmet? Also, old commented out code had GEM but didn't have PrismaticBoomstick or "CrystalCharm"/CrystiliumHelmet
			int[] lootTable = { ItemType<Items.Accessories.CrystalMonocle>(), ItemType<Items.Weapons.PrismBlade>(), ItemType<Items.Weapons.Gemshot>(),
				ItemType<Items.Weapons.Crystishae>(), ItemType<Items.Weapons.QuartzBlade>(), ItemType<Items.Weapons.DiamondSceptor>(),
				ItemType<Items.Weapons.ManaDrainer>(), ItemType<Items.Armor.CrystiliumHelmet>(), ItemType<Items.Weapons.PrismaticBoomstick>()};
			int loot = lootTable[Main.rand.Next(lootTable.Length)];
			Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, loot);
		}
	}
}