using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class RoyalShredder : ModItem
	{
		private Vector2 newVect;
		public override void SetDefaults()
		{
			item.name = "Royal Shredder";
			item.damage = 54;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "'Crush your enemies'";
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 100000;
			item.rare = 7;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType<Projectiles.Shatter1>(); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 14f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 origVect = new Vector2(speedX, speedY);
			if (Main.rand.Next(2) == 1)
			{
				newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(900, 1800) / 10));
			}
			else
			{
				newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(900, 1800) / 10));
			}
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, mod.ProjectileType("Shatter" + (1 + Main.rand.Next(0, 3))), damage - 5, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}