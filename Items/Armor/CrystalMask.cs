using System.Collections.Generic;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
	public class CrystalMask : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Crystal King Mask";
			item.width = 18;
			item.height = 18;
			item.toolTip = "Vanity item";
			item.value = 150000;
			item.rare = 8;
		}
	}
}