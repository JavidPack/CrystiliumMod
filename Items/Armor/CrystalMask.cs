using System.Collections.Generic;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			Item.width = 18;
			Item.height = 18;
			Item.value = 150000;
			Item.rare = 8;
		}
	}
}