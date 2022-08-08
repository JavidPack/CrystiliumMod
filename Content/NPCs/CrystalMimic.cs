using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;

namespace CrystiliumMod.Content.NPCs
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

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				CrystiliumMod.SpawnCondition,
				new FlavorTextBestiaryInfoElement("MystalCrimic"),
			});
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			//only spawn in hardmode AND after any mech boss
			if (Main.hardMode && NPC.downedMechBossAny)
				return Main.tile[(int)(spawnInfo.SpawnTileX), (int)(spawnInfo.SpawnTileY)].TileType == ModContent.TileType<Tiles.CrystalBlock>() ? 3f : 0f;
			return 0f;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
			int[] lootTable = {
				ModContent.ItemType<Items.Accessories.CrystalMonocle>(),
				ModContent.ItemType<Items.Weapons.PrismBlade>(),
				ModContent.ItemType<Items.Weapons.Gemshot>(),
				ModContent.ItemType<Items.Weapons.Crystishae>(),
				ModContent.ItemType<Items.Weapons.QuartzBlade>(),
				ModContent.ItemType<Items.Weapons.DiamondSceptor>(),
				ModContent.ItemType<Items.Weapons.ManaDrainer>(),
				ModContent.ItemType<Items.Armor.CrystiliumHelmet>(),
				ModContent.ItemType<Items.Weapons.PrismaticBoomstick>()};
			npcLoot.Add(ItemDropRule.OneFromOptions(1, lootTable)); 
		}
    }
}