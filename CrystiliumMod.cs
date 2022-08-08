using System.IO;
using CrystiliumMod.Content.NPCs.Bosses;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod
{
	public class CrystiliumMod : Mod
	{
		public static CrystiliumMod Instance => ModContent.GetInstance<CrystiliumMod>();

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			CrystiliumModMessageType msgType = (CrystiliumModMessageType)reader.ReadByte();
			switch (msgType)
			{
				case CrystiliumModMessageType.SpawnBossSpecial:
					NPC.SpawnOnPlayer(whoAmI, ModContent.NPCType<CrystalKing>());
					break;
				default:
					Logger.Warn("CrystiliumMod: Unknown Message type: " + msgType);
					break;
			}
		}

		public static CrystaliumSpawnCondition SpawnCondition = new CrystaliumSpawnCondition();

		public override void Unload()
        {
			SpawnCondition = null;
		}
    }

	enum CrystiliumModMessageType : byte
	{
		SpawnBossSpecial,
	}
}
