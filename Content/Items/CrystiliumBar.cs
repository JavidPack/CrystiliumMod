using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items
{
	public class CrystiliumBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystilium Bar");
			// Tooltip.SetDefault("`Enchanted with the magic of an entire world`");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 10000;
			Item.rare = 7;
		}
	}
}