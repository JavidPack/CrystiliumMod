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
			item.width = 40;
			item.height = 40;
			item.expert = true;
			item.value = 100000;
			item.rare = 3;
			item.defense = 3;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<CrystalPlayer>().CrystalAcc = true;
		}
	}
}