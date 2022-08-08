using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace CrystiliumMod.Content.Items
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
				player.QuickSpawnItem(Item.GetSource_Loot(),ModContent.ItemType<Armor.CrystalMask>());
			}
			player.QuickSpawnItem(Item.GetSource_Loot(), ModContent.ItemType<Accessories.CrystalJewel>());
			player.QuickSpawnItem(Item.GetSource_Loot(), ModContent.ItemType<CrystiliumBar>(), Main.rand.Next(13, 20));

			var ChoiceChooser = new WeightedRandom<int>();
			ChoiceChooser.Add(ModContent.ItemType<Weapons.Cryst>());
			ChoiceChooser.Add(ModContent.ItemType<Weapons.Callandor>());
			ChoiceChooser.Add(ModContent.ItemType<Weapons.QuartzSpear>());
			ChoiceChooser.Add(ModContent.ItemType<Weapons.ShiningTrigger>());
			ChoiceChooser.Add(ModContent.ItemType<Weapons.Slamborite>());
			ChoiceChooser.Add(ModContent.ItemType<Weapons.Shimmer>());
			ChoiceChooser.Add(ModContent.ItemType<Weapons.Shatterocket>());
			ChoiceChooser.Add(ModContent.ItemType<Weapons.RoyalShredder>());
			int Choice = ChoiceChooser;
			player.QuickSpawnItem(Item.GetSource_Loot(), Choice);
		}
	}
}