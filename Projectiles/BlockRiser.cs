using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
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
			projectile.width = 10; //Set the hitbox width
			projectile.height = 10; //Set the hitbox height
			projectile.timeLeft = 1000; //The amount of time the projectile is alive for
			projectile.penetrate = 3; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to Players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to Players or not
			projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.aiStyle = -1; //How the projectile works, 0 makes the projectile just go straight towards your cursor
			projectile.light = 1;
		}

		//How the projectile works
		public override void AI()
		{
			if (start)
			{
				mouseX = projectile.timeLeft / 10;
			}
			projectile.timeLeft += 10;
			int y = (int)(-1 + (Main.mouseY + Main.screenPosition.Y) / 16) * 16;
			projectile.position = new Vector2(mouseX, y);
			Main.NewText("PrX:" + projectile.position.X.ToString());
			Main.NewText("PrY:" + projectile.position.Y.ToString());
			Main.NewText("PX:" + Main.LocalPlayer.position.X.ToString());
			Main.NewText("PY:" + Main.LocalPlayer.position.Y.ToString());
			start = false;
		}
	}
}