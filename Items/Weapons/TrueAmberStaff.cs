using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class TrueAmberStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "True Amber Staff";
			item.damage = 73; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 54; //Item width
			item.height = 54; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "'Blades of Cleopatra'"; //The item’s tooltip
			item.useTime = 25; //How long it takes for the item to be used
			item.useAnimation = 25; //How long the animation of the item takes
			Item.staff[item.type] = true;
			item.knockBack = 7f; //How much knockback the item produces
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 120000; //How much the item is worth
			item.rare = 8; //The rarity of the item
			item.shoot = 580; //What the item shoots, retains an int value | *
			item.shootSpeed = 7f; //How fast the projectile fires
			item.mana = 20;
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Items.CrystiliumBar>(), 15);
			recipe.AddIngredient(mod.ItemType<Items.Weapons.EnchantedAmberStaff>());
			recipe.AddIngredient(mod.ItemType<Items.BrokenStaff>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
			float Xdis1 = (Main.LocalPlayer.Center.X - mouse.X) + 45;  // change myplayer to nearest player in full version
			float Ydis1 = (Main.LocalPlayer.Center.Y - mouse.Y) + 45;// change myplayer to nearest player in full version
			float Angle1 = (float)Math.Atan(Xdis1 / Ydis1);
			float TrijectoryX1 = (float)(Math.Sin(Angle1));
			float TrijectoryY1 = (float)(Math.Cos(Angle1));
			float Xdis2 = (Main.LocalPlayer.Center.X - mouse.X) - 45;  // change myplayer to nearest player in full version
			float Ydis2 = (Main.LocalPlayer.Center.Y - mouse.Y) + 45;// change myplayer to nearest player in full version
			float Angle2 = (float)Math.Atan(Xdis2 / Ydis2);
			float TrijectoryX2 = (float)(Math.Sin(Angle2));
			float TrijectoryY2 = (float)(Math.Cos(Angle2));
			float Xdis3 = (Main.LocalPlayer.Center.X - mouse.X) + 45;  // change myplayer to nearest player in full version
			float Ydis3 = (Main.LocalPlayer.Center.Y - mouse.Y) - 45;// change myplayer to nearest player in full version
			float Angle3 = (float)Math.Atan(Xdis3 / Ydis3);
			float TrijectoryX3 = (float)(Math.Sin(Angle3));
			float TrijectoryY3 = (float)(Math.Cos(Angle3));
			float Xdis4 = (Main.LocalPlayer.Center.X - mouse.X) - 45;  // change myplayer to nearest player in full version
			float Ydis4 = (Main.LocalPlayer.Center.Y - mouse.Y) - 45;// change myplayer to nearest player in full version
			float Angle4 = (float)Math.Atan(Xdis4 / Ydis4);
			float TrijectoryX4 = (float)(Math.Sin(Angle4));
			float TrijectoryY4 = (float)(Math.Cos(Angle4));
			if (Ydis1 >= 0)
			{
				Projectile.NewProjectile(player.Center.X + 45, player.Center.Y + 45, 0 - (TrijectoryX1 * 9), 0 - (TrijectoryY1 * 9), mod.ProjectileType<AmberBlade>(), damage, knockBack, player.whoAmI);
			}
			else
			{
				Projectile.NewProjectile(player.Center.X + 45, player.Center.Y + 45, TrijectoryX1 * 9, TrijectoryY1 * 9, mod.ProjectileType<AmberBlade>(), damage, knockBack, player.whoAmI);
			}

			if (Ydis2 >= 0)
			{
				Projectile.NewProjectile(player.Center.X - 45, player.Center.Y + 45, 0 - (TrijectoryX2 * 9), 0 - (TrijectoryY2 * 9), mod.ProjectileType<AmberBlade>(), damage, knockBack, player.whoAmI);
			}
			else
			{
				Projectile.NewProjectile(player.Center.X - 45, player.Center.Y + 45, TrijectoryX2 * 9, TrijectoryY2 * 9, mod.ProjectileType<AmberBlade>(), damage, knockBack, player.whoAmI);
			}

			if (Ydis3 >= 0)
			{
				Projectile.NewProjectile(player.Center.X + 45, player.Center.Y - 45, 0 - (TrijectoryX3 * 9), 0 - (TrijectoryY3 * 9), mod.ProjectileType<AmberBlade>(), damage, knockBack, player.whoAmI);
			}
			else
			{
				Projectile.NewProjectile(player.Center.X + 45, player.Center.Y - 45, TrijectoryX3 * 9, TrijectoryY3 * 9, mod.ProjectileType<AmberBlade>(), damage, knockBack, player.whoAmI);
			}

			if (Ydis4 >= 0)
			{
				Projectile.NewProjectile(player.Center.X - 45, player.Center.Y - 45, 0 - (TrijectoryX4 * 9), 0 - (TrijectoryY4 * 9), mod.ProjectileType<AmberBlade>(), damage, knockBack, player.whoAmI);
			}
			else
			{
				Projectile.NewProjectile(player.Center.X - 45, player.Center.Y - 45, TrijectoryX4 * 9, TrijectoryY4 * 9, mod.ProjectileType<AmberBlade>(), damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}