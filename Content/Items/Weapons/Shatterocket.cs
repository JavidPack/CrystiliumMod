using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
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
			Item.shoot = ModContent.ProjectileType<Projectiles.RPC>();
			Item.useAmmo = ModContent.ItemType<RPC>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			switch (Main.rand.Next(3))
			{
				case (0):
					Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.RPC>(), damage, knockback, player.whoAmI);
					break;

				case (1):
					Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.RPC>(), damage * 2, knockback, player.whoAmI, 0, 1);
					break;

				case (2):
					Projectile.NewProjectile(source, position, velocity * 2, ModContent.ProjectileType<Projectiles.RPC>(), damage, knockback, player.whoAmI, 0, 2);
					break;
			}
			return false;
		}
	}
}