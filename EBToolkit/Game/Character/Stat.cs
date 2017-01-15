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
		/// Determines whether the <paramref name="Left"/> stat is less than
		/// the <paramref name="Right"/> stat.
		/// </summary>
		/// <param name="Left">First stat in comparison</param>
		/// <param name="Right">Second stat in comparison</param>
		/// <returns>Whether the <see cref="Value"/> of <paramref name="Left"/>
		/// is less than <paramref name="Right"/></returns>
		public static bool operator <(Stat Left, Stat Right)
		{
			return Left.Value < Right.Value;
		}
		/// <summary>
		/// Determines whether the <paramref name="Left"/> stat is less than
		/// the value of <paramref name="Right"/>.
		/// </summary>
		/// <param name="Left">First stat in comparison</param>
		/// <param name="Right">Byte to compare to</param>
		/// <returns>Whether the <see cref="Value"/> of <paramref name="Left"/>
		/// is less than <paramref name="Right"/></returns>
		public static bool operator <(Stat Left, byte Right)
		{
			return Left.Value < Right;
		}
		/// <summary>
		/// Determines whether the <paramref name="Left"/> stat is greater than
		/// the <paramref name="Right"/> stat.
		/// </summary>
		/// <param name="Left">First stat in comparison</param>
		/// <param name="Right">Second stat in comparison</param>
		/// <returns>Whether the <see cref="Value"/> of <paramref name="Left"/>
		/// is greater than <paramref name="Right"/></returns>
		public static bool operator >(Stat Left, Stat Right)
		{
			return Left.Value > Right.Value;
		}
		/// <summary>
		/// Determines whether the <paramref name="Left"/> stat is greater than
		/// the value of <paramref name="Right"/>.
		/// </summary>
		/// <param name="Left">First stat in comparison</param>
		/// <param name="Right">Byte to compare to</param>
		/// <returns>Whether the <see cref="Value"/> of <paramref name="Left"/>
		/// is greater than <paramref name="Right"/></returns>
		public static bool operator >(Stat Left, byte Right)
		{
			return Left.Value > Right;
		}
		#endregion
		#region "Multiplication"
		public static ushort operator *(Stat Left, ushort Right)
		{
			return (ushort)(Left.Value * Right);
		}
		#endregion
		#region "Division"
		public static ushort operator /(Stat Left, ushort Right)
		{
			return (ushort)(Left.Value / Right);
		}

		public static double operator /(Stat Left, double Right)
		{
			return (double)Left.Value / Right;
		}
		#endregion
		#endregion
	}
}
