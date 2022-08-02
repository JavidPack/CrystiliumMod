using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class BlockRiser : ModProjectile
	{
		public float mouseX;
		private bool start = true;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Block Riser");
		}

		public override void SetDefaults()
		{
			Projectile.width = 10; //Set the hitbox width
			Projectile.height = 10; //Set the hitbox height
			Projectile.timeLeft = 1000; //The amount of time the projectile is alive for
			Projectile.penetrate = 3; //Tells the game how many enemies it can hit before being destroyed
			Projectile.friendly = true; //Tells the game whether it is friendly to Players/friendly npcs or not
			Projectile.hostile = false; //Tells the game whether it is hostile to Players or not
			Projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
			Projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			Projectile.aiStyle = -1; //How the projectile works, 0 makes the projectile just go straight towards your cursor
			Projectile.light = 1;
		}

		//How the projectile works
		public override void AI()
		{
			if (start)
			{
				mouseX = Projectile.timeLeft / 10;
			}
			Projectile.timeLeft += 10;
			int y = (int)(-1 + (Main.mouseY + Main.screenPosition.Y) / 16) * 16;
			Projectile.position = new Vector2(mouseX, y);
			Main.NewText("PrX:" + Projectile.position.X.ToString());
			Main.NewText("PrY:" + Projectile.position.Y.ToString());
			Main.NewText("PX:" + Main.LocalPlayer.position.X.ToString());
			Main.NewText("PY:" + Main.LocalPlayer.position.Y.ToString());
			start = false;
		}
	}
}