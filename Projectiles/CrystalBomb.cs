using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class CrystalBomb : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Grenade);
			projectile.penetrate = 1;
			projectile.width = 24;
			projectile.height = 26;
			projectile.friendly = true;
			aiType = ProjectileID.Grenade;
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
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
			for (int k = 0; k < 15; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType<Dusts.Sparkle>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			for (int h = 0; h < 20; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("Shatter" + (1 + Main.rand.Next(0, 3))), projectile.damage - 8, 0, projectile.owner);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}