using System;
using CrystiliumMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class TrueAmberStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Amber Staff");
			// Tooltip.SetDefault("'Blades of Cleopatra'");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 73; //The damage
			Item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			Item.width = 54; //Item width
			Item.height = 54; //Item height
			Item.maxStack = 1; //How many of this item you can stack
			Item.useTime = 25; //How long it takes for the item to be used
			Item.useAnimation = 25; //How long the animation of the item takes
			Item.knockBack = 7f; //How much knockback the item produces
			Item.noMelee = true; //Whether the weapon should do melee damage or not
			Item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			Item.value = 120000; //How much the item is worth
			Item.rare = 8; //The rarity of the item
			Item.shoot = 580; //What the item shoots, retains an int value | *
			Item.shootSpeed = 7f; //How fast the projectile fires
			Item.mana = 20;
			Item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.CrystiliumBar>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Items.Weapons.EnchantedAmberStaff>());
			recipe.AddIngredient(ModContent.ItemType<Items.BrokenStaff>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
				Projectile.NewProjectile(source, player.Center.X + 45, player.Center.Y + 45, 0 - (TrijectoryX1 * 9), 0 - (TrijectoryY1 * 9), ModContent.ProjectileType<AmberBlade>(), damage, knockback, player.whoAmI);
			}
			else
			{
				Projectile.NewProjectile(source, player.Center.X + 45, player.Center.Y + 45, TrijectoryX1 * 9, TrijectoryY1 * 9, ModContent.ProjectileType<AmberBlade>(), damage, knockback, player.whoAmI);
			}

			if (Ydis2 >= 0)
			{
				Projectile.NewProjectile(source, player.Center.X - 45, player.Center.Y + 45, 0 - (TrijectoryX2 * 9), 0 - (TrijectoryY2 * 9), ModContent.ProjectileType<AmberBlade>(), damage, knockback, player.whoAmI);
			}
			else
			{
				Projectile.NewProjectile(source, player.Center.X - 45, player.Center.Y + 45, TrijectoryX2 * 9, TrijectoryY2 * 9, ModContent.ProjectileType<AmberBlade>(), damage, knockback, player.whoAmI);
			}

			if (Ydis3 >= 0)
			{
				Projectile.NewProjectile(source, player.Center.X + 45, player.Center.Y - 45, 0 - (TrijectoryX3 * 9), 0 - (TrijectoryY3 * 9), ModContent.ProjectileType<AmberBlade>(), damage, knockback, player.whoAmI);
			}
			else
			{
				Projectile.NewProjectile(source, player.Center.X + 45, player.Center.Y - 45, TrijectoryX3 * 9, TrijectoryY3 * 9, ModContent.ProjectileType<AmberBlade>(), damage, knockback, player.whoAmI);
			}

			if (Ydis4 >= 0)
			{
				Projectile.NewProjectile(source, player.Center.X - 45, player.Center.Y - 45, 0 - (TrijectoryX4 * 9), 0 - (TrijectoryY4 * 9), ModContent.ProjectileType<AmberBlade>(), damage, knockback, player.whoAmI);
			}
			else
			{
				Projectile.NewProjectile(source, player.Center.X - 45, player.Center.Y - 45, TrijectoryX4 * 9, TrijectoryY4 * 9, ModContent.ProjectileType<AmberBlade>(), damage, knockback, player.whoAmI);
			}
			return false;
		}
	}
}