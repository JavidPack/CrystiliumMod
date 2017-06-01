using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
	public class VortexCrystal : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Vortex crystal"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 13;
			projectile.height = 46;
			projectile.timeLeft = 100; //The amount of time the projectile is alive for
			projectile.penetrate = 10; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to players or not
			projectile.light = 0.75f;
			projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
		}

		//How the projectile works
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
			projectile.velocity *= 0.98f;
		}

		//public override bool OnTileCollide(Vector2 oldVelocity)
		//{
		//	 projectile.velocity.X = 0f;
		//	 projectile.velocity.Y = 0f;
		//	 return false;
		//}
	}
}