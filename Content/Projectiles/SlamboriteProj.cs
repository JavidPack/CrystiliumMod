using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class SlamboriteProj : ModProjectile
	{
		private int Gemstone;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slamborite");
		}

		public override void SetDefaults()
		{
			Projectile.width = 28;
			Projectile.height = 28;
			Projectile.friendly = true;
			Projectile.penetrate = -1; // Penetrates NPCs infinitely.
			Projectile.DamageType = DamageClass.Melee; // Deals melee dmg.

			Projectile.aiStyle = 15; // Set the aiStyle to that of a flail.
		}

		// Now this is where the chain magic happens. You don't have to try to figure this whole thing out.
		// Just make sure that you edit the first line (which starts with 'Texture2D texture') correctly.
		public override bool PreDraw(ref Color lightColor)
		{
			// So set the correct path here to load the chain texture. 'YourModName' is of course the name of your mod.
			// Then into the Projectiles folder and take the texture that is called 'CustomFlailBall_Chain'.
			Texture2D texture = ModContent.GetTexture("CrystiliumMod/Projectiles/SlamboriteChain");

			Vector2 position = Projectile.Center;
			Vector2 mountedCenter = Main.player[Projectile.owner].MountedCenter;
			Rectangle? sourceRectangle = new();
			Vector2 origin = new((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
			float num1 = (float)texture.Height;
			Vector2 vector2_4 = mountedCenter - position;
			float rotation = (float)Math.Atan2((double)vector2_4.Y, (double)vector2_4.X) - 1.57f;
			bool flag = true;
			if (float.IsNaN(position.X) && float.IsNaN(position.Y))
				flag = false;
			if (float.IsNaN(vector2_4.X) && float.IsNaN(vector2_4.Y))
				flag = false;
			while (flag)
			{
				if ((double)vector2_4.Length() < (double)num1 + 1.0)
				{
					flag = false;
				}
				else
				{
					Vector2 vector2_1 = vector2_4;
					vector2_1.Normalize();
					position += vector2_1 * num1;
					vector2_4 = mountedCenter - position;
					Color color2 = Lighting.GetColor((int)position.X / 16, (int)((double)position.Y / 16.0));
					color2 = Projectile.GetAlpha(color2);
					Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1.35f, SpriteEffects.None, 0.0f);
				}
			}

			return true;
		}

		public override void AI()
		{
			Gemstone++;
			if (Gemstone % 9 == 7)
			{
				Vector2 vel = new(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y + 20, vel.X, vel.Y, ModContent.ProjectileType<ShatterGems.GemstoneFlailProj>(), Projectile.damage - (Projectile.damage / 3), 0, Projectile.owner, 0, Main.rand.Next(1, 8));
			}
		}
	}
}