using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class QuartzSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Spear");
			Tooltip.SetDefault("'Object class - Keter'");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.scale = 1.1f;
			item.maxStack = 1;
			item.useTime = 30;
			item.useAnimation = 30;
			item.knockBack = 4f;
			item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
			item.value = 100000;
			item.rare = 7;
			item.shoot = ProjectileType<Projectiles.QuartzSpearProj>();  //put your Spear projectile name
			item.shootSpeed = 5f;
		}
	}
}