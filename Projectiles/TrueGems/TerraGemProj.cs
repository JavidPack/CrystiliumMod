using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles.TrueGems
{
	public class TerraGemProj : ModProjectile
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "CrystiliumMod/Projectiles/TrueGems/TrueGem1";
			return true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(82);
			projectile.hostile = false;
			projectile.magic = true;
			projectile.width = 28;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.name = "True gem";
			projectile.damage = 10;
			projectile.light = 0.5f;
		}

		//Removes the need for separate projectiles by using custom drawing for all variants
		//public override bool PreDraw (SpriteBatch spriteBatch, Color lightColor)
		//{
		//}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			}
			for (int I = 0; I < 3; I++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CrystalDust"), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
			}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
				for (int I = 0; I < 15; I++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CrystalDust"), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}

			string texName = "Projectiles/TrueGems/TrueGem" + projectile.ai[1];
			Texture2D texture = mod.GetTexture(texName);
			spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Rectangle(0, 0, texture.Width, texture.Height), lightColor, projectile.rotation, new Vector2((float)texture.Width / 2, (float)texture.Height / 2), projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}