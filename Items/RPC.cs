using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class RPC : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "RPC";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("'Rocket Propelled Crystal'");
			item.ammo = item.type;
			item.consumable = true;
		}
	}
}