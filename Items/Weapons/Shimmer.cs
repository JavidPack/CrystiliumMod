using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Shimmer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shimmer");
			Tooltip.SetDefault("Rain lead on the enemy");
		}

		public override void SetDefaults()
		{
			item.damage = 47;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 100000;
			item.rare = 7;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 15f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 3; i++)
			{
				Projectile.NewProjectile(position.X - 8, position.Y + 8, speedX + ((float)Main.rand.Next(-300, 300) / 100), speedY + ((float)Main.rand.Next(-300, 300) / 100), type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}
	}
}