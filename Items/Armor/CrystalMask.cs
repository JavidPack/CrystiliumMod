using System.Collections.Generic;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CrystalMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal King Mask");
			Tooltip.SetDefault("Vanity item");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 150000;
			item.rare = 8;
		}
	}
}