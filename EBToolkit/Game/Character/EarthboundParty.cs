using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBToolkit.Game.Character
{
	/// <summary>
	/// Represents the party of <see cref="EarthboundPartyMember">playable</see>
	/// and non-playable characters.
	/// </summary>
	public class EarthboundParty : EarthboundSaveable
	{
		/// <summary>
		/// The amount of experience "gained" by the party when the playable party
		/// wins and dies at the same time. A <a href="https://en.wikipedia.org/wiki/Division_by_zero">division by zero</a>
		/// error occurs when experience is attempted to split between the zero
		/// alive party members, causing it to underflow to this value. For more
		/// information, please see the
		/// <a href="http://earthboundcentral.com/2009/09/simultaneous-defeat-glitch/">Simultaneous Defeat Glitch</a>
		/// page on EarthBound Central.
		/// </summary>
		/// <remarks>
		/// It is unknown if this value is the same when three or more party 
		/// members as the text window that displays the experience gained
		/// glitches as well. 
		/// </remarks>
		public const uint DeathGlitchExperience = 4294940287;

		/// <summary>
		/// The playable characters there are in EarthBound
		/// </summary>
		public const int PlayableCharacterCount = 4;

		/// <summary>
		/// The party members that are playable characters. All characters, even
		/// if they are unable to be controlled, are part of this. Each element
		/// of this is what is saved in <see cref="WriteDataToStream(BinaryWriter)"/>
		/// </summary>
		public readonly EarthboundPartyMember[] PlayableParty = new EarthboundPartyMember[PlayableCharacterCount];

		/// <summary>
		/// The order of the party members, including those not directly
		/// controlled by the player.
		/// </summary>
		public readonly EarthboundPartyMemberOrder PartyOrder = new EarthboundPartyMemberOrder();

		/// <summary>
		/// Gets the chance that an <see cref="EarthboundCharacter"/> will run
		/// from the playable party. In EarthBound, this is only used for
		/// <see cref="EarthboundEnemy">enemies</see>. This does not apply if an
		/// event flag is set, in which case the enemy will always run away.
		/// </summary>
		/// <param name="Other">The other character to test</param>
		/// <returns>If the sum of levels is greater than <paramref name="Other"/>'s
	    /// level by 10, 1. If eight times, 0.75. If five times 0.5. Otherwise 0.
		/// </returns>
		/// <remarks>
		/// This function is adapted from the equation on the <a href="https://starmen.net/mother2/gameinfo/technical/equations.php">Starmen.net equations page</a>.
		/// </remarks>
		public double GetOutOfBattleRunChance(EarthboundCharacter Other)
		{
			//TODO: Magic number
			if (SumOfLevels > Other.Level * 10) return 1;
			if (SumOfLevels > Other.Level * 8) return 0.75;
			if (SumOfLevels > Other.Level * 5) return 0.5;
			return 0;
		}

		/// <summary>
		/// Gets the amount of experience earned per character on defeat of a
		/// battle group
		/// </summary>
		/// <param name="Group">The battle group to use</param>
		/// <returns>An <see cref="uint"/> representing the amount of experience
		/// each <see cref="EarthboundPartyMember"/> recieves or 
		/// <see cref="DeathGlitchExperience"/> if no consicous members are alive</returns>
		/// <remarks>
		/// Due to a glitch in the programming, a division by zero error can
		/// occur if all playable characters die and win at the same time
		/// (this can happen with enemies that explode upon death).
		/// </remarks>
		/// <seealso cref="GetConsciousCharacters(bool)"/>
		/// <seealso cref="BattleGroup"/>
		/// <seealso cref="BattleGroup.TotalExperience"/>
		/// <seealso cref="DeathGlitchExperience"/>
		public uint GetPerCharacterExperienceOnWin(BattleGroup Group)
		{
			uint Alive = (uint)GetConsciousCharacters().Length;
			if (Alive == 0) return DeathGlitchExperience;
			return Group.TotalExperience / Alive;
		}

		/// <summary>
		/// Gets whether the party can perform an instant win against the enemies
		/// in this battle formation.
		/// </summary>
		/// <param name="Group">The battle group to check against</param>
		/// <param name="SurpriseAttack">Whether this is a surprise attack</param>
		/// <returns>Whether an instant win will be performed</returns>
		/// <remarks>
		/// This function is adapted from the equation on the <a href="https://starmen.net/mother2/gameinfo/technical/equations.php">Starmen.net equations page</a>.
		/// </remarks>
		public bool CanInstantWin(BattleGroup Group, bool SurpriseAttack)
		{
			Contract.Requires<ArgumentNullException>(Group != null);
			EarthboundPartyMember[] NormalCharacters = GetNonAfflictedCharacters();
			if (Group.Enemies.Length > NormalCharacters.Length) return false;
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the characters who are not <see cref="PermanentStatusEffect.Unconsciousness">unconscious</see>
		/// </summary>
		/// <param name="DiscludeDiamondized">Whether to count
		/// <see cref="PermanentStatusEffect.Diamondization"/> as unconsciousness</param>
		/// <returns>An array of playable characters that are not <see cref="PermanentStatusEffect.Unconsciousness">unconscious</see></returns>
		/// <seealso cref="PermanentStatusEffect"/>
		/// <seealso cref="PermanentStatusEffect.Unconsciousness"/>
		/// <seealso cref="PermanentStatusEffect.Diamondization"/>
		/// <seealso cref="EarthboundPartyMember"/>
		public EarthboundPartyMember[] GetConsciousCharacters(bool DiscludeDiamondized = true)
		{
			//TODO: Make this more efficient
			//TODO: Return only characters that are in the current party
			List<EarthboundPartyMember> ConsciousCharacters = PlayableParty.ToList();
			foreach (EarthboundPartyMember PartyMember in PlayableParty)
			{
				if (!PartyMember.Conscious) ConsciousCharacters.Remove(PartyMember);
				if (!DiscludeDiamondized) continue;
				if (PartyMember.PermanentStatusEffect == PermanentStatusEffect.Diamondization)
				{
					ConsciousCharacters.Remove(PartyMember);
				}
			}
			return ConsciousCharacters.ToArray();
		}

		/// <summary>
		/// Gets characters that are not afflicted with a permanent status effect
		/// or a possession of some sort
		/// </summary>
		/// <returns>
		/// An array of <see cref="EarthboundPartyMember"/> that have no status
		/// effect currently applied or is not possessed.
		/// </returns>
		public EarthboundPartyMember[] GetNonAfflictedCharacters()
		{
			//TODO: Document properly.
			//TODO: Probably make this more efficient.
			//TODO: Return only characters that are in the current party
			List<EarthboundPartyMember> NonAfflictedCharacters = PlayableParty.ToList();
			foreach (EarthboundPartyMember PartyMember in PlayableParty)
			{
				if (PartyMember.PermanentStatusEffect != PermanentStatusEffect.Normal)
				{
					NonAfflictedCharacters.Remove(PartyMember);
				}
				if (PartyMember.PossessionStatus != PossessionStatus.Normal)
				{
					NonAfflictedCharacters.Remove(PartyMember);
				}
			}
			return NonAfflictedCharacters.ToArray();
		}

		/// <summary>
		/// Gets the amount of currently playable party members in the current
		/// party
		/// </summary>
		public byte PlayablePartyCount
		{
			get
			{
				return (byte)PartyOrder.PlayableCount;
			}
		}

		/// <summary>
		/// Gets the amount of members in the current active party
		/// </summary>
		public byte PartyCount
		{
			get
			{
				byte Members = 0;
				foreach (EarthboundPartyMemberType PartyMember in PartyOrder)
				{
					if (PartyMember != EarthboundPartyMemberType.None) Members++;
				}
				return Members;
			}
		}

		/// <summary>
		/// A value which is equivalent to each of the playable character's
		/// levels added together
		/// </summary>
		public ushort SumOfLevels
		{
			get
			{
				ushort Level = 0;
				foreach (EarthboundPartyMember PartyMember in PlayableParty) Level += PartyMember.Level;
				return Level;
			}
		}

		/// <summary>
		/// Writes the contents of the party members to <paramref name="Writer"/>.
		/// This does not write any data on the current count of party members or
		/// the ordering they are in.
		/// </summary>
		/// <param name="Writer">The <see cref="BinaryWriter"/> to write to.</param>
		public void WriteDataToStream(BinaryWriter Writer)
		{
			foreach (EarthboundPartyMember PartyMember in PlayableParty)
			{
				PartyMember.WriteDataToStream(Writer);
			}
		}
	}
}
