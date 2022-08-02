using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 2500;
			Item.rare = 3;
		}
	}
}