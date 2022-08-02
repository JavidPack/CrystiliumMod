using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class StardustCrystal : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("StardustCrystal");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			Projectile.penetrate = 5;
			Projectile.width = 13;
			Projectile.height = 46;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.Center);
			return base.OnTileCollide(oldVelocity);
		}
	}
}