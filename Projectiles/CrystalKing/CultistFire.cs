using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles.CrystalKing
{
    public class CultistFire : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Cultist Fire";
            projectile.penetrate = 600;
			projectile.hostile = true;
			projectile.damage = 13;
			projectile.friendly = false;
			projectile.tileCollide = false;
			projectile.timeLeft = 120;
            projectile.light = 2;
			Main.projFrames[projectile.type] = 4;			

        }
		public override void AI()
        {
			 projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
			projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 4;
            } 
		}
    }
}