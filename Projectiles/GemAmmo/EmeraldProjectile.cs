using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles.GemAmmo
{
	public class EmeraldProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Emerald Bullet");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 12;
			Projectile.height = 12;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 7;
			Projectile.timeLeft = 600;
			Projectile.damage = 6;
			Projectile.alpha = 255;
			Projectile.light = 0.5f;
			Projectile.extraUpdates = 1;
			AIType = ProjectileID.Bullet;
		}
	}
}