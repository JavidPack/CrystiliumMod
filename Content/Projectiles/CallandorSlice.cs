using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class CallandorSlice : ModProjectile
	{
		private float DistX;
		private float DistY;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("CallandorSlice");
			Main.projFrames[ModContent.ProjectileType<CallandorSlice>()] = 28;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Arkhalis);
			Projectile.width = 50;
			Projectile.height = 46;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = -1;
			Projectile.aiStyle = 75;
			AIType = 595;
		}

		public override void AI()
		{
			if (Main.myPlayer == Projectile.owner)
			{
				//Do net updatey thing. Syncs this projectile.
				if (Main.rand.Next(3) == 0)
				{
					int num30 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 2f);
					Main.dust[num30].noGravity = true;
					Main.dust[num30].position -= Projectile.velocity;
				}
				Projectile.netUpdate = true;
				Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
				if (Main.player[Projectile.owner].Center.Y < mouse.Y)
				{
					float Xdis = Main.LocalPlayer.Center.X - mouse.X;  // change myplayer to nearest player in full version
					float Ydis = Main.LocalPlayer.Center.Y - mouse.Y; // change myplayer to nearest player in full version
					float Angle = (float)Math.Atan(Xdis / Ydis);
					float DistXT = (float)(Math.Sin(Angle) * 29);
					float DistYT = (float)(Math.Cos(Angle) * 29);
					Projectile.position.X = (Main.player[Projectile.owner].Center.X + DistXT) - 30;
					Projectile.position.Y = (Main.player[Projectile.owner].Center.Y + DistYT) - 30;
				}
				if (Main.player[Projectile.owner].Center.Y >= mouse.Y)
				{
					float Xdis = Main.LocalPlayer.Center.X - mouse.X;  // change myplayer to nearest player in full version
					float Ydis = Main.LocalPlayer.Center.Y - mouse.Y; // change myplayer to nearest player in full version
					float Angle = (float)Math.Atan(Xdis / Ydis);
					float DistXT = (float)(Math.Sin(Angle) * 29);
					float DistYT = (float)(Math.Cos(Angle) * 29);
					Projectile.position.X = (Main.player[Projectile.owner].Center.X + (0 - DistXT)) - 30;
					Projectile.position.Y = (Main.player[Projectile.owner].Center.Y + (0 - DistYT)) - 30;
				}
			}
		}

		//public override void AI()
		//{
		//	 Player player = Main.player[projectile.owner];
		//	 float num = 1.57079637f;
		//	 Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
		//	 if (projectile.type == ProjectileType<CallandorSlice>())
		//	 {
		//		  num = 0f;
		//		  if (projectile.spriteDirection == -1)
		//		  {
		//				num = 3.14159274f;
		//		  }
		//		  if (++projectile.frame >= Main.projFrames[projectile.type])
		//		  {
		//				projectile.frame = 0;
		//		  }
		//		  projectile.soundDelay--;
		//		  if (projectile.soundDelay <= 0)
		//		  {
		//				Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 1);
		//				projectile.soundDelay = 12;
		//		  }
		//		  if (Main.myPlayer == projectile.owner)
		//		  {
		//				if (player.channel && !player.noItems && !player.CCed)
		//				{
		//					 float scaleFactor6 = 1f;
		//					 if (player.inventory[player.selectedItem].shoot == projectile.type)
		//					 {
		//						  scaleFactor6 = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
		//					 }
		//					 Vector2 vector13 = Main.MouseWorld - vector;
		//					 vector13.Normalize();
		//					 if (vector13.HasNaNs())
		//					 {
		//						  vector13 = Vector2.UnitX * (float)player.direction;
		//					 }
		//					 vector13 *= scaleFactor6;
		//					 if (vector13.X != projectile.velocity.X || vector13.Y != projectile.velocity.Y)
		//					 {
		//						  projectile.netUpdate = true;
		//					 }
		//					 projectile.velocity = vector13;
		//				}
		//				else
		//				{
		//					 projectile.Kill();
		//				}
		//		  }
		//		  Vector2 vector14 = projectile.Center + projectile.velocity;// * 2f;
		//		  Lighting.AddLight(vector14, 0.8f, 0.8f, 0.8f);
		//		  //					 if (Main.rand.Next(3) == 0)
		//		  //					 {
		//		  //						  int num30 = Dust.NewDust(vector14 - projectile.Size / 2f, projectile.width, projectile.height, 63, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 2f);
		//		  //						  Main.dust[num30].noGravity = true;
		//		  //						  Main.dust[num30].position -= projectile.velocity;
		//		  //					 }
		//	 }
		//	 projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f;
		//	 projectile.rotation = projectile.velocity.ToRotation() + num;
		//	 projectile.spriteDirection = projectile.direction;
		//	 projectile.timeLeft = 2;
		//	 player.ChangeDir(projectile.direction);
		//	 player.heldProj = projectile.whoAmI;
		//	 player.itemTime = 2;
		//	 player.itemAnimation = 2;
		//	 player.itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
		//}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			projHitbox.X -= projHitbox.Width / 2;
			projHitbox.Y -= projHitbox.Height / 2;
			projHitbox.Width *= 2;
			projHitbox.Height *= 2;
			return projHitbox.Intersects(targetHitbox);
		}
	}
}