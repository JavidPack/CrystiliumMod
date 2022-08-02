using System;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class Leaf : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 30;
			Projectile.damage = 10;
			Projectile.timeLeft = 300;
			Projectile.friendly = true;
			Projectile.light = 0.5f;
			Projectile.penetrate = 5;
		}

		public override void AI()
		{
			float rotationSpeed = (float)Math.PI / 15;
			Projectile.rotation += rotationSpeed;
			Projectile.velocity.X *= 1.03f;
			Projectile.velocity.Y *= 1.03f;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 6; k++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 3, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
			}
		}
	}
}