using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Accessories
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
			Item.width = 40;
			Item.height = 40;
			Item.value = 30000;
			Item.rare = 3;
			Item.defense = 3;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Magic) += 10;
			player.GetCritChance(DamageClass.Ranged) += 10;
			player.GetDamage(DamageClass.Magic) *= 1.10f;
			player.GetDamage(DamageClass.Ranged) *= 1.10f;
		}
	}
}