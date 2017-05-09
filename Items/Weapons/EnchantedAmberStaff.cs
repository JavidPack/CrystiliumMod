using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedAmberStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Enchanted Amber Staff";
			item.damage = 17;
			item.magic = true;
			item.mana = 9;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Creates sharp daggers";
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType<AmberDagger>();
			item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amber, 15);
			recipe.AddIngredient(ItemID.AmberStaff, 1);
			recipe.AddIngredient(null, "ShinyGemstone", 10);
			recipe.AddTile(16);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//float SdirX = (Main.MouseWorld.X - player.position.X) * 8.5f;
			//float SdirY = (Main.MouseWorld.Y - player.position.Y) * 8.5f;
			float angle = (float)Math.Atan(12f);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType<AmberDagger>(), damage, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - angle, mod.ProjectileType<AmberDagger>(), damage, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + angle, mod.ProjectileType<AmberDagger>(), damage, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX - 2, speedY - (2 * angle), mod.ProjectileType<AmberDagger>(), damage, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + (2 * angle), mod.ProjectileType<AmberDagger>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}