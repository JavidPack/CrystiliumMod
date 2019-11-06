using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class FireGem : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Gem");
			Main.projFrames[projectile.type] = 3;
		}

		public override void SetDefaults()
		{
			projectile.timeLeft = 300;
			projectile.friendly = true;
			projectile.light = 0.5f;
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 2;
			}
			if (projectile.timeLeft % 60 == 0)
			{
				int n = Main.rand.Next(3, 6);
				int deviation = Main.rand.Next(0, 60);
				for (int i = 0; i < n; i++)
				{
					float rotation = MathHelper.ToRadians(360 / n * i + deviation);
					Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(rotation);
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, Terraria.ID.ProjectileID.RubyBolt, projectile.damage, projectile.knockBack, projectile.owner);
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
			for (int k = 0; k < 10; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("TrueRubyDust"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
	}
}