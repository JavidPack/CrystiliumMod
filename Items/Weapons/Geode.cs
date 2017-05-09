using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
    public class Geode : ModItem
    {
        public override void SetDefaults()
        {
			item.CloneDefaults(ItemID.WoodYoyo);
            item.name = "Geode";
			item.damage = 22;
            item.value = 30000;
            item.rare = 3;
            item.toolTip = "Very sharp when broken";
			item.knockBack = 0;
			item.channel = true;
			item.useStyle = 5;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shoot = mod.ProjectileType("Geode");
           
        }
	}
}