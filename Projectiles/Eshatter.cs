using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class Eshatter : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.penetrate = 1;
			projectile.width = 8;
			projectile.height = 8;
			projectile.alpha = 80;
			projectile.light = 0.5f;
			projectile.timeLeft = 300;
			projectile.tileCollide = false;
		}
	}
}