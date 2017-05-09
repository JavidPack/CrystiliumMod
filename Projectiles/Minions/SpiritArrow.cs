using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.IO;

namespace CrystiliumMod.Projectiles.Minions
{
	public class SpiritArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			projectile.name = "Spirit Arrow";
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