using Terraria;
using Terraria.ModLoader;

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
			if (Main.rand.Next(10) == 1)
			{
				player.QuickSpawnItem(mod.ItemType<Armor.CrystalMask>()); ;
			}
			int Choice = Main.rand.Next(8);
			int Crystilium = Main.rand.Next(13, 20);
			player.QuickSpawnItem(mod.ItemType<Accessories.CrystalJewel>());
			for (int I = 0; I < Crystilium; I++)
			{
				player.QuickSpawnItem(mod.ItemType<CrystiliumBar>());
			}
			if (Choice == 0)
			{
				player.QuickSpawnItem(mod.ItemType<Weapons.Cryst>());
			}
			if (Choice == 1)
			{
				player.QuickSpawnItem(mod.ItemType<Weapons.Callandor>());
			}
			if (Choice == 2)
			{
				player.QuickSpawnItem(mod.ItemType<Weapons.QuartzSpear>());
			}
			if (Choice == 3)
			{
				player.QuickSpawnItem(mod.ItemType<Weapons.ShiningTrigger>());
			}
			if (Choice == 4)
			{
				player.QuickSpawnItem(mod.ItemType<Weapons.Slamborite>());
			}
			if (Choice == 5)
			{
				player.QuickSpawnItem(mod.ItemType<Weapons.Shimmer>());
			}
			if (Choice == 6)
			{
				player.QuickSpawnItem(mod.ItemType<Weapons.Shatterocket>());
			}
			if (Choice == 7)
			{
				player.QuickSpawnItem(mod.ItemType<Weapons.RoyalShredder>());
			}
		}
	}
}