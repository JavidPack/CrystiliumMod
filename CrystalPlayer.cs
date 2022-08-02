using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace CrystiliumMod
{
	public class CrystalPlayer : ModPlayer
	{
		public float critDmgMult = 1f;
		public bool CrystalAcc = false;
		public int constantDamage = 0;
		public float percentDamage = 0f;
		public float defenseEffect = -1f;
		public bool crystalCharm = false;
		public int crystalCharmStacks = 0;

		// TODO, need to sync this data?
		public bool ZoneCrystal = false;

		public bool crystalFountain = false;

		public override void ResetEffects()
		{
			critDmgMult = 1f;
			constantDamage = 0;
			percentDamage = 0f;
			defenseEffect = -1f;
			CrystalAcc = false;
			crystalCharm = false;
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit, int cooldownCounter)
		{
			if (CrystalAcc)
			{
				SoundEngine.PlaySound(SoundID.Item27, Player.position);
				for (int h = 0; h < 20; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(Player.Center.X, Player.Center.Y, vel.X, vel.Y, Mod.Find<ModProjectile>("Shatter" + (1 + Main.rand.Next(0, 3))).Type, 20, 0, Player.whoAmI);
				}
			}
		}

		private void ApplyCritBonus(ref int damage, ref bool crit)
		{
			if (crit)
			{
				damage = (int)(damage * critDmgMult);
			}
		}

		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			ApplyCritBonus(ref damage, ref crit);
		}

		public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			ApplyCritBonus(ref damage, ref crit);
		}

		public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit)
		{
			ApplyCritBonus(ref damage, ref crit);
		}

		public override void ModifyHitPvpWithProj(Projectile proj, Player target, ref int damage, ref bool crit)
		{
			ApplyCritBonus(ref damage, ref crit);
		}

		private void UpdateCharmBuff(NPC npc)
		{
			//only do this stuff if wearing accessory
			if (crystalCharm)
			{
				//add buff, update stacks
				int buffIdx = Player.FindBuffIndex(BuffType<Buffs.CrystalCharm>());
				if (buffIdx < 0)
				{
					Player.AddBuff(BuffType<Buffs.CrystalCharm>(), 120);
					crystalCharmStacks = 1;
					//1/3 chance to increase stack each hit
				}
				else if (crystalCharmStacks < 25 && Main.rand.Next(2) == 0)
				{
					crystalCharmStacks += 1;
				}

				//reset buff time
				if (buffIdx > -1)
				{
					Player.buffTime[buffIdx] = 120;
				}
			}
		}

		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			UpdateCharmBuff(target);
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			UpdateCharmBuff(target);
		}

		public override void UpdateBiomes()
		{
			ZoneCrystal = (CrystalWorld.CrystalTiles > 400);
		}

		// TODO, need MapBackgroundImage
		public override Texture2D GetMapBackgroundImage()
		{
			if (ZoneCrystal)
			{
				//return mod.GetTexture("CrystalBiomeMapBackground");
			}
			return base.GetMapBackgroundImage();
		}

		public override bool CustomBiomesMatch(Player other)
		{
			CrystalPlayer modOther = other.GetModPlayer<CrystalPlayer>();
			return ZoneCrystal == modOther.ZoneCrystal;
		}

		public override void CopyCustomBiomesTo(Player other)
		{
			CrystalPlayer modOther = other.GetModPlayer<CrystalPlayer>();
			modOther.ZoneCrystal = ZoneCrystal;
		}

		public override void SendCustomBiomes(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = ZoneCrystal;
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			ZoneCrystal = flags[0];
		}

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
		{
			if (constantDamage > 0 || percentDamage > 0f)
			{
				int damageFromPercent = (int)(Player.statLifeMax2 * percentDamage);
				damage = Math.Max(constantDamage, damageFromPercent);
				customDamage = true;
			}
			else if (defenseEffect >= 0f)
			{
				if (Main.expertMode)
				{
					defenseEffect *= 1.5f;
				}
				damage -= (int)(Player.statDefense * defenseEffect);
				if (damage < 0)
				{
					damage = 1;
				}
				customDamage = true;
			}
			constantDamage = 0;
			percentDamage = 0f;
			defenseEffect = -1f;
			return true;
		}

		public override void PreUpdateBuffs()
		{
			if (crystalFountain)
			{
				Player.AddBuff(BuffType<Buffs.CrystalHealing>(), 2);
			}
		}

		public override void PostUpdateBuffs()
		{
			if (Player.FindBuffIndex(BuffType<Buffs.CrystalCharm>()) < 0)
			{
				crystalCharmStacks = 0;
			}
		}
	}
}