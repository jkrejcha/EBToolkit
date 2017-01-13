using System;
using System.Collections.Generic;
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
		/// The playable characters there are in EarthBound
		/// </summary>
		public const int PlayableCharacterCount = 4;
		/// <summary>
		/// The maximum amount of characters that can be part of the party
		/// </summary>
		public const int MaxPartyCount = 6;
		/// <summary>
		/// The party members that are playable characters. All characters, even
		/// if they are unable to be controlled, are part of this. Each element
		/// of this is what is saved in <see cref="WriteDataToStream(BinaryWriter)"/>
		/// </summary>
		public readonly EarthboundPartyMember[] PlayableParty = new EarthboundPartyMember[PlayableCharacterCount];

		/// <summary>
		/// Gets the chance that an <see cref="EarthboundCharacter"/> will run from
		/// the playable party. In EarthBound, this is only used for <see cref="EarthboundEnemy">enemies</see>.
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
		/// <returns>An <see cref="int"/> representing the amount of experience
		/// each <see cref="EarthboundPartyMember"/> recieves</returns>
		public int GetPerCharacterExperienceOnWin(BattleGroup Group)
		{
            //TODO: If no alive characters...
			return Group.TotalExperience / GetConsciousCharacters().Count();
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
			if (Group.Enemies.Length > GetNonAfflictedCharacters().Length) return false;
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the characters who are not <see cref="PermanentStatusEffect.Unconsciousness">unconscious</see>
		/// </summary>
		/// <param name="CountDiamondizationAsUnconsciousness">Whether to count
		/// <see cref="PermanentStatusEffect.Diamondization"/> as unconsciousness</param>
		/// <returns>An array of playable characters that are not <see cref="PermanentStatusEffect.Unconsciousness">unconscious</see></returns>
		/// <seealso cref="PermanentStatusEffect"/>
		/// <seealso cref="PermanentStatusEffect.Unconsciousness"/>
		/// <seealso cref="PermanentStatusEffect.Diamondization"/>
		/// <seealso cref="EarthboundPartyMember"/>
		public EarthboundPartyMember[] GetConsciousCharacters(bool CountDiamondizationAsUnconsciousness = true)
		{
			//TODO: Make this more efficient
			//TODO: Return only characters that are in the current party
			List<EarthboundPartyMember> ConsciousCharacters = PlayableParty.ToList();
			foreach (EarthboundPartyMember PartyMember in PlayableParty)
			{
				if (PartyMember.PermanentStatusEffect == PermanentStatusEffect.Unconsciousness)
				{
					ConsciousCharacters.Remove(PartyMember);
				}
				if (!CountDiamondizationAsUnconsciousness) continue;
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
		/// <returns></returns>
		public EarthboundPartyMember[] GetNonAfflictedCharacters()
		{
			//TODO: Document.
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

		public int SumOfLevels
		{
			get
			{
				int Level = 0;
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
