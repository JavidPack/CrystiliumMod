using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class SolarSickle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Crystal Sickle");
			Tooltip.SetDefault("'Shines with the ember of sunset'");
		}

		public override void SetDefaults()
		{
			item.damage = 166;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 600000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.SolarCrystal>();
			item.shootSpeed = 11f;
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//create velocity vectors for the two angled projectiles (outwards at PI/15 radians)
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / 15);
			Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 15);

			//create three Crystishae projectiles
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0, 0);
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI, 0, 0);
			Projectile.NewProjectile(position.X, position.Y, newVect2.X, newVect2.Y, type, damage, knockBack, player.whoAmI, 0, 0);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<CrystiliumBar>(), 15);
			recipe.AddIngredient(ItemID.FragmentSolar, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}