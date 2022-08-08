using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class Cryst : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryst");
			Tooltip.SetDefault("Summons sharp crystals to orbit you");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 67;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 17;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 41;
			Item.useAnimation = 41;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 100000;
			Item.rare = 7;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.CrystProj>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			//Remove all previous Cryst projectiles - creates "reset" behavior
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				Projectile p = Main.projectile[i];
				if (p.active && p.type == Item.shoot && p.owner == player.whoAmI)
				{
					p.active = false;
				}
			}

			//get degrees from direction vector
			int dir = (int)(velocity.ToRotation() / (Math.PI / 180));
			int dir2 = dir + 120;
			int dir3 = dir - 120;

			//spawn the new projectiles
			Projectile.NewProjectile(source, position, velocity, Item.shoot, damage, knockback, player.whoAmI, 0, dir);
			Projectile.NewProjectile(source, position, velocity, Item.shoot, damage, knockback, player.whoAmI, 0, dir2);
			Projectile.NewProjectile(source, position, velocity, Item.shoot, damage, knockback, player.whoAmI, 0, dir3);
			return false;
		}
	}
}