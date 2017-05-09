using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
    public class gProj : GlobalProjectile
    {
        public override void AI(Projectile projectile)
        {//todo - forking lightning in Kill(), kill projectile when far from player in AI(), homing in OnHitNPC()
            if (projectile.aiStyle == 88 && projectile.knockBack == .5f || (projectile.knockBack >= .2f && projectile.knockBack < .5f))
            {
                projectile.hostile = false;
                projectile.friendly = true;
                projectile.magic = true;
				projectile.penetrate = 1000;
                if((projectile.knockBack >= .45f && projectile.knockBack < .5f) && projectile.oldVelocity != projectile.velocity && Main.rand.Next(0, 4)==0)
                {
                    projectile.knockBack -= .0125f;
                    Vector2 vector83 = projectile.velocity.RotatedByRandom(.1f);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector83.X, vector83.Y, projectile.type, projectile.damage, projectile.knockBack-.025f, projectile.owner, projectile.velocity.ToRotation(), projectile.ai[1]);
                }
            }
        }
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.aiStyle == 88 && (projectile.knockBack >= .2f && projectile.knockBack <= .5f))
            {
                target.immune[projectile.owner] = 6;
            }
        }
        public override bool? CanHitNPC(Projectile projectile, NPC target)
        {
            if (projectile.aiStyle == 88 && ((projectile.knockBack == .5f || projectile.knockBack == .4f) || (projectile.knockBack >= .4f && projectile.knockBack < .5f)) && target.immune[projectile.owner] > 0)
            {
                return false;
            }
            return null;
        }
    }
}
