using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedAmethystStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted amethyst staff");
			Tooltip.SetDefault("'Made with shadow magic'");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.magic = true;
			item.mana = 11;
			item.width = 40;
			item.height = 40;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<Projectiles.TrueAmethystProjectile>();
			item.shootSpeed = 1f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
			Projectile.NewProjectile((mouse.X - 16) + Main.rand.Next(32), (mouse.Y - 16) + Main.rand.Next(32), Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), ProjectileType<Projectiles.TrueAmethystProjectile>(), damage, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((mouse.X - 16) + Main.rand.Next(32), (mouse.Y - 16) + Main.rand.Next(32), Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), ProjectileType<Projectiles.TrueAmethystProjectile>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AmethystStaff);
			recipe.AddIngredient(ItemID.Amethyst, 15);
			recipe.AddIngredient(ItemType<Items.ShinyGemstone>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}