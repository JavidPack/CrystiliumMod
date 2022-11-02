using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class RoyalShredder : ModItem
	{
		private Vector2 newVect;

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Royal Shredder");
			// Tooltip.SetDefault("'Crush your enemies'");
		}

		public override void SetDefaults()
		{
			Item.damage = 54;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = 7;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Shatter1>(); //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 14f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (Main.rand.Next(2) == 0)
			{
				newVect = velocity.RotatedBy(System.Math.PI / (Main.rand.Next(900, 1800) / 10));
			}
			else
			{
				newVect = velocity.RotatedBy(-System.Math.PI / (Main.rand.Next(900, 1800) / 10));
			}
			Projectile.NewProjectile(source, position.X, position.Y, newVect.X, newVect.Y, Mod.Find<ModProjectile>("Shatter" + (1 + Main.rand.Next(0, 3))).Type, damage - 5, knockback, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}