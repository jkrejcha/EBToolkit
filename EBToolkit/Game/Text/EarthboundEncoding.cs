using System;
using System.Diagnostics.Contracts;
using System.Text;

namespace EBToolkit.Game.Text
{
	/// <summary>
	/// An encoding used in the EarthBound game.
	/// </summary>
	public abstract class EarthboundEncoding : ASCIIEncoding
	{
		/// <summary>
		/// The amount of bytes upward from ASCII that bytes are shifted in this
		/// <see cref="EarthboundEncoding"/>
		/// </summary>
		protected byte ByteShift = 0;

		/// <inheritdoc/>
		public override byte[] GetBytes(string s)
		{
			return this.ShiftBytes(base.GetBytes(s), true);
		}

		/// <summary>
		/// Gets a string padded to a specific size. This has the effect of limiting
		/// the string to be a certain size, and padding with 0x00 (ASCII NUL characters)
		/// if the string is not long enough.
		/// </summary>
		/// <param name="s">String to get bytes for</param>
		/// <param name="size">Size of resulting byte array</param>
		/// <returns>A byte array containing an encoded string, forced to the
		/// limit of <paramref name="size"/></returns>
		public byte[] GetBytesPadded(string s, int size)
		{
			Contract.Requires<ArgumentNullException>(s != null);
			Contract.Requires<ArgumentOutOfRangeException>(size >= 0);
			byte[] finalArray = new byte[size];
			byte[] unpadded = GetBytes(s);
			for (int i = 0; i < finalArray.Length; i++)
			{
				finalArray[i] = unpadded[i];
			}
			return finalArray;
		}

		/// <inheritdoc/>
		public override string GetString(byte[] bytes)
		{
			return base.GetString(this.ShiftBytes(bytes, false));
		}

		/// <summary>
		/// A method that shifts each character's byte by <see cref="ByteShift"/>
		/// </summary>
		/// <param name="original">The original byte array</param>
		/// <param name="positive">Whether to shift in a positive direction</param>
		/// <returns>A shifted array</returns>
		private byte[] ShiftBytes(byte[] original, bool positive)
		{
			for (int i = 0; i < original.Length; i++)
			{
				if (positive)
				{
					original[i] += this.ByteShift;
				}
				else
				{
					if (original[i] < ByteShift)
					{
						original[i] = 0;
					}
					else
					{
						original[i] -= ByteShift;
					}
				}
			}
			return original;
		}
	}
}
