using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace CrystiliumMod.Items
{
	public class CrystalBag : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Treasure Bag";
			item.width = 20;
			item.maxStack = 30;
			item.height = 20;
			item.toolTip = "Right Click to open";
			item.expert = true;
			item.rare = -2;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			if (Main.rand.Next(10) == 0)
			{
				player.QuickSpawnItem(mod.ItemType<Armor.CrystalMask>());
			}
			player.QuickSpawnItem(mod.ItemType<Accessories.CrystalJewel>());
			player.QuickSpawnItem(mod.ItemType<CrystiliumBar>(), Main.rand.Next(13, 20));

			var ChoiceChooser = new WeightedRandom<int>();
			ChoiceChooser.Add(mod.ItemType<Weapons.Cryst>());
			ChoiceChooser.Add(mod.ItemType<Weapons.Callandor>());
			ChoiceChooser.Add(mod.ItemType<Weapons.QuartzSpear>());
			ChoiceChooser.Add(mod.ItemType<Weapons.ShiningTrigger>());
			ChoiceChooser.Add(mod.ItemType<Weapons.Slamborite>());
			ChoiceChooser.Add(mod.ItemType<Weapons.Shimmer>());
			ChoiceChooser.Add(mod.ItemType<Weapons.Shatterocket>());
			ChoiceChooser.Add(mod.ItemType<Weapons.RoyalShredder>());
			int Choice = ChoiceChooser;
			player.QuickSpawnItem(Choice);
		}
	}
}