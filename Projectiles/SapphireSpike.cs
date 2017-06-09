using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class SapphireSpike : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Staff Spike");
		}

		public override void SetDefaults()
		{
			projectile.width = 18; //Set the hitbox width
			projectile.height = 18; //Set the hitbox height
			projectile.aiStyle = 45;
			projectile.damage = 5;
			projectile.timeLeft = 600; //The amount of time the projectile is alive for
			projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to players or not
			projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
		}

		//How the projectile works
		public override void AI()
		{
			projectile.AngleTo(Main.MouseWorld);
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 6; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 33, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
		}

		/*	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{
				target.AddBuff(Terraria.ID.BuffID.Chilled, 300);
			}*/
	}
}