using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class TrueEmeraldStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Emerald staff");
			// Tooltip.SetDefault("'Blow all your enemies away'");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 65;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 9;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 7;
			Item.useAnimation = 7;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 120000; //How much the item is worth
			Item.rare = 8; //The rarity of the item
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.AmberDagger>();
			Item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.CrystiliumBar>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Items.Weapons.EnchantedEmeraldStaff>());
			recipe.AddIngredient(ModContent.ItemType<Items.BrokenStaff>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float speedX = velocity.X;
			float speedY = velocity.Y;
			Projectile.NewProjectile(source, position.X, position.Y, speedX + Main.rand.Next(-3, 3), speedY + Main.rand.Next(-3, 3), ModContent.ProjectileType<Projectiles.TrueLeaf>(), damage, knockback, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}