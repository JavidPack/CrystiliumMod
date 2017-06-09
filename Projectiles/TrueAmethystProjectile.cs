using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class TrueAmethystProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("TrueAmethystProjectile");
		}

		public override void SetDefaults()
		{
			projectile.penetrate = 3;
			projectile.width = 24;
			projectile.height = 26;
			projectile.timeLeft = 30;
			projectile.friendly = true;
			aiType = 7;
			projectile.alpha = 80;
			projectile.light = 0.5f;
		}

		public override void AI()
		{
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("AmethystDust"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
	}
}