using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles.CrystalKing
{
    public class Slasher : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Slasher";
			projectile.tileCollide = false;
            projectile.penetrate = 600;
			projectile.hostile = true;
			projectile.damage = 12;
			projectile.friendly = false;
             projectile.extraUpdates = 1;
            projectile.light = 2;
			projectile.width = 48;
			projectile.height = 48;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;

        }
		public override void AI()
        {
			 projectile.rotation += 0.2f;
		}
    }
}