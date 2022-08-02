using CrystiliumMod.Content.Items;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod
{
	public class CrystiliumGlobalNPC : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			base.ModifyNPCLoot(npc, npcLoot);

			switch (npc.type) {
				case NPCID.Mothron:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenStaff>(), 4));
					break;
			}
		}
	}
}