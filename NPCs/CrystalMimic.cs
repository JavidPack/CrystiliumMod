using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.NPCs
{
	public class CrystalMimic : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Crystal Mimic";
			npc.displayName = "Crystal Mimic";
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
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[475];
			aiType = NPCID.Zombie;
			animationType = 475;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			//only spawn in hardmode AND after any mech boss
			if (Main.hardMode && NPC.downedMechBossAny)
				return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == mod.TileType<Tiles.CrystalBlock>() ? 3f : 0f;
			return 0f;
		}

		public override void NPCLoot()
		{
			//TODO, this use to reference an item called CrystalCharm, was it suppose to be CrystiliumHelmet? Also, old commented out code had GEM but didn't have PrismaticBoomstick or "CrystalCharm"/CrystiliumHelmet
			int[] lootTable = { mod.ItemType<Items.Accessories.CrystalMonocle>(), mod.ItemType<Items.Weapons.PrismBlade>(), mod.ItemType<Items.Weapons.Gemshot>(),
				mod.ItemType<Items.Weapons.Crystishae>(), mod.ItemType<Items.Weapons.QuartzBlade>(), mod.ItemType<Items.Weapons.DiamondSceptor>(),
				mod.ItemType<Items.Weapons.ManaDrainer>(), mod.ItemType<Items.Armor.CrystiliumHelmet>(), mod.ItemType<Items.Weapons.PrismaticBoomstick>()};
			int loot = lootTable[Main.rand.Next(lootTable.Length)];
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, loot);
		}
	}
}