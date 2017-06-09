using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class DiamondSceptor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diamond Scepter");
			Tooltip.SetDefault("Launches an explosive diamond");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 35;
			item.magic = true;
			item.mana = 15;
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType<Projectiles.AmberDagger>();
			item.shootSpeed = 8f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 6;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(30) + 13));

			//create the first two projectiles
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType<DiamondBomb>(), damage, knockBack, item.owner, 0f, 1f);
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, mod.ProjectileType<DiamondBomb>(), damage, knockBack, item.owner, 0f, 2f);

			//generate the remaining projectiles
			for (int i = 3; i <= 2; i++)
			{
				Vector2 randVect2 = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(30) + 13));
				Projectile.NewProjectile(position.X, position.Y, randVect2.X, randVect2.Y, mod.ProjectileType<DiamondBomb>(), damage, knockBack, item.owner, 0f, i);
			}
			return false;
		}
	}
}