using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class ShinyGemstone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shining Gemstone");
			Tooltip.SetDefault("Infused with mana");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 2500;
			item.rare = 3;
		}
	}
}