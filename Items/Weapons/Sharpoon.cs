using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Sharpoon : ModItem
	{
		private Vector2 newVect;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharp Shooter");
			Tooltip.SetDefault("'Smooth as a crystal'");
		}

		public override void SetDefaults()
		{
			item.damage = 26;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 48;
			item.useAnimation = 48;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 100000;
			item.rare = 7;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 11f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 origVect = new Vector2(speedX, speedY);
			for (int X = 0; X <= 4; X++)
			{
				if (Main.rand.Next(2) == 0)
				{
					newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
				}
				else
				{
					newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(72, 1800) / 10));
				}
				newVect *= 0.4f;
				Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, mod.ProjectileType("Shatter" + (1 + Main.rand.Next(0, 3))), damage - 9, knockBack, player.whoAmI, 0f, 0f);
			}
			return true;
		}
	}
}