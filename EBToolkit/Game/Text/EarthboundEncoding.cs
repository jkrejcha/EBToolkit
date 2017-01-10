using System;
using System.Text;

namespace EBToolkit.Game.Text
{
	/// <summary>
	/// An encoding used in the EarthBound game.
	/// </summary>
	public abstract class EarthboundEncoding : ASCIIEncoding
	{
		protected byte ByteShift = 0;

		public override byte[] GetBytes(string s)
		{
			return this.ShiftBytes(base.GetBytes(s), true);
		}

		public byte[] GetBytesPadded(string s, int size)
		{
			byte[] finalArray = new byte[size];
			byte[] unpadded = GetBytes(s);
			for (int i = 0; i < finalArray.Length; i++)
			{
				finalArray[i] = unpadded[i];
			}
			return finalArray;
		}

		public override string GetString(byte[] bytes)
		{
			return base.GetString(this.ShiftBytes(bytes, false));
		}

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
