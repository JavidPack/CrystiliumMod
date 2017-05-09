using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class DiamondExplosion : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1000;
			projectile.tileCollide = false;
			projectile.timeLeft = 40;
			projectile.name = "DiamondExplosion";
			Main.projFrames[projectile.type] = 7;
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