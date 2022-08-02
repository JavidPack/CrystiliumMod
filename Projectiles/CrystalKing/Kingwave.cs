using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles.CrystalKing
{
	public class Kingwave : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.penetrate = 600;
			Projectile.hostile = true;
			Projectile.damage = 15;
			Projectile.width = 80;
			Projectile.height = 48;
			Projectile.friendly = false;
			Projectile.light = 2;
			Projectile.aiStyle = 1;
			AIType = ProjectileID.Bullet;
		}
	}
}