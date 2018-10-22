using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBToolkit.Game.Character
{
	/// <summary>
	/// A class representing the order of current party members of an
	/// <see cref="EarthboundParty"/>.
	/// </summary>
	public class EarthboundPartyMemberOrder : IList<EarthboundPartyMemberType>
	{
		/// <summary>
		/// The underlying array that is used to store the party member order
		/// in memory.
		/// </summary>
		private EarthboundPartyMemberType[] baseArray = new EarthboundPartyMemberType[MaxPartyCount];
		/// <summary>
		/// The maximum amount of characters that can be part of the party
		/// </summary>
		public const int MaxPartyCount = 6;

		/// <summary>
		/// Gets an array of <see cref="EarthboundPartyMemberType"/> containing
		/// only members who are playable party members.
		/// </summary>
		/// <remarks>
		/// A party member is considered "playable" if 
		/// <see cref="EarthboundPartyMemberTypeExtensions.IsPlayable(EarthboundPartyMemberType)"/>
		/// is <see langword="true"/>.
		/// </remarks>
		public EarthboundPartyMemberType[] PlayableParty
		{
			get
			{
				int playablePartyMemberIndex = 0;
				EarthboundPartyMemberType[] playableParty = new EarthboundPartyMemberType[EarthboundParty.PlayableCharacterCount];
				foreach (EarthboundPartyMemberType partyMember in baseArray)
				{
					if (partyMember.IsPlayable())
					{
						playableParty[playablePartyMemberIndex] = partyMember;
						playablePartyMemberIndex++;
					}
				}
				throw new NotImplementedException();
			}
		}

		/// <inheritdoc/>
		public EarthboundPartyMemberType this[int index]
		{
			get
			{
				return this[index, false];
			}
			set
			{
				this[index, false] = value;
			}
		}

		/// <inheritdoc cref="this[int]"/>
		public EarthboundPartyMemberType this[int index, bool playable = false]
		{
			get
			{
				if (playable)
				{
					return PlayableParty[index];
				}
				return baseArray[index];
			}

			set
			{
				baseArray[index] = value;
			}
		}

		/// <inheritdoc/>
		public int Count
		{
			get
			{
				for (int partyMemberIndex = 0; partyMemberIndex < baseArray.Length; partyMemberIndex++)
				{
					if (this[partyMemberIndex] == EarthboundPartyMemberType.None) return partyMemberIndex;
				}
				return baseArray.Length;
			}
		}

		/// <summary>
		/// Returns the number of playable characters in the current party.
		/// </summary>
		/// <remarks>
		/// This number is limited to <see cref="EarthboundParty.PlayableCharacterCount"/>, the
		/// amount of playable characters in the game.
		/// </remarks>
		public int PlayableCount
		{
			get
			{
				/* We can do this because the chosen four are always the first
				 * members in the party. If we find a non-playable party member,
				 * we can stop.
				 */
				for (int partyMemberIndex = 0; partyMemberIndex < EarthboundParty.PlayableCharacterCount; partyMemberIndex++)
				{
					if (!this[partyMemberIndex].IsPlayable()) return partyMemberIndex;
				}
				return EarthboundParty.PlayableCharacterCount;
			}
		}

		/// <inheritdoc/>
		/// <remarks>
		/// This value is always <see langword="false"/>.
		/// </remarks>
		public bool IsReadOnly
		{
            get => false;
		}

		/// <summary>
		/// Adds a member to the current party. Party members are added and dropped
		/// in this way.
		/// </summary>
		/// <param name="item">The party member to add</param>
		/// <remarks>
		/// This does not actually change the size of the array and will fail
		/// if there is no empty spot to place the new party member.
		/// </remarks>
		public void Add(EarthboundPartyMemberType item)
		{
			Contract.Requires<IndexOutOfRangeException>(Count < MaxPartyCount);
			Contract.Assert(Contains(EarthboundPartyMemberType.None)); // sanity check
			baseArray[IndexOf(EarthboundPartyMemberType.None)] = item;
		}

		/// <summary>
		/// This will clear the entire party. Doing so is VERY dangerous, and
		/// will almost certainly lead to a game-over loop. Callers should know
		/// what they are doing.
		/// </summary>
		public void Clear()
		{
			for (int partyMemberIndex = 0; partyMemberIndex < Count; partyMemberIndex++)
			{
				this[partyMemberIndex] = EarthboundPartyMemberType.None;
			}
		}

		/// <summary>
		/// Gets whether a party member is contained in the current party.
		/// </summary>
		/// <param name="item">The party member to test for</param>
		/// <returns>Whether <paramref name="item"/> is in the current party</returns>
		public bool Contains(EarthboundPartyMemberType item)
		{
			return baseArray.Contains(item);
		}

		/// <inheritdoc/>
		public void CopyTo(EarthboundPartyMemberType[] array, int arrayIndex)
		{
            array.CopyTo(baseArray, arrayIndex);
		}

		/// <inheritdoc/>
		public IEnumerator<EarthboundPartyMemberType> GetEnumerator()
		{
			return new EarthboundPartyMemberOrderEnumerator(baseArray);
		}

		/// <inheritdoc/>
		public int IndexOf(EarthboundPartyMemberType item)
		{
			for (int i = 0; i < baseArray.Length; i++)
			{
				if (item == this[i]) return i;
			}
			return -1;
		}

		/// <inheritdoc/>
		public void Insert(int index, EarthboundPartyMemberType item)
		{
			Contract.Requires<ArgumentOutOfRangeException>(index >= 0);
			Contract.Requires<ArgumentOutOfRangeException>(index < baseArray.Length);
			Contract.Requires<IndexOutOfRangeException>(index < Count);
			Contract.Requires<InvalidOperationException>(Count < baseArray.Length);
			// implementation here
			Contract.Ensures(Count <= baseArray.Length);
			throw new NotImplementedException();
		}

		/// <inheritdoc/>
		public bool Remove(EarthboundPartyMemberType item)
		{
			if (!Contains(item)) return false;
			RemoveAt(IndexOf(item));
			return true;
		}

		/// <inheritdoc/>
		public void RemoveAt(int index)
		{
			Contract.Requires<IndexOutOfRangeException>(index < Count);
			Contract.Requires<ArgumentOutOfRangeException>(index >= 0 && index < MaxPartyCount);
			baseArray[index] = EarthboundPartyMemberType.None;
			Contract.Ensures(Count < MaxPartyCount);
		}

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return baseArray.GetEnumerator();
		}
	}
}
