using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
	public class VortexCrystal : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vortex crystal");
		}

		public override void SetDefaults()
		{
			Projectile.width = 13;
			Projectile.height = 46;
			Projectile.timeLeft = 100; //The amount of time the projectile is alive for
			Projectile.penetrate = 10; //Tells the game how many enemies it can hit before being destroyed
			Projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
			Projectile.hostile = false; //Tells the game whether it is hostile to players or not
			Projectile.light = 0.75f;
			Projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
			Projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
		}

		//How the projectile works
		public override void AI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation() + 1.57f;
			Projectile.velocity *= 0.98f;
		}

		//public override bool OnTileCollide(Vector2 oldVelocity)
		//{
		//	 projectile.velocity.X = 0f;
		//	 projectile.velocity.Y = 0f;
		//	 return false;
		//}
	}
}