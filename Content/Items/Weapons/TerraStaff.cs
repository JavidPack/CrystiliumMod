using CrystiliumMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class TerraStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ultimate Gem Staff");
			// Tooltip.SetDefault("'Ultimate gemstone power'");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 96;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 3;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 100000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<AmberDagger>();
			Item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TrueRubyStaff>());
			recipe.AddIngredient(ModContent.ItemType<TrueEmeraldStaff>());
			recipe.AddIngredient(ModContent.ItemType<TrueDiamondStaff>());
			recipe.AddIngredient(ModContent.ItemType<TrueSapphireStaff>());
			recipe.AddIngredient(ModContent.ItemType<TrueAmethystStaff>());
			recipe.AddIngredient(ModContent.ItemType<TrueTopazStaff>());
			recipe.AddIngredient(ModContent.ItemType<TrueAmberStaff>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 newVect = velocity.RotatedBy(System.Math.PI / (Main.rand.Next(20) + 8));

			//create the first two projectiles
			Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<Projectiles.TrueGems.TerraGemProj>(), damage, knockback, player.whoAmI, 0f, 1f);
			Projectile.NewProjectile(source, position.X, position.Y, newVect.X, newVect.Y, ModContent.ProjectileType<Projectiles.TrueGems.TerraGemProj>(), damage, knockback, player.whoAmI, 0f, 2f);

			//generate the remaining projectiles
			for (int i = 3; i <= 7; i++)
			{
				Vector2 randVect2 = velocity.RotatedBy(-System.Math.PI / (Main.rand.Next(20) + 8));
				Projectile.NewProjectile(source, position.X, position.Y, randVect2.X, randVect2.Y, ModContent.ProjectileType<Projectiles.TrueGems.TerraGemProj>(), damage, knockback, player.whoAmI, 0f, i);
			}
			return false;
		}
	}
}