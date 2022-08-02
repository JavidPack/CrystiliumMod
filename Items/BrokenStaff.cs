using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class BrokenStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Archmage Staff");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.BrokenHeroSword);
		}
	}
}