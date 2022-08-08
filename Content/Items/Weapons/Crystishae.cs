using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class Crystishae : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystoshet");
			Tooltip.SetDefault("'The powers of three do not set out alone'");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ThornChakram);
			Item.damage = 77;
			Item.DamageType = DamageClass.Throwing;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = 6;
			Item.shoot = ModContent.ProjectileType<Projectiles.Crystishae>();
		}

		public override bool CanUseItem(Player player)
		{
			//if any projectiles named "Crystishae" exist that are owned by this player, don't use this item
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].type == Item.shoot && Main.projectile[i].owner == player.whoAmI)
					return false;
			}

			//otherwise, use this item
			return true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			//create velocity vectors for the two angled projectiles (outwards at PI/15 radians)
			Vector2 newVect = velocity.RotatedBy(System.Math.PI / 15);
			Vector2 newVect2 = velocity.RotatedBy(-System.Math.PI / 15);

			//create three Crystishae projectiles
			//Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(source, position.X, position.Y, newVect.X, newVect.Y, type, damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, position.X, position.Y, newVect2.X, newVect2.Y, type, damage, knockback, player.whoAmI);
			return true; //will shoot original projectile
		}
	}
}