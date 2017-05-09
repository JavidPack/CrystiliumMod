using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CrystiliumMod.Projectiles;

namespace CrystiliumMod.Items.Weapons
{
	public class Shatterocket : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ElectrosphereLauncher); //grabs values we're not bothering to change yet
			item.name = "Shatterocket";
			item.damage = 76;
			item.ranged = true;
			item.value = 100000;
			item.rare = 7;
			item.toolTip = "Uses RPCs as ammo";
			item.toolTip2 = "Fires dual volleys of varied shots";
			item.autoReuse = true;
			item.useTime = 10;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType<Projectiles.RPC>();
			item.useAmmo = mod.ItemType<RPC>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			switch (Main.rand.Next(3))
			{
				case (0):
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType<Projectiles.RPC>(), damage, knockBack, player.whoAmI);
					break;
				case (1):
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType<Projectiles.RPC>(), damage * 2, knockBack, player.whoAmI, 0, 1);
					break;
				case (2):
					Projectile.NewProjectile(position.X, position.Y, speedX * 2, speedY * 2, mod.ProjectileType<Projectiles.RPC>(), damage, knockBack, player.whoAmI, 0, 2);
					break;
			}
			return false;
		}
	}
}