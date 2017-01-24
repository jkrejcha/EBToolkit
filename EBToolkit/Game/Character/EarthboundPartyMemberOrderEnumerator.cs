using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBToolkit.Game.Character
{
	/// <inheritdoc/>
	public class EarthboundPartyMemberOrderEnumerator : IEnumerator<EarthboundPartyMemberType>
	{
		private EarthboundPartyMemberType[] baseArray;
		private int position = -1;

		/// <inheritdoc/>
		public EarthboundPartyMemberOrderEnumerator(EarthboundPartyMemberType[] baseArray)
		{
			this.baseArray = baseArray;
		}

		/// <inheritdoc/>
		public EarthboundPartyMemberType Current
		{
			get
			{
				try
				{
					return baseArray[position];
				}
				catch (IndexOutOfRangeException e)
				{
					throw new InvalidOperationException(null, e);
				}
			}
		}

		/// <inheritdoc/>
		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		/// <inheritdoc/>
		public void Dispose()
		{
			// do nothing?
		}

		/// <inheritdoc/>
		public bool MoveNext()
		{
			position++;
			return position < baseArray.Length;
		}

		/// <inheritdoc/>
		public void Reset()
		{
			position = -1;
		}
	}
}
