using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class SapphireDroplet : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.penetrate = 1;
			Projectile.width = 24;
			Projectile.height = 26;
			Projectile.friendly = true;
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

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.Kill();
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			Projectile.Kill();
			if (Projectile.penetrate <= 0)
			{
				SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
				Projectile.Kill();
				for (int k = 0; k < 6; k++)
				{
					Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 33, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
				}
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
	}
}