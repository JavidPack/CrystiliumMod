using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles.Minions
{
	public class SpiritArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.MinionShot[Projectile.type] = true;
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			Projectile.ranged = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
			Projectile.minion = true;
			Projectile.width = 10;
			Projectile.penetrate = 5;
			Projectile.height = 20;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.Center);
			return base.OnTileCollide(oldVelocity);
		}
	}
}