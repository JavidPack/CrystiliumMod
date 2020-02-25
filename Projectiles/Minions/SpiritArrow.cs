using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles.Minions
{
	public class SpiritArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.MinionShot[projectile.type] = true;
		}
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			projectile.ranged = false;
			projectile.minion = true;
			projectile.width = 10;
			projectile.penetrate = 5;
			projectile.height = 20;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Main.PlaySound(0, projectile.Center);
			return base.OnTileCollide(oldVelocity);
		}
	}
}