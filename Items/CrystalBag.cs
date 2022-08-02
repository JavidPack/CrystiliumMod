using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;

namespace CrystiliumMod.Items
{
	public class CrystalBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Right Click to open");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.maxStack = 30;
			Item.height = 20;
			Item.expert = true;
			Item.rare = -2;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			if (Main.rand.Next(10) == 0)
			{
				player.QuickSpawnItem(ItemType<Armor.CrystalMask>());
			}
			player.QuickSpawnItem(ItemType<Accessories.CrystalJewel>());
			player.QuickSpawnItem(ItemType<CrystiliumBar>(), Main.rand.Next(13, 20));

			var ChoiceChooser = new WeightedRandom<int>();
			ChoiceChooser.Add(ItemType<Weapons.Cryst>());
			ChoiceChooser.Add(ItemType<Weapons.Callandor>());
			ChoiceChooser.Add(ItemType<Weapons.QuartzSpear>());
			ChoiceChooser.Add(ItemType<Weapons.ShiningTrigger>());
			ChoiceChooser.Add(ItemType<Weapons.Slamborite>());
			ChoiceChooser.Add(ItemType<Weapons.Shimmer>());
			ChoiceChooser.Add(ItemType<Weapons.Shatterocket>());
			ChoiceChooser.Add(ItemType<Weapons.RoyalShredder>());
			int Choice = ChoiceChooser;
			player.QuickSpawnItem(Choice);
		}
	}
}