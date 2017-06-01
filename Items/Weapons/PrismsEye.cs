using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class PrismsEye : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.QueenSpiderStaff); //only here for values we haven't defined ourselves yet
			item.name = "Prism's Eye";
			item.damage = 105;  //placeholder damage :3
			item.mana = 40;	//somehow I think this might be too much...? -thegamemaster1234
			item.width = 40;
			item.height = 40;
			item.value = 80000;
			item.rare = 8;
			item.knockBack = 2.5f;
			item.UseSound = SoundID.Item25;
			item.toolTip = "A spectral bow assists you";
			item.shoot = mod.ProjectileType<Projectiles.Minions.SpiritBow>();
			item.shootSpeed = 0f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//remove any other owned SpiritBow projectiles, just like any other sentry minion
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				Projectile p = Main.projectile[i];
				if (p.active && p.type == item.shoot && p.owner == player.whoAmI)
				{
					p.active = false;
				}
			}
			//projectile spawns at mouse cursor
			Vector2 value18 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			position = value18;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<CrystiliumBar>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}