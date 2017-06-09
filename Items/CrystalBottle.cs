using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class CrystalBottle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Bottle");
			Tooltip.SetDefault("It seems enchanted");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 2500;
			item.rare = 3;
		}
	}
}