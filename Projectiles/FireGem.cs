using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class FireGem : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Gem");
			Main.projFrames[Projectile.type] = 3;
		}

		public override void SetDefaults()
		{
			Projectile.timeLeft = 300;
			Projectile.friendly = true;
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
			if (Projectile.timeLeft % 60 == 0)
			{
				int n = Main.rand.Next(3, 6);
				int deviation = Main.rand.Next(0, 60);
				for (int i = 0; i < n; i++)
				{
					float rotation = MathHelper.ToRadians(360 / n * i + deviation);
					Vector2 perturbedSpeed = new Vector2(Projectile.velocity.X, Projectile.velocity.Y).RotatedBy(rotation);
					Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, Terraria.ID.ProjectileID.RubyBolt, Projectile.damage, Projectile.knockBack, Projectile.owner);
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			for (int k = 0; k < 10; k++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, Mod.Find<ModDust>("TrueRubyDust").Type, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
			}
		}
	}
}