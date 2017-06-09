using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class TerraStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ultimate Gem Staff");
			Tooltip.SetDefault("'Ultimate gemstone power'");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 96;
			item.magic = true;
			item.mana = 3;
			item.width = 40;
			item.height = 40;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 100000;
			item.rare = 8;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType<AmberDagger>();
			item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<TrueRubyStaff>());
			recipe.AddIngredient(mod.ItemType<TrueEmeraldStaff>());
			recipe.AddIngredient(mod.ItemType<TrueDiamondStaff>());
			recipe.AddIngredient(mod.ItemType<TrueSapphireStaff>());
			recipe.AddIngredient(mod.ItemType<TrueAmethystStaff>());
			recipe.AddIngredient(mod.ItemType<TrueTopazStaff>());
			recipe.AddIngredient(mod.ItemType<TrueAmberStaff>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(20) + 8));

			//create the first two projectiles
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType<Projectiles.TrueGems.TerraGemProj>(), damage, knockBack, player.whoAmI, 0f, 1f);
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, mod.ProjectileType<Projectiles.TrueGems.TerraGemProj>(), damage, knockBack, player.whoAmI, 0f, 2f);

			//generate the remaining projectiles
			for (int i = 3; i <= 7; i++)
			{
				Vector2 randVect2 = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(20) + 8));
				Projectile.NewProjectile(position.X, position.Y, randVect2.X, randVect2.Y, mod.ProjectileType<Projectiles.TrueGems.TerraGemProj>(), damage, knockBack, player.whoAmI, 0f, i);
			}
			return false;
		}
	}
}