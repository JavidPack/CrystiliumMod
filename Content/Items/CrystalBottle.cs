using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items
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
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 99;
			Item.value = 2500;
			Item.rare = 3;
		}
	}
}