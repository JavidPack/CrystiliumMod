using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class PrismaticBoomstick : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Prismatic Boomstick");
			// Tooltip.SetDefault("Launches rainbow beams");
		}

		public override void SetDefaults()
		{
			Item.damage = 47;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = 7;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.PrismSlug>(); //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float speedX = velocity.X;
			float speedY = velocity.Y;

			for (int i = 0; i < 3; i++)
			{
				Projectile.NewProjectile(source, position.X - 8, position.Y + 8, speedX + ((float)Main.rand.Next(-200, 200) / 100), speedY + ((float)Main.rand.Next(-200, 200) / 100), type, damage, knockback, player.whoAmI, 0f, 0f);
			}
			return false;
		}
	}
}