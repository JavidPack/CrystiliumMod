using CrystiliumMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class DiamondSceptor : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Diamond Scepter");
			// Tooltip.SetDefault("Launches an explosive diamond");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 15;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.AmberDagger>();
			Item.shootSpeed = 8f;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = 6;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float speedX = velocity.X;
			float speedY = velocity.Y;
			Vector2 newVect = velocity.RotatedBy(System.Math.PI / (Main.rand.Next(30) + 13));

			//create the first two projectiles
			Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, ModContent.ProjectileType<DiamondBomb>(), damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 1f);
			Projectile.NewProjectile(source, position.X, position.Y, newVect.X, newVect.Y, ModContent.ProjectileType<DiamondBomb>(), damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 2f);

			//generate the remaining projectiles
			for (int i = 3; i <= 2; i++)
			{
				Vector2 randVect2 = velocity.RotatedBy(-System.Math.PI / (Main.rand.Next(30) + 13));
				Projectile.NewProjectile(source, position.X, position.Y, randVect2.X, randVect2.Y, ModContent.ProjectileType<DiamondBomb>(), damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, i);
			}
			return false;
		}
	}
}