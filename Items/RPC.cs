using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class RPC : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("RPC");
			Tooltip.SetDefault("'Rocket Propelled Crystal'");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.ammo = item.type;
			item.consumable = true;
		}
	}
}