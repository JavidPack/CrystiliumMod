using Microsoft.Xna.Framework;
using Terraria;
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
			item.CloneDefaults(ItemID.ElectrosphereLauncher); //grabs values we're not bothering to change yet
			item.damage = 76;
			item.ranged = true;
			item.value = 100000;
			item.rare = 7;
			item.autoReuse = true;
			item.useTime = 10;
			item.useAnimation = 20;
			item.shoot = ProjectileType<Projectiles.RPC>();
			item.useAmmo = ItemType<RPC>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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