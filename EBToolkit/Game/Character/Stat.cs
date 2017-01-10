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

		public static ushort operator *(Stat Left, ushort Right)
		{
			return (ushort)(Left.Value * Right);
		}

		public static ushort operator /(Stat Left, ushort Right)
		{
			return (ushort)(Left.Value / Right);
		}

		public static double operator /(Stat Left, double Right)
		{
			return (double)Left.Value / Right;
		}
	}
}
