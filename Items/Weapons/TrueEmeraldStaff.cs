using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class TrueEmeraldStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "True Emerald staff";
			item.damage = 65;
			item.magic = true;
			item.mana = 9;
			item.width = 40;
			item.height = 40;
			item.toolTip = "'Blow all your enemies away'";
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 5;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 120000; //How much the item is worth
			item.rare = 8; //The rarity of the item
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType<Projectiles.AmberDagger>();
			item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Items.CrystiliumBar>(), 15);
			recipe.AddIngredient(mod.ItemType<Items.Weapons.EnchantedEmeraldStaff>(), 1);
			recipe.AddIngredient(mod.ItemType<Items.BrokenStaff>(), 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX + Main.rand.Next(-3, 3), speedY + Main.rand.Next(-3, 3), mod.ProjectileType<Projectiles.TrueLeaf>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}