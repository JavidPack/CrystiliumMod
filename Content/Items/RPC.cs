using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items
{
	public class RPC : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("RPC");
			// Tooltip.SetDefault("'Rocket Propelled Crystal'");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.ammo = Item.type;
			Item.consumable = true;
		}
	}
}