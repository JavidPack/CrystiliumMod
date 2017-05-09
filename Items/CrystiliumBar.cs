using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class CrystiliumBar : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystilium Bar";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("`Enchanted with the magic of an entire world`");
			item.value = 10000;
			item.rare = 7;
		}
	}
}