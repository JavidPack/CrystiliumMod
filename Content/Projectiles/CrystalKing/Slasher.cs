using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles.CrystalKing
{
	public class Slasher : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 9;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.tileCollide = false;
			Projectile.penetrate = 600;
			Projectile.hostile = true;
			Projectile.damage = 12;
			Projectile.friendly = false;
			Projectile.extraUpdates = 1;
			Projectile.light = 2;
			Projectile.width = 48;
			Projectile.height = 48;
		}

		public override void AI()
		{
			Projectile.rotation += 0.2f;
		}
	}
}