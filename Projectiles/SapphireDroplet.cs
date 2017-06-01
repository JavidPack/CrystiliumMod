using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class SapphireDroplet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.penetrate = 1;
			projectile.width = 24;
			projectile.height = 26;
			projectile.friendly = true;
			projectile.alpha = 80;
			projectile.light = 0.5f;
		}

		/*	public override void AI()
			{
				projectile.velocity.Y += projectile.ai[0];
				if (Main.rand.Next(3) == 0)
				{
					Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType<Dusts.Sparkle>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				}
			} */

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			projectile.Kill();
			if (projectile.penetrate <= 0)
			{
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
				projectile.Kill();
				for (int k = 0; k < 6; k++)
				{
					Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 33, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				}
			}
			else
			{
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
			}
			return false;
		}
	}
}