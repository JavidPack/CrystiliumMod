using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Accessories
{
	public class DiamondRing : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.DiamondRing)
			{
				item.toolTip = "5% increased critical strike chance";
				item.value = Item.sellPrice(0, 0, 85, 0); //item is now worth less because craftable
				item.vanity = false; //allows use of modifiers
				item.rare = 1;
			}
		}

		public override void UpdateAccessory(Item item, Player player, bool hideVisual)
		{
			if (item.type == ItemID.DiamondRing)
			{
				player.magicCrit += 5;
				player.meleeCrit += 5;
				player.thrownCrit += 5;
				player.rangedCrit += 5;
			}
		}
	}
}