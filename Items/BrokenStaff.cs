using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class BrokenStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.BrokenHeroSword);
			item.name = "Broken Archmage Staff";
		}
	}
}