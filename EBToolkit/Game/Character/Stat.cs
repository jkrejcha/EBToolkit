using System;

namespace EBToolkit.Game.Character
{
	/// <summary>
	/// Represents a statistic in the game.
	/// </summary>
	public class Stat
	{
		/// <summary>
		/// The value of this statistic.
		/// </summary>
		public byte Value;

		#region "Operators"
		#region "Comparison Operators"
		/// <summary>
		/// Determines whether the <paramref name="left"/> stat is less than
		/// the <paramref name="right"/> stat.
		/// </summary>
		/// <param name="left">First stat in comparison</param>
		/// <param name="right">Second stat in comparison</param>
		/// <returns>Whether the <see cref="Value"/> of <paramref name="left"/>
		/// is less than <paramref name="right"/></returns>
		public static bool operator <(Stat left, Stat right)
		{
			return left.Value < right.Value;
		}
		/// <summary>
		/// Determines whether the <paramref name="left"/> stat is less than
		/// the value of <paramref name="right"/>.
		/// </summary>
		/// <param name="left">First stat in comparison</param>
		/// <param name="right">Byte to compare to</param>
		/// <returns>Whether the <see cref="Value"/> of <paramref name="left"/>
		/// is less than <paramref name="right"/></returns>
		public static bool operator <(Stat left, byte right)
		{
			return left.Value < right;
		}
		/// <summary>
		/// Determines whether the <paramref name="left"/> stat is greater than
		/// the <paramref name="right"/> stat.
		/// </summary>
		/// <param name="left">First stat in comparison</param>
		/// <param name="right">Second stat in comparison</param>
		/// <returns>Whether the <see cref="Value"/> of <paramref name="left"/>
		/// is greater than <paramref name="right"/></returns>
		public static bool operator >(Stat left, Stat right)
		{
			return left.Value > right.Value;
		}
		/// <summary>
		/// Determines whether the <paramref name="left"/> stat is greater than
		/// the value of <paramref name="right"/>.
		/// </summary>
		/// <param name="left">First stat in comparison</param>
		/// <param name="right">Byte to compare to</param>
		/// <returns>Whether the <see cref="Value"/> of <paramref name="left"/>
		/// is greater than <paramref name="right"/></returns>
		public static bool operator >(Stat left, byte right)
		{
			return left.Value > right;
		}
		#endregion
		#region "Multiplication"
		/// <summary>
		/// Multiplies the value of <paramref name="left"/> with
		/// <paramref name="right"/>
		/// </summary>
		/// <param name="left">Stat to be multiplied</param>
		/// <param name="right">Value to multiply <paramref name="left"/> by</param>
		/// <returns>
		/// The <see cref="Value"/> of <paramref name="left"/> multiplied by <paramref name="right"/>
		/// </returns>
		public static ushort operator *(Stat left, ushort right)
		{
			return (ushort)(left.Value * right);
		}
		#endregion
		#region "Division"
		/// <summary>
		/// Divides the value of <paramref name="left"/> with
		/// <paramref name="right"/>
		/// </summary>
		/// <param name="left">Stat to be divided</param>
		/// <param name="right">Value to divide <paramref name="left"/> by</param>
		/// <returns>
		/// The <see cref="Value"/> of <paramref name="left"/> divided by <paramref name="right"/>
		/// </returns>
		public static ushort operator /(Stat left, ushort right)
		{
			return (ushort)(left.Value / right);
		}

		/// <inheritdoc cref="operator /(Stat, ushort)"/>
		public static double operator /(Stat left, double right)
		{
			return (double)left.Value / right;
		}
		#endregion
		#endregion
	}
}
