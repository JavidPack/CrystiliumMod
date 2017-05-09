using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedAmethystStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Enchanted amethyst staff";
			item.damage = 18;
			item.magic = true;
			item.mana = 11;
			item.width = 40;
			item.height = 40;
			item.toolTip = "'Made with shadow magic'";
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 5;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType<Projectiles.TrueAmethystProjectile>();
			item.shootSpeed = 1f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
			Projectile.NewProjectile((mouse.X - 16) + Main.rand.Next(32), (mouse.Y - 16) + Main.rand.Next(32), Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), mod.ProjectileType<Projectiles.TrueAmethystProjectile>(), damage, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((mouse.X - 16) + Main.rand.Next(32), (mouse.Y - 16) + Main.rand.Next(32), Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), mod.ProjectileType<Projectiles.TrueAmethystProjectile>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AmethystStaff);
			recipe.AddIngredient(ItemID.Amethyst, 15);
			recipe.AddIngredient(mod.ItemType<Items.ShinyGemstone>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}