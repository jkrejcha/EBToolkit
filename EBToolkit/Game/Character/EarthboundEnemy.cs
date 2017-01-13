using EBToolkit.Game.Inventory;
using System;

namespace EBToolkit.Game.Character
{
	/// <summary>
	/// Represents an enemy that can be in battle in EarthBound
	/// </summary>
	public class EarthboundEnemy : EarthboundCharacter
	{
		/// <summary>
		/// Whether the word "the" is appended to the front of the enemy's name
		/// in battle. For example, if set to true, a battle message may say something
		/// similar to "The 'Enemy Name' attacks!" instead of "'Enemy Name' attacks!".
		/// </summary>
		public bool TheFlag;
		/// <summary>
		/// How much money is gained on defeat of this enemy
		/// </summary>
		public ushort Money;
		/// <summary>
		/// Represents the drop frequency of <see cref="DroppedItem"/> 
		/// </summary>
		/// <seealso cref="DroppedItem"/>
		public ItemDropFrequency DropFrequency;
		/// <summary>
		/// What the dropped item will be
		/// </summary>
		public Item DroppedItem;
		/// <summary>
		/// Whether a <see cref="EarthboundPartyMember"/> can run away from this
		/// enemy
		/// </summary>
		public bool CanRunAwayFrom;

		/// <summary>
		/// Gets the chance that an enemy will drop an item.
		/// </summary>
		/// <returns>A <see cref="double"/> representing <see cref="DropFrequency"/>/128</returns>
		public double GetItemDropChance()
		{
			return Math.Pow(2, (double)DropFrequency) / 128d;
		}

		/// <summary>
		/// The gender of the enemy. This affects some battle action text.
		/// </summary>
		public enum Gender : byte
		{
			/// <summary>
			/// A gender-neutral enemy
			/// </summary>
			Neutral = 0,
			/// <summary>
			/// An enemy which uses male pronouns (his, him, etc)
			/// </summary>
			Male = 1,
			/// <summary>
			/// An enemy which uses female pronouns (her, etc)
			/// </summary>
			Female = 2,
		}

		/// <summary>
		/// The type of enemy that this enemy is. This affects whether some
		/// offensive items will work against this enemy
		/// </summary>
		public enum EnemyType : byte
		{
			/// <summary>
			/// A normal enemy that is not an insect type or mechanical
			/// </summary>
			Normal = 0,
			/// <summary>
			/// An insect type enemy. Some offensive items can affect enemies 
			/// of this type.
			/// </summary>
			Insect = 1,
			/// <summary>
			/// A metal type enemy. Some offensive items can affect enemies of
			/// this type.
			/// </summary>
			Metal = 2,
		}

		/// <summary>
		/// Item drop frequency, expressed as a fraction over 128. One thing to note
		/// is that the byte representations of these values are not the values themselves
		/// but rather in the form of 2^<see cref="ItemDropFrequency"/>'s power.
		/// </summary>
		/// <seealso cref="EarthboundEnemy.GetItemDropChance"/>
		public enum ItemDropFrequency : byte
		{
			/// <summary>
			/// A drop chance of 1/128
			/// </summary>
			One = 0,
			/// <summary>
			/// A drop chance of 2/128 (1/64)
			/// </summary>
			Two = 1,
			/// <summary>
			/// A drop chance of 4/128 (1/32)
			/// </summary>
			Four = 2,
			/// <summary>
			/// A drop chance of 8/128 (1/16)
			/// </summary>
			Eight = 3,
			/// <summary>
			/// A drop chance of 16/128 (1/8)
			/// </summary>
			Sixteen = 4,
			/// <summary>
			/// A drop chance of 32/128 (1/4)
			/// </summary>
			ThirtyTwo = 5,
			/// <summary>
			/// A drop chance of 64/128 (1/2)
			/// </summary>
			SixtyFour = 6,
			/// <summary>
			/// A drop chance of 128/128 (1).
			/// The enemy will always drop the specified item.
			/// </summary>
			OneHundredTwentyEight = 7,
		}
	}

}