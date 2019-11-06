using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class Leaf : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 30;
			projectile.damage = 10;
			projectile.timeLeft = 300;
			projectile.friendly = true;
			projectile.light = 0.5f;
			projectile.penetrate = 5;
		}

		public override void AI()
		{
			float rotationSpeed = (float)Math.PI / 15;
			projectile.rotation += rotationSpeed;
			projectile.velocity.X *= 1.03f;
			projectile.velocity.Y *= 1.03f;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 6; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 3, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
		}
	}
}