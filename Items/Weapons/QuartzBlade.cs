using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class QuartzBlade : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Quartz Blade";
			item.damage = 54;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Launches tridents";
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = 80000;
            item.rare = 8;
            item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("QuartzTrident");
			item.shootSpeed = 6f;
			item.autoReuse = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//create velocity vectors for the two angled projectiles (outwards at PI/6 radians, or 15 degrees)
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / 20);
			Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 20);

			//create three Crystishae projectiles
			Projectile.NewProjectile(player.Center.X, player.Center.Y - 20, speedX, speedY, mod.ProjectileType("QuartzTrident"), damage, knockBack, item.owner, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y - 20, newVect.X, newVect.Y, mod.ProjectileType("QuartzTrident"), damage, knockBack, item.owner, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y - 20, newVect2.X, newVect2.Y, mod.ProjectileType("QuartzTrident"), damage, knockBack, item.owner, 0, 0);
			return false;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			for (int J = 1; J < 3; J++)
			{
				Vector2 vel = new Vector2(0, -1);   
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
		/*		int proj = Projectile.NewProjectile(projectile.Center.X, item.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("Shatter"+(1+Main.rand.Next(0,3))), item.damage / 4, 0, Main.myPlayer); */
			}
		}
	}
}