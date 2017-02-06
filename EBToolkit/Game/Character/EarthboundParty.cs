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
		/// Minimum chance that the party can run away. While in practice this
		/// value could be lower than this number, a value less than this isn't
		/// any more useful and doesn't make much sense.
		/// </summary>
		public const double MinimumRunChance = 0.0;

		/// <summary>
		/// Maximum chance that the party can run away. While in practice this
		/// value could be higher than this number, a value greater than this
		/// isn't any more useful and doesn't make much sense.
		/// </summary>
		public const double MaximumRunChance = 1.0;

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
		/// Gets the chance that the party will successfully run away from a
		/// battle group. The minimum chance is defined by <see cref="MinimumRunChance"/>
		/// and the maximum by <see cref="MaximumRunChance"/>. This will get
		/// the lowest chance from every enemy in the group.
		/// </summary>
		/// <param name="group">Group to get run chance for</param>
		/// <param name="turnNumber">Turn number in battle</param>
		/// <returns>
		/// A <see cref="Double"/> value representing a chance that the current
		/// party will run away from <paramref name="group"/>.
		/// </returns>
		/// <seealso cref="GetRunAwayChance(EarthboundEnemy, int)"/>
		/// <remarks>
		/// This function is adapted from the equation on the <a href="https://starmen.net/mother2/gameinfo/technical/equations.php">Starmen.net equations page</a>.
		/// </remarks>
		public double GetRunAwayChance(BattleGroup group, int turnNumber)
		{
			double runAwayChance = MaximumRunChance;
			foreach (EarthboundEnemy enemy in group.Enemies)
			{
				double enemyChance = GetRunAwayChance(enemy, turnNumber);
				runAwayChance = Math.Min(enemyChance, runAwayChance);
				// no point in continuing if there's no chance of going lower
				if (runAwayChance == MinimumRunChance) return runAwayChance;
			}
			return runAwayChance;
		}

		/// <summary>
		/// Gets the chance that the party will successfully run away from an
		/// enemy. The minimum chance is defined by <see cref="MinimumRunChance"/>
		/// and the maximum by <see cref="MaximumRunChance"/>.
		/// </summary>
		/// <param name="enemy">Enemy to get run chance for</param>
		/// <param name="turnNumber">Turn number in battle</param>
		/// <returns>
		/// A <see cref="Double"/> value representing a chance that the current
		/// party will run away from <paramref name="enemy"/>. If
		/// <see cref="EarthboundEnemy.CanRunAwayFrom"/> is <see langword="false"/>,
		/// <see cref="MinimumRunChance"/>.
		/// </returns>
		/// <seealso cref="GetRunAwayChance(BattleGroup, int)"/>
		/// <remarks>
		/// This function is adapted from the equation on the <a href="https://starmen.net/mother2/gameinfo/technical/equations.php">Starmen.net equations page</a>.
		/// </remarks>
		public double GetRunAwayChance(EarthboundEnemy enemy, int turnNumber)
		{
			if (!enemy.CanRunAwayFrom) return MinimumRunChance;
			double chance = MinimumRunChance;
			byte speed = Byte.MinValue;
			foreach (EarthboundPartyMember partyMember in PlayableParty)
			{
				speed = Math.Max(speed, partyMember.Speed.Value);
			}
			chance = (speed - enemy.Speed.Value + 10.0 * turnNumber) / 100.0;
			// Constrain values to ensure contract is met
			chance = Math.Max(Math.Min(chance, MaximumRunChance), MinimumRunChance);
			Contract.Ensures(!Double.IsNaN(chance)); // it is a number! :)
			Contract.Ensures(chance >= MinimumRunChance); // minimum chance is 0%
			Contract.Ensures(chance <= MaximumRunChance); // maximum chance is 100%
			return chance;
		}

		/// <summary>
		/// Gets the chance that an <see cref="EarthboundCharacter"/> will run
		/// from the playable party. In EarthBound, this is only used for
		/// <see cref="EarthboundEnemy">enemies</see>. This does not apply if an
		/// event flag is set, in which case the enemy will always run away.
		/// </summary>
		/// <param name="other">The other character to test</param>
		/// <returns>If the sum of levels is greater than <paramref name="other"/>'s
	    /// level by 10, 1. If eight times, 0.75. If five times 0.5. Otherwise 0.
		/// </returns>
		/// <remarks>
		/// This function is adapted from the equation on the <a href="https://starmen.net/mother2/gameinfo/technical/equations.php">Starmen.net equations page</a>.
		/// </remarks>
		public double GetOutOfBattleRunChance(EarthboundCharacter other)
		{
			//TODO: Magic number
			if (SumOfLevels > other.Level * 10) return 1;
			if (SumOfLevels > other.Level * 8) return 0.75;
			if (SumOfLevels > other.Level * 5) return 0.5;
			return 0;
		}

		/// <summary>
		/// Gets the amount of experience earned per character on defeat of a
		/// battle group
		/// </summary>
		/// <param name="group">The battle group to use</param>
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
		public uint GetPerCharacterExperienceOnWin(BattleGroup group)
		{
			uint alive = (uint)ConsciousCharacters.Length;
			if (alive == 0) return DeathGlitchExperience;
			return group.TotalExperience / alive;
		}

		/// <summary>
		/// Gets whether the party can perform an instant win against the enemies
		/// in this battle formation.
		/// </summary>
		/// <param name="group">The battle group to check against</param>
		/// <param name="surpriseAttack">Whether this is a surprise attack</param>
		/// <returns>Whether an instant win will be performed</returns>
		/// <remarks>
		/// This function is adapted from the equation on the <a href="https://starmen.net/mother2/gameinfo/technical/equations.php">Starmen.net equations page</a>.
		/// </remarks>
		public bool CanInstantWin(BattleGroup group, bool surpriseAttack)
		{
			Contract.Requires<ArgumentNullException>(group != null);
			EarthboundPartyMember[] NormalCharacters = NormalStatusCharacters;
			if (group.Enemies.Length > NormalCharacters.Length) return false;
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the characters who are not 
		/// <see cref="PermanentStatusEffect.Unconsciousness">unconscious</see>
		/// </summary>
		/// <param name="discludeDiamondized">Whether to count
		/// <see cref="PermanentStatusEffect.Diamondization"/> as unconsciousness</param>
		/// <returns>
		/// An array of playable characters that are not 
		/// <see cref="PermanentStatusEffect.Unconsciousness">unconscious</see>
		/// </returns>
		/// <seealso cref="PermanentStatusEffect"/>
		/// <seealso cref="PermanentStatusEffect.Unconsciousness"/>
		/// <seealso cref="PermanentStatusEffect.Diamondization"/>
		/// <seealso cref="EarthboundPartyMember"/>
		public EarthboundPartyMember[] GetConsciousCharacters(bool discludeDiamondized = true)
		{
			return CurrentPlayableParty.Where(member => member.Conscious &&
														(!discludeDiamondized || member.PermanentStatusEffect == PermanentStatusEffect.Diamondization)).ToArray();
		}

		//TODO: Document
		public EarthboundPartyMember[] ConsciousCharacters
		{
			get
			{
				return GetConsciousCharacters();
			}
		}

		/// <summary>
		/// Gets characters that are not afflicted with a permanent status effect
		/// or a possession of some sort
		/// </summary>
		public EarthboundPartyMember[] NormalStatusCharacters
		{
			get
			{
				return CurrentPlayableParty.Where(member => member.PermanentStatusEffect == PermanentStatusEffect.Normal &&
															member.PossessionStatus == PossessionStatus.Normal).ToArray();
			}
		}

		/// <summary>
		/// Gets the members of the playable party that are currently in the
		/// party
		/// </summary>
		public EarthboundPartyMember[] CurrentPlayableParty
		{
			get
			{
				EarthboundPartyMember[] party = new EarthboundPartyMember[PlayablePartyCount];
				for (byte i = 0; i < PlayablePartyCount; i++)
				{
					party[i] = PlayableParty[i];
				}
				return party;
			}
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
				return (byte)PartyOrder.Count;
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
				ushort level = 0;
				foreach (EarthboundPartyMember PartyMember in PlayableParty) level += PartyMember.Level;
				return level;
			}
		}

		/// <summary>
		/// Writes the contents of the party members to <paramref name="Writer"/>.
		/// This does not write any data on the current count of party members or
		/// the ordering they are in.
		/// </summary>
		/// <param name="Writer">The <see cref="BinaryWriter"/> to write to.</param>
		public void WriteDataToStream(BinaryWriter writer)
		{
			foreach (EarthboundPartyMember partyMember in PlayableParty)
			{
				partyMember.WriteDataToStream(Writer);
			}
		}
	}
}
