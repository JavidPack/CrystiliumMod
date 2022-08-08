using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class CrystiliumSceptor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystilium Scepter");
			Tooltip.SetDefault("Launches 5 bolts");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 67;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 25;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 12;
			Item.useAnimation = 60;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 80000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.AmberDagger>();
			Item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			//float SdirX = (Main.MouseWorld.X - player.position.X) * 9.5f;
			//float SdirY = (Main.MouseWorld.Y - player.position.Y) * 9.5f;
			float speedX = velocity.X;
			float speedY = velocity.Y;
			float angle = (float)Math.Atan((float)Main.rand.Next(-12, 12));
			Projectile.NewProjectile(source, position.X, position.Y, speedX + angle, speedY + Main.rand.Next(-1, 1), ModContent.ProjectileType<Projectiles.CrystalSceptorProj>(), damage, knockback, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}