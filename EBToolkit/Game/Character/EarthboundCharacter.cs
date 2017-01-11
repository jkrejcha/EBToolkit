using System;
namespace EBToolkit.Game.Character
{
	/// <summary>
	/// Represents a character (playable, NPC, or foe) in EarthBound
	/// </summary>
	public class EarthboundCharacter
	{
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
		/// Guts.
		/// </summary>
		public EquipmentChangeableStat Guts;

		public EquipmentChangeableStat Luck;

		public byte Level;

		public int Experience;

		public PermanentStatusEffect PermanentStatusEffect;

		public PossessionStatus PossessionStatus;

		/// <summary>
		/// Gets an estimated chance of surviving mortal damage (for PCs/NPCs)
		/// and for SMAAAASH! attacks (for physical Bash type attacks).
		/// </summary>
		/// <returns><see cref="Guts"/>/500 or 1/20, whichever is higher</returns>
		/// <seealso cref="Guts"/>
		public double GetGutsChance()
		{
			// Taken from Starmen.net
			return Math.Max((double)(this.Guts / 500), 1.0 / 20);
		}
	}
	
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
		//TODO: Document the other Permanent Status Effects
		Nausea = 4,
		Poison = 5,
		Sunstroke = 6,
		Cold = 7,
	}

	public enum PossessionStatus : byte
	{
		/// <summary>
		/// Everything is normal and happy. :)
		/// </summary>
		Normal,
		/// <summary>
		/// Whether this character is mushroomized/mashroomized. If this
		/// is present, similar effects to the "feeling strange" status
		/// effect occur in battle. Overworld directional controls are also
		/// changed every period of time.
		/// </summary>
		Mushroomization,
		/// <summary>
		/// Whether this character is possessed. Represents whether the 
		/// Tiny Lil' Ghost is present.
		/// </summary>
		/// <remarks>
		/// oOoOoOo SPOOKY!
		/// </remarks>
		Possession,
	}
}
