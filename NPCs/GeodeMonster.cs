using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace CrystiliumMod.NPCs
{
	public class GeodeMonster : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Geode Mutant";
			npc.displayName = "Geode Mutant";
			npc.damage = 54;
			npc.defense = 18;
			npc.height = 56;
			npc.width = 70;
			npc.lifeMax = 350;
            npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.height = 56;
			npc.value = 550f;
			npc.knockBackResist = 0.75f;
			npc.aiStyle = NPCID.GoblinPeon;
			Main.npcFrameCount[npc.type] = 8;
			aiType = NPCID.GoblinPeon;
			animationType = 415;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode) //restrict spawning to Hardmode
				return Main.tile[(int)(spawnInfo.spawnTileX),(int)(spawnInfo.spawnTileY)].type == mod.TileType("CrystalBlock") ? 13f : 0f;
			return 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if(npc.life <= 0) {
				//spawn initial set
				for(int i = 1; i <= 4; i++) {
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Geode_Monster_Gore_" + i));
				}
				//spawn rest of the legs
				for(int i = 0; i < 3; i++) {
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Geode_Monster_Gore_2"));
				}
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnchantedGeode"));
			}
		}
		
		  public override void AI()
		  {
			  Vector3 RGB = new Vector3(0f,0.75f,1.5f);
			float multiplier = 1;
			float max = 2.25f;
			float min = 1.0f;
			RGB *= multiplier;
			if (RGB.X > max)
			{
			multiplier = 0.5f;
			}
			if (RGB.X < min)
			{
			multiplier = 1.5f;
			}
			Lighting.AddLight(npc.position,RGB.X,RGB.Y,RGB.Z);
            if (Main.rand.Next(50) == 5)
            {
                for (int h = 0; h < 10; h++)
                {
                    Vector2 vel = new Vector2(0, -1);
                    float rand = Main.rand.NextFloat() * 6.283f;
                    vel = vel.RotatedBy(rand);
                    vel *= 5f;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("ShatterEnemy" + (1 + Main.rand.Next(0, 3))), 25, 0, Main.myPlayer);
                }
            }
        } 
	}
}
