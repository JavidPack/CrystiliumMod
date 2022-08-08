using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class EnchantedAmethystStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted amethyst staff");
			Tooltip.SetDefault("'Made with shadow magic'");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 11;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 30000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.TrueAmethystProjectile>();
			Item.shootSpeed = 1f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
			Projectile.NewProjectile(source, (mouse.X - 16) + Main.rand.Next(32), (mouse.Y - 16) + Main.rand.Next(32), Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), ModContent.ProjectileType<Projectiles.TrueAmethystProjectile>(), damage, knockback, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(source, (mouse.X - 16) + Main.rand.Next(32), (mouse.Y - 16) + Main.rand.Next(32), Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), ModContent.ProjectileType<Projectiles.TrueAmethystProjectile>(), damage, knockback, player.whoAmI, 0f, 0f);
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AmethystStaff);
			recipe.AddIngredient(ItemID.Amethyst, 15);
			recipe.AddIngredient(ModContent.ItemType<Items.ShinyGemstone>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}