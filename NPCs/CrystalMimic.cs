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
			string[] lootTable = { "CrystalMonocle", "PrismBlade", "Gemshot", "Crystishae", "QuartzBlade",
								   "DiamondSceptor", "ManaDrainer", "CrystalCharm", "PrismaticBoomstick"};
			int loot = Main.rand.Next(lootTable.Length);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
			/*if (NPCloot == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Items.CrystalMonocle>());
			}

			if (NPCloot == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Items.PrismBlade>());
			}
			if (NPCloot == 2)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Gemshot>());
			}
			if (NPCloot == 3)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Items.GEM>());
			}
			if (NPCloot == 4)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Crystishae>());
			}
			if (NPCloot == 5)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Items.QuartzBlade>());
			}
            if (NPCloot == 6)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Items.DiamonSceptor>());
            }
            if (NPCloot == 7)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Items.ManaDrainer>());
            }*/
		}
	}
}