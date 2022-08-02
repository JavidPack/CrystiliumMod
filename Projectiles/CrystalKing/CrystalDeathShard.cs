using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles.CrystalKing
{
	public class CrystalDeathShard : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Grenade);
			Projectile.penetrate = 1;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.alpha = 80;
			AIType = ProjectileID.Grenade;
			Projectile.light = 0.5f;
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
	}
}