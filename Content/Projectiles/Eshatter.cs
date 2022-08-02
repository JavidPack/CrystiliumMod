using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class Eshatter : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.penetrate = 1;
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.alpha = 80;
			Projectile.light = 0.5f;
			Projectile.timeLeft = 300;
			Projectile.tileCollide = false;
		}
	}
}