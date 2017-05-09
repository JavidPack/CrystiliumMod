using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.IO;

namespace CrystiliumMod.Projectiles
{
    public class StardustCrystal : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.name = "StardustCrystal";
			projectile.penetrate = 5;
            projectile.width = 13;
            projectile.height = 46;
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Main.PlaySound(0, projectile.Center);
			return base.OnTileCollide(oldVelocity);
		}
    }
}