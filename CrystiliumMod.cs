using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod
{
	public class CrystiliumMod : Mod
	{
		internal static CrystiliumMod instance;

		public CrystiliumMod()
		{
			// We need this for the worldgen chest fix.
			if (ModLoader.version < new Version(0, 10, 0, 1))
			{
				throw new Exception("\nThis mod uses functionality only present in the latest tModLoader. Please update tModLoader to use this mod\n\n");
			}

			instance = this;
		}

		public override void AddRecipes()
		{
		}

		public override void UpdateMusic(ref int music)
		{
			Player player = Main.LocalPlayer;

			//Don't override the songs in this list!
			int[] NoOverride = {MusicID.Boss1, MusicID.Boss2, MusicID.Boss3, MusicID.Boss4, MusicID.Boss5,
				MusicID.LunarBoss, MusicID.PumpkinMoon, MusicID.TheTowers, MusicID.FrostMoon, MusicID.GoblinInvasion,
				MusicID.PirateInvasion, GetSoundSlot(SoundType.Music, "Sounds/Music/CrystalKing")};

			bool playMusic = true;
			foreach (int n in NoOverride)
			{
				if (music == n) playMusic = false;
			}

			if (player.active && player.GetModPlayer<CrystalPlayer>(this).ZoneCrystal && !Main.gameMenu && playMusic)
			{
				music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/CrystallineFlows");
			}
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			CrystiliumModMessageType msgType = (CrystiliumModMessageType)reader.ReadByte();
			switch (msgType)
			{
				case CrystiliumModMessageType.SpawnBossSpecial:
					int dps = reader.ReadInt32();
					NPC.SpawnOnPlayer(whoAmI, NPCType<NPCs.Bosses.CrystalKing>());
					break;
				default:
					ErrorLogger.Log("CrystiliumMod: Unknown Message type: " + msgType);
					break;
			}
		}
	}

	enum CrystiliumModMessageType : byte
	{
		SpawnBossSpecial,
	}
}