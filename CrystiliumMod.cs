using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod
{
	public class CrystiliumMod : Mod
	{
		internal static CrystiliumMod instance;

		public CrystiliumMod()
		{
			// We need this for the worldgen chest fix.
			if (ModLoader.version < new Version(0, 11, 5))
			{
				throw new Exception("\nThis mod uses functionality only present in the latest tModLoader. Please update tModLoader to use this mod\n\n");
			}

			instance = this;
		}

		public override void Unload()
		{
			instance = null;
		}

		public override void Close() {
			// Fix a tModLoader bug.
			var slots = new int[] {
				GetSoundSlot(SoundType.Music, "Sounds/Music/CrystalKing"),
				GetSoundSlot(SoundType.Music, "Sounds/Music/CrystallineFlows")
			};
			foreach (var slot in slots) {
				if (Main.music[slot].IsPlaying) {
					Main.music[slot].Stop(Microsoft.Xna.Framework.Audio.AudioStopOptions.Immediate);
				}
			}

			base.Close();
		}

		public override void AddRecipes()
		{
		}

		public override void UpdateMusic(ref int music, ref MusicPriority priority) {
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active) {
				return;
			}
			Player player = Main.LocalPlayer;
			if (player.GetModPlayer<CrystalPlayer>().ZoneCrystal)
			{
				// TODO: alt music possibly.
				//var normalMusic = this.GetSoundSlot(SoundType.Music, "Sounds/Music/CrystallineFlows");
				//if(music != normalMusic && Main.rand.NextBool(10))
				music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/CrystallineFlows");
				priority = MusicPriority.BiomeMedium;
			}
		}

		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call("AddBossWithInfo", "Crystal King", 11.8f, (Func<bool>)(() => CrystalWorld.downedCrystalKing), "Right click on a Crystal Fountain with a [i:" + ModContent.ItemType<Items.CrypticCrystal>() + "] in your inventory");
			}
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			CrystiliumModMessageType msgType = (CrystiliumModMessageType)reader.ReadByte();
			switch (msgType)
			{
				case CrystiliumModMessageType.SpawnBossSpecial:
					NPC.SpawnOnPlayer(whoAmI, ModContent.NPCType<NPCs.Bosses.CrystalKing>());
					break;
				default:
					Logger.Warn("CrystiliumMod: Unknown Message type: " + msgType);
					break;
			}
		}
	}

	enum CrystiliumModMessageType : byte
	{
		SpawnBossSpecial,
	}
}