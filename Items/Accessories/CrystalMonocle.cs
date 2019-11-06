using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Accessories
{
	public class CrystalMonocle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Monocle");
			Tooltip.SetDefault("+10% Magic and ranged damage and Crit chance"
				+"\n+10% Magic and ranged critical strike chance"
				+"\nColorful distortion");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = 30000;
			item.rare = 3;
			item.defense = 3;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicCrit += 10;
			player.rangedCrit += 10;
			player.magicDamage *= 1.10f;
			player.rangedDamage *= 1.10f;
		}
	}
}