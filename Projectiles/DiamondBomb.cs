using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class DiamondBomb : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.aiStyle = 14;
			projectile.penetrate = 1;
			projectile.timeLeft = 400;
			projectile.width = 18;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.alpha = 80;
			projectile.light = 0.5f;
			Main.projFrames[projectile.type] = 4;
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 2;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
				projectile.Kill();
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

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 10; k++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 206, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType<DiamondExplosion>(), projectile.damage, 0, Main.myPlayer);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
		}
	}
}