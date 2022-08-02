using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles.CrystalKing
{
	public class CultistFire : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cultist Fire");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.penetrate = 600;
			Projectile.hostile = true;
			Projectile.damage = 13;
			Projectile.friendly = false;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 120;
			Projectile.light = 2;
		}

		public override void AI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation() + 1.57f;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 8)
			{
				Projectile.frameCounter = 0;
				Projectile.frame = (Projectile.frame + 1) % 4;
			}
		}
	}
}