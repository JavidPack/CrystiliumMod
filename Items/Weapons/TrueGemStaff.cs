using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class TrueGemStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Gem Staff");
			Tooltip.SetDefault("'Ultimate gemstone power'");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 19;
			item.magic = true;
			item.mana = 3;
			item.width = 40;
			item.height = 40;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 40000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<Projectiles.AmberDagger>();
			item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<EnchantedRubyStaff>());
			recipe.AddIngredient(ItemType<EnchantedAmberStaff>());
			recipe.AddIngredient(ItemType<EnchantedEmeraldStaff>());
			recipe.AddIngredient(ItemType<EnchantedDiamondStaff>());
			recipe.AddIngredient(ItemType<EnchantedSapphireStaff>());
			recipe.AddIngredient(ItemType<EnchantedTopazStaff>());
			recipe.AddIngredient(ItemType<EnchantedAmethystStaff>());
			recipe.AddIngredient(ItemType<ShinyGemstone>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//float SdirX = (Main.MouseWorld.X - player.position.X) * 8.5f;
			//float SdirY = (Main.MouseWorld.Y - player.position.Y) * 8.5f;
			float angle = (float)Math.Atan((float)Main.rand.Next(-12, 12));
			Projectile.NewProjectile(position.X, position.Y, speedX + angle, speedY + Main.rand.Next(-1, 1), ProjectileType<Projectiles.TrueGemFire>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}