using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class Geode : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Geode");
			// Tooltip.SetDefault("Very sharp when broken");
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
			Item.shoot = ModContent.ProjectileType<Projectiles.Geode>();
		}
	}
}