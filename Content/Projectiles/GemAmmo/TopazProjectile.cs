using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles.GemAmmo
{
	public class TopazProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Topaz Bullet");
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
			Projectile.penetrate = 3;
			Projectile.timeLeft = 600;
			Projectile.damage = 8;
			Projectile.alpha = 255;
			Projectile.light = 0.5f;
			Projectile.extraUpdates = 1;
			AIType = ProjectileID.Bullet;
		}
	}
}