using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class GiantDiamond : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Grenade);
			Projectile.penetrate = 1;
			Projectile.width = 24;
			Projectile.height = 26;
			Projectile.timeLeft = 25;
			Projectile.friendly = true;
			AIType = ProjectileID.Grenade;
			Projectile.alpha = 80;
			Projectile.light = 0.5f;
		}

		/*	public override void AI()
			{
				projectile.velocity.Y += projectile.ai[0];
				if (Main.rand.Next(3) == 0)
				{
					Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Dusts.Sparkle>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				}
			} */

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
				Projectile.Kill();
			}
			else
			{
				Projectile.ai[0] += 0.1f;
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
				SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustType<Dusts.Sparkle>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
			}
			for (int h = 0; h < 4; h++)
			{
				Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), ProjectileType<DiamondBomb>(), Projectile.damage, 0, Projectile.owner);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.ai[0] += 0.1f;
			Projectile.velocity *= 0.75f;
		}
	}
}