using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace CrystiliumMod.Items.Weapons
{
	public class CrystiliumSceptor : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystilium Scepter";
			item.damage = 67;
			item.magic = true;
			item.mana = 25;
			item.width = 40;
			item.height = 40;
			item.toolTip = "launches 5 bolts.";
			item.useTime = 12;
			item.useAnimation = 60;
			item.useStyle = 5;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 80000;
			item.rare = 8;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("AmberDagger");
			item.shootSpeed = 8f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            //float SdirX = (Main.MouseWorld.X - player.position.X) * 9.5f;
            //float SdirY = (Main.MouseWorld.Y - player.position.Y) * 9.5f;
            float angle = (float)Math.Atan((float)Main.rand.Next(-12, 12));
            Projectile.NewProjectile(position.X, position.Y, speedX + angle, speedY + Main.rand.Next(-1, 1), mod.ProjectileType("CrystalSceptorProj"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
	}
}