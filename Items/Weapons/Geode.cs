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
			item.CloneDefaults(ItemID.WoodYoyo);
			item.damage = 22;
			item.value = 30000;
			item.rare = 3;
			item.knockBack = 0;
			item.channel = true;
			item.useStyle = 5;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shoot = ProjectileType<Projectiles.Geode>();
		}
	}
}