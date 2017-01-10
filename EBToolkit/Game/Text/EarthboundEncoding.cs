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

		public override string GetString(byte[] bytes)
		{
			return base.GetString(this.ShiftBytes(bytes, false));
		}

		private byte[] ShiftBytes(byte[] original, bool Positive)
		{
			for (int i = 0; i < original.Length; i++)
			{
				if (Positive)
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
