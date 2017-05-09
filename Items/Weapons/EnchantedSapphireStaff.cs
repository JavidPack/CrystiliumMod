using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedSapphireStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Enchanted Sapphire Staff";
			item.damage = 20; //The damage
            item.summon = true; //Whether or not it is a magic weapon
            item.width = 60; //Item width
            item.height = 60; //Item height
            item.maxStack = 1; //How many of this item you can stack
            item.toolTip = "'Colder than tundra'"; //The item’s tooltip
            item.useTime = 50; //How long it takes for the item to be used
            item.useAnimation = 50; //How long the animation of the item takes
			Item.staff[item.type] = true;
            item.knockBack = 7f; //How much knockback the item produces
            item.UseSound = SoundID.Item30; //The soundeffect played when used
            item.noMelee = true; //Whether the weapon should do melee damage or not
            item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
            item.value = 30000;
            item.rare = 3;
            item.shoot = mod.ProjectileType("SapphirePortal"); //What the item shoots, retains an int value | *
            item.shootSpeed = 1f; //How fast the projectile fires   
            item.mana = 80;   
            item.autoReuse = false; //Whether it automatically uses the item again after its done being used/animated
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SapphireStaff, 1);
			recipe.AddIngredient(ItemID.Sapphire, 15);
			recipe.AddIngredient(null, "ShinyGemstone", 10);
			recipe.AddTile(16);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
       
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
        {
            player.channel = true;
			//Vector2 mouse = new Vector2(Main.mouseX,Main.mouseY) + Main.screenPosition;
            //remove any other owned SapphirePortal projectiles
			for(int i = 0; i < Main.projectile.Length; i++)
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
    }
}