using CrystiliumMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
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
			Item.damage = 21;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4;
			Item.value = 30000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
			Item.shoot = 3; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 8f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<CrystalArrowPlayer>(), damage, knockback, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}