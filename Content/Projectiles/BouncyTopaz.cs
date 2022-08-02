using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class BouncyTopaz : ModProjectile
	{
		public override void SetDefaults()
		{
			//projectile.name = "Bouncy Topaz";
			//projectile.timeLeft = 300;
			//projectile.friendly = true;
			//projectile.light = 0.5f;
			Projectile.CloneDefaults(Terraria.ID.ProjectileID.BallofFire);
			//Main.projFrames[projectile.type] = 3;
		}
	}
}