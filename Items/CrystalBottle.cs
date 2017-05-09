using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class CrystalBottle : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystal Bottle";
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			AddTooltip("It seems enchanted");
			item.value = 2500;
			item.rare = 3;
		}
	}
}