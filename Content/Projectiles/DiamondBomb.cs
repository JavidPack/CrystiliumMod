using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class DiamondBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.aiStyle = 14;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 400;
			Projectile.width = 18;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.alpha = 80;
			Projectile.light = 0.5f;
		}

		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 8)
			{
				Projectile.frameCounter = 0;
				Projectile.frame = (Projectile.frame + 1) % 2;
			}
		}

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
			for (int k = 0; k < 10; k++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 206, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
			}
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<DiamondExplosion>(), Projectile.damage, 0, Main.myPlayer);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.Kill();
		}
	}
}