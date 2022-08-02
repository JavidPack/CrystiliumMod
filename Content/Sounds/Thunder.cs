﻿using Microsoft.Xna.Framework.Audio;
using Terraria;

namespace CrystiliumMod.Content.Sounds
{
	public class Thunder : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		{
			soundInstance = sound.CreateInstance();
			soundInstance.Volume = volume * .5f;
			soundInstance.Pan = pan;
			soundInstance.Pitch = Main.rand.Next(-6, 7) / 30f;
			return soundInstance;
		}
	}
}