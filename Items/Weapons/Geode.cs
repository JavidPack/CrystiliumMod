using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Geode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Geode");
			Tooltip.SetDefault("Very sharp when broken");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.WoodYoyo);
			Item.damage = 22;
			Item.value = 30000;
			Item.rare = 3;
			Item.knockBack = 0;
			Item.channel = true;
			Item.useStyle = 5;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shoot = ProjectileType<Projectiles.Geode>();
		}
	}
}