using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Shatterocket : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shatterocket");
			Tooltip.SetDefault("Uses RPCs as ammo"
				+ "\nFires dual volleys of varied shots");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ElectrosphereLauncher); //grabs values we're not bothering to change yet
			Item.damage = 76;
			Item.DamageType = DamageClass.Ranged;
			Item.value = 100000;
			Item.rare = 7;
			Item.autoReuse = true;
			Item.useTime = 10;
			Item.useAnimation = 20;
			Item.shoot = ProjectileType<Projectiles.RPC>();
			Item.useAmmo = ItemType<RPC>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			switch (Main.rand.Next(3))
			{
				case (0):
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<Projectiles.RPC>(), damage, knockBack, player.whoAmI);
					break;

				case (1):
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<Projectiles.RPC>(), damage * 2, knockBack, player.whoAmI, 0, 1);
					break;

				case (2):
					Projectile.NewProjectile(position.X, position.Y, speedX * 2, speedY * 2, ProjectileType<Projectiles.RPC>(), damage, knockBack, player.whoAmI, 0, 2);
					break;
			}
			return false;
		}
	}
}