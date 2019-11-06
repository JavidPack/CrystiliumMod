using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class DiamondExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diamond Explosion");
			Main.projFrames[projectile.type] = 7;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1000;
			projectile.tileCollide = false;
			projectile.timeLeft = 40;
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1);
			}
		}
	}
}