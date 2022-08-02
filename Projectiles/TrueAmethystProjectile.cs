using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			Projectile.penetrate = 3;
			Projectile.width = 24;
			Projectile.height = 26;
			Projectile.timeLeft = 30;
			Projectile.friendly = true;
			AIType = 7;
			Projectile.alpha = 80;
			Projectile.light = 0.5f;
		}

		public override void AI()
		{
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, Mod.Find<ModDust>("AmethystDust").Type, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
			}
		}
	}
}