using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrystiliumMod.Projectiles.ShatterGems
{
	public class GemstoneFlailProj : ModProjectile
	{
		public override bool Autoload (ref string name, ref string texture)
		{
			texture = "CrystiliumMod/Projectiles/ShatterGems/GemstoneFlail1";
			return true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Grenade);
            projectile.penetrate = 1;
			projectile.alpha = 80;
			aiType = ProjectileID.Grenade;
			projectile.light = 0.5f;
		}

		//Changes draw texture based on AI value, set at creation. Removes disgusting duplicate projectiles.
		public override bool PreDraw (SpriteBatch spriteBatch, Color lightColor)
		{
			string texName = "Projectiles/ShatterGems/GemstoneFlail" + projectile.ai[1];
			Texture2D texture = mod.GetTexture(texName);
			spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Rectangle(0, 0, texture.Width, texture.Height), lightColor, projectile.rotation, new Vector2((float)texture.Width / 2, (float)texture.Height / 2), projectile.scale, SpriteEffects.None, 0f);
			return false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				Main.PlaySound (2, (int)projectile.position.X, (int)projectile.position.Y, 27);
				projectile.Kill ();
			} else {
				projectile.ai [0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
				Main.PlaySound (2, (int)projectile.position.X, (int)projectile.position.Y, 27);
			}
			return false;
		}
	}
}