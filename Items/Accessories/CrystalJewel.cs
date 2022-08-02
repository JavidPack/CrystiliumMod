using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Accessories
{
	public class CrystalJewel : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Jewel");
			Tooltip.SetDefault("Creates dangerous shards when hit");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.expert = true;
			Item.value = 100000;
			Item.rare = 3;
			Item.defense = 3;
			Item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<CrystalPlayer>().CrystalAcc = true;
		}
	}
}