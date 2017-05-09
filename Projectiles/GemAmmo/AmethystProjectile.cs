using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles.GemAmmo
{
	public class AmethystProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Amethyst Bullet";
			projectile.width = 12;
			projectile.height = 12;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 600;
			projectile.damage = 10;
			projectile.alpha = 255;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			aiType = ProjectileID.Bullet;
		}
	}
}