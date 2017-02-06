using System;

namespace EBToolkit.Game.Character
{
	/// <summary>
	/// Base class for representing a character (playable, NPC, or foe) in
	/// EarthBound. NPCs are treated the same as enemies
	/// </summary>
	/// <seealso cref="EarthboundPartyMember"/>
	/// <seealso cref="EarthboundEnemy"/>
	public abstract class EarthboundCharacter
	{
		/// <summary>
		/// The minimum value for <see cref="GetGutsChance"/>
		/// </summary>
		public const double MinimumGutsChance = 1.0 / 20.0;

		/// <summary>
		/// Represents the name that is given to this character. This is either fixed
		/// (for NPCs and enemies) or chosen at the start of the game (for PCs). The
		/// limit on length is determined by the game (EarthBound has a longer limit
		/// than Mother 2) and whether this character is an NPC/enemy (enemies can have
		/// longer names than playable characters).
		/// </summary>
		public string Name;

		/// <summary>
		/// Health points. When the <see cref="RollingStat.RollingValue"/> is 0, this
		/// character becomes <see cref="PermanentStatusEffect.Unconsciousness">unconscious</see>.
		/// <seealso cref="PP"/>
		/// <seealso cref="RollingStat"/>
		/// </summary>
		public RollingStat HP;

		/// <summary>
		/// Psychic points. This is required for any character to use PSI abilities.
		/// </summary>
		/// <remarks>
		/// If a character attempts to use a PSI ability without having enough PP,
		/// a message stating that will be displayed. Also, haha PP.
		/// </remarks>
		public RollingStat PP;

		/// <summary>
		/// Offense. Coorelates to how much damage a physical (non-PSI) attack such as
		/// "Bash" or "Shoot" will do. This can be changed by equipping certain items.
		/// </summary>
		/// <remarks>
		/// Because this does not affect PSI or certain types of attacks but are rather
		/// based on fixed values, a character with a very low Offense can still deal
		/// a large amount of damage for these types of attacks.
		/// </remarks>
		public EquipmentChangeableStat Offense;

		/// <summary>
		/// Defense. Coorelates to how much protection from attacks this character has.
		/// This is not used for items that suck HP away and in some scenarios.
		/// </summary>
		public EquipmentChangeableStat Defense;

		/// <summary>
		/// Speed. Affects turn order. In addition, for <see cref="EarthboundPartyMember"/>s,
		/// it affects the run away chance, instant wins, and the chance that
		/// bottle rockets will succeed.
		/// </summary>
		public EquipmentChangeableStat Speed;
		//TODO: Document the rest of the stats.
		/// <summary>
		/// Guts. Affects the rate of SMAAAASH! attacks and the ability to survive
		/// mortal damage for a <see cref="EarthboundPartyMember">playable character</see>
		/// or NPC.
		/// </summary>
		public EquipmentChangeableStat Guts;

		/// <summary>
		/// Luck. Affects whether certain PSI moves and offensive items will work.
		/// This also affects whether attacks that can <see cref="PermanentStatusEffect.Diamondization">diamondize</see>
		/// will succeed.
		/// </summary>
		public EquipmentChangeableStat Luck;

		/// <summary>
		/// The level a character is at. This affects whether a certain enemy
		/// will run from the playable characters.
		/// </summary>
		public byte Level;

		/// <summary>
		/// Experience points that the character has or will be split among
		/// the <see cref="EarthboundParty">party</see> on defeat.
		/// </summary>
		public uint Experience;

		/// <summary>
		/// The <see cref="PermanentStatusEffect"/> that this character currently
	    /// has. 
		/// </summary>
		public PermanentStatusEffect PermanentStatusEffect;

		/// <summary>
		/// The <see cref="PossessionStatus"/> that this character currently has.
		/// </summary>
		public PossessionStatus PossessionStatus;

		/// <summary>
		/// Whether this character is "feeling strange". If a character is
		/// feeling strange, they may attack an unintended target.
		/// </summary>
		public bool FeelingStrange;

		/// <summary>
		/// When non-zero, the character will not be able to use psychic abilities.
		/// A message saying "But it didn't work very well." will show after trying
		/// to use PSI.
		/// </summary>
		/// <remarks>
		/// The range in-game for this value is 0-4.
		/// </remarks>
		public byte CantConcentrateTurns;

		/// <summary>
		/// Whether this character is homesick. If <see langword="true"/>, the
		/// character may spend turns thinking about the favorite food.
		/// </summary>
		public bool Homesick;

		public BattleStatusEffect BattleStatusEffect;

		/// <summary>
		/// Gets an estimated chance of surviving mortal damage (for PCs/NPCs)
		/// and for SMAAAASH! attacks (for physical Bash type attacks).
		/// </summary>
		/// <returns><see cref="Guts"/>/500 or 1/20, whichever is higher</returns>
		/// <seealso cref="Guts"/>
		/// <remarks>
		/// This function is adapted from the equation on the <a href="https://starmen.net/mother2/gameinfo/technical/equations.php">Starmen.net equations page</a>.
		/// </remarks>
		public double GetGutsChance()
		{
			return Math.Max((double)(this.Guts / 500d), MinimumGutsChance);
		}

		/// <summary>
		/// Gets whether this character is currently conscious.
		/// </summary>
		public bool Conscious
		{
			get { return PermanentStatusEffect != PermanentStatusEffect.Unconsciousness; }
		}
	}

	/// <summary>
	/// A status effect that is applied to this <see cref="EarthboundCharacter">character</see>
	/// permanently (or until a higher level status effect overrides or a
	/// healing heals it away). This can work in conjunction with a 
	/// <see cref="PossessionStatus"/>.
	/// </summary>
	/// <remarks>
	/// In EarthBound, with the exception of <see cref="Normal"/>, the lower
	/// numbered status effects take precedence over higher numbered ones. This
	/// means that, for example, a <see cref="EarthboundCharacter"/> who has
	/// <see cref="Paralysis"/> cannot get <see cref="Sunstroke"/> or a
	/// <see cref="Cold"/>. This also means that a character who, for example,
	/// has <see cref="Nausea"/> can get <see cref="Paralysis"/> or another
	/// higher level status effect.
	/// </remarks>
	/// <seealso cref="PossessionStatus"/>
	public enum PermanentStatusEffect : byte
	{
		/// <summary>
		/// Everything is normal and happy. :)
		/// </summary>
		Normal = 0,
		/// <summary>
		/// A status effect that occurs when <see cref="EarthboundCharacter.HP"/>
		/// drops to 0. There is a different overworld sprite, items cannot be used,
		/// and they do not have a turn in battle.
		/// </summary>
		Unconsciousness = 1,
		/// <summary>
		/// A status effect caused by some enemies that is similar to <see cref="Unconsciousness"/>
		/// however does not change <see cref="EarthboundCharacter.HP"/>
		/// </summary>
		Diamondization = 2,
		/// <summary>
		/// A status effect that makes this character unable to use non-PSI
		/// moves in battle and makes them unable to use items.
		/// </summary>
		Paralysis = 3,
		/// <summary>
		/// A status effect that deals high level damage every turn and every
		/// few seconds out of battle
		/// </summary>
		/// <seealso cref="Poison"/>
		/// <seealso cref="Sunstroke"/>
		/// <seealso cref="Cold"/>
		Nausea = 4,
		/// <summary>
		/// A status effect that deals high level damage every turn and every
		/// few seconds out of battle.
		/// </summary>
		/// <seealso cref="Nausea"/>
		/// <seealso cref="Sunstroke"/>
		/// <seealso cref="Cold"/>
		Poison = 5,
		/// <summary>
		/// A status effect that deals low level damage every turn and every
		/// few seconds out of battle
		/// </summary>
		/// <seealso cref="Nausea"/>
		/// <seealso cref="Poison"/>
		/// <seealso cref="Cold"/>
		Sunstroke = 6,
		/// <summary>
		/// A status effect that deals low level damage every turn and every 
		/// few seconds out of battle
		/// </summary>
		/// <seealso cref="Nausea"/>
		/// <seealso cref="Poison"/>
		/// <seealso cref="Sunstroke"/>
		Cold = 7,
	}

	/// <summary>
	/// A status effect that is applied to this <see cref="EarthboundCharacter">character</see>
	/// permanently (or until a higher level status effect overrides or a
	/// healing heals it away). This can work in conjunction with a 
	/// <see cref="PermanentStatusEffect"/>.
	/// </summary>
	/// <remarks>
	/// In EarthBound, with the exception of <see cref="Normal"/>, the lower
	/// numbered status effects take precedence over higher numbered ones. This
	/// means that, for example, a <see cref="EarthboundCharacter"/> who is
	/// <see cref="Mushroomization">mushroomized</see> cannot be
	/// <see cref="Possession">possessed</see>, however the other way around works.
	/// </remarks>
	public enum PossessionStatus : byte
	{
		/// <summary>
		/// Everything is normal and happy. :)
		/// </summary>
		Normal = 0,
		/// <summary>
		/// Whether this character is mushroomized/mashroomized. If this
		/// is present, similar effects to the "feeling strange" status
		/// effect occur in battle. Overworld directional controls are also
		/// changed every period of time.
		/// </summary>
		Mushroomization = 1,
		/// <summary>
		/// Whether this character is possessed. Represents whether the 
		/// Tiny Lil' Ghost is present.
		/// </summary>
		/// <remarks>
		/// oOoOoOo SPOOKY!
		/// </remarks>
		Possession = 2,
	}

	/// <summary>
	/// A status effect that is applied to this <see cref="EarthboundCharacter">character</see>
	/// for the duration of a battle (or until a higher level status effect
	/// overrides or healing heals it away). This can work in conjunction with
	/// a <see cref="PermanentStatusEffect"/> and <see cref="PossessionStatus"/>.
	/// </summary>
	/// <remarks>
	/// In EarthBound, with the exception of <see cref="Normal"/>, the lower
	/// numbered status effects take precedence over higher numbered ones. This
	/// means that, for example, a <see cref="EarthboundCharacter"/> who is
	/// </remarks>
	public enum BattleStatusEffect : byte
	{
		/// <summary>
		/// Everything is normal and happy :)
		/// </summary>
		Normal = 0,
		/// <summary>
		/// The character is asleep. The character cannot select an action
		/// during battle.
		/// </summary>
		/// <remarks>
		/// In EarthBound, the chance of waking up on a turn is 25%. Being hit 
		/// with a physical attack that does not SMAAAASH! causes a 50% chance
		/// of waking up.
		/// </remarks>
		Asleep = 1,
		/// <summary>
		/// Increases the miss rate for physical attacks by 8/16 (50%).
		/// </summary>
		Crying = 2,
		/// <summary>
		/// Causes the same effects as <see cref="PermanentStatusEffect.Paralysis"/>.
		/// An immobilized character has an 85% of being able to move freely on
		/// their turn.
		/// </summary>
		Immobilization = 3,
		/// <summary>
		/// Similar to <see cref="Asleep"/>, however this only lasts for one
		/// turn.
		/// </summary>
		Solidification = 4,
	}
}
