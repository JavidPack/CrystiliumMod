using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items
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