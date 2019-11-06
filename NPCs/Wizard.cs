using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.NPCs
{
	public class Wizard : GlobalNPC
	{
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Wizard)
			{
				shop.item[nextSlot].SetDefaults(ItemType<Items.CrystalBottle>());
				nextSlot++;
			}
		}
	}
}