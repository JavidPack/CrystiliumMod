using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.NPCs
{
	public class CrystalSlime : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Crystal Slime";
			npc.displayName = "Crystal Slime";
			npc.width = 30;
			npc.height = 50;
			npc.damage = 24;
			npc.defense = 9;
			npc.lifeMax = 130;
            npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 200f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 1;
			Main.npcFrameCount[npc.type] = 2;
			aiType = 1;
			animationType = NPCID.BlueSlime;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return Main.tile[(int)(spawnInfo.spawnTileX),(int)(spawnInfo.spawnTileY)].type == mod.TileType("CrystalBlock") ? 10f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if(npc.life <= 0) {
				//spawn gore set
				for(int i = 1; i <= 4; i++) {
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crystal_Slime_Gore_" + i));
				}
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShinyGemstone"));
			}
		}
		
		  public override void AI()
		  {
			  Vector3 RGB = new Vector3(2.0f,0.75f,1.5f);
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
        } 
	}
}
