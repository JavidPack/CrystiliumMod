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
			Item.damage = 25;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 38;
			Item.height = 38;
			Item.scale = 1.1f;
			Item.maxStack = 1;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.knockBack = 4f;
			Item.UseSound = SoundID.Item1;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.useTurn = true;
			Item.useStyle = 5;
			Item.value = 100000;
			Item.rare = 7;
			Item.shoot = ProjectileType<Projectiles.QuartzSpearProj>();  //put your Spear projectile name
			Item.shootSpeed = 5f;
		}
	}
}