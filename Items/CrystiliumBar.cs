using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class CrystiliumBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystilium Bar");
			Tooltip.SetDefault("`Enchanted with the magic of an entire world`");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 10000;
			item.rare = 7;
		}
	}
}