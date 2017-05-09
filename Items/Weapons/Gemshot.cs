using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class Gemshot : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Gemshot";
			item.damage = 47;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "Converts arrows into enchanted crystal arrows";
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 6;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 3; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Arrow;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType<Projectiles.EnchantedCrystalArrow>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}