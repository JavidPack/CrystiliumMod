using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class TrueTopazStaff : ModItem
	{
		private float DistY = 0f;
		private float DistX = 0f;

		public override void SetDefaults()
		{
			item.name = "True Topaz Staff";
			item.damage = 43; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 54; //Item width
			item.height = 54; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "'A storm of a billion grains'"; //The item’s tooltip
			item.useTime = 3; //How long it takes for the item to be used
			item.useAnimation = 60; //How long the animation of the item takes
			Item.staff[item.type] = true;
			item.knockBack = 0f; //How much knockback the item produces
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 120000; //How much the item is worth
			item.rare = 8; //The rarity of the item
			item.shoot = mod.ProjectileType<Projectiles.SapphirePortal>();
			item.shootSpeed = 7f; //How fast the projectile fires
			item.mana = 90;
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Items.CrystiliumBar>(), 15);
			recipe.AddIngredient(mod.ItemType<Items.Weapons.EnchantedTopazStaff>());
			recipe.AddIngredient(mod.ItemType<Items.BrokenStaff>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
		{
			Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
			if (position.Y <= mouse.Y)
			{
				float Xdis = position.X - mouse.X;  // change myplayer to nearest player in full version
				float Ydis = position.Y - mouse.Y; // change myplayer to nearest player in full version
				float Angle = (float)Math.Atan(Xdis / Ydis);
				float DistXT = (float)(Math.Sin(Angle) * 54);
				float DistYT = (float)(Math.Cos(Angle) * 54);
				DistX = (position.X + DistXT);
				DistY = (position.Y + DistYT);
			}
			if (position.Y > mouse.Y)
			{
				float Xdis = position.X - mouse.X;  // change myplayer to nearest player in full version
				float Ydis = position.Y - mouse.Y; // change myplayer to nearest player in full version
				float Angle = (float)Math.Atan(Xdis / Ydis);
				float DistXT = (float)(Math.Sin(Angle) * 54);
				float DistYT = (float)(Math.Cos(Angle) * 54);
				DistX = (position.X + (0 - DistXT));
				DistY = (position.Y + (0 - DistYT));
			}
			Projectile.NewProjectile(DistX, DistY, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), mod.ProjectileType<Projectiles.SandParticle>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}