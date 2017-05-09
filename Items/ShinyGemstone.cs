using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class ShinyGemstone : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Shining Gemstone";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("Infused with mana");
			item.value = 2500;
			item.rare = 3;
		}
	}
}