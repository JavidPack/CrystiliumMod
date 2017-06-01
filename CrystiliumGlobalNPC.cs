using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod
{
	public class CrystiliumGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (npc.type == NPCID.Mothron && Main.rand.Next(4) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Items.BrokenStaff>());
			}
		}
	}
}