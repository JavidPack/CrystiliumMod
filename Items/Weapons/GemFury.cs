using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class GemFury : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gem Fury");
			Tooltip.SetDefault("Converts arrows into crystal arrows");
		}

		public override void SetDefaults()
		{
			item.damage = 21;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.shoot = 3; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<CrystalArrowPlayer>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}