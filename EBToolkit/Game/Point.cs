using System;
using System.Drawing;
using System.IO;

namespace EBToolkit.Game
{
	/// <summary>
	/// A location on the map, represents by two <see cref="UInt16"/> values
	/// </summary>
	public struct Point : EarthboundSaveable
	{
		/// <summary>
		/// The coordinate point (0, 0)
		/// </summary>
		public static readonly Point Zero = new Point(0, 0);
		/// <summary>
		/// The location of Onett in EarthBound
		/// </summary>
		/// <remarks>
		/// This location was found using the debug menu and RAM watch tools.
		/// </remarks>
		public static readonly Point Onett = new Point(2632, 400);

		/// <summary>
		/// The location of Twoson in EarthBound
		/// </summary>
		/// <remarks>
		/// This location was found using the debug menu and RAM watch tools.
		/// </remarks>
		public static readonly Point Twoson = new Point(1496, 6568);

		/// <summary>
		/// The location of Happy Happy Village in EarthBound
		/// </summary>
		/// <remarks>
		/// This location was found using the debug menu and RAM watch tools.
		/// </remarks>
		public static readonly Point HappyHappyVillage = new Point(3728, 7904);

		/// <summary>
		/// The location of Happy Happy cultist's cabin in EarthBound
		/// </summary>
		/// <remarks>
		/// This location was found using the debug menu and RAM watch tools.
		/// The location was adjusted slightly in order to be outside a wall.
		/// </remarks>
		public static readonly Point HHCultistCabin = new Point(5965, 1287);

		/// <summary>
		/// The location of Threed in EarthBound
		/// </summary>
		/// <remarks>
		/// This location was found using the debug menu and RAM watch tools.
		/// </remarks>
		public static readonly Point Threed = new Point(5592, 9168);

		/// <summary>
		/// The location of Winters in EarthBound
		/// </summary>
		/// <remarks>
		/// This location was found using the debug menu and RAM watch tools.
		/// </remarks>
		public static readonly Point Winters = new Point(480, 2360);

		/// <summary>
		/// The location of Saturn Valley in EarthBound
		/// </summary>
		/// <remarks>
		/// This location was found using the debug menu and RAM watch tools.
		/// </remarks>
		public static readonly Point SaturnValley = new Point(440, 7362);

		//TODO: Add more points

		/// <summary>
		/// The X coordinate
		/// </summary>
		public ushort X;

		/// <summary>
		/// The Y coordinate
		/// </summary>
		public ushort Y;

		/// <summary>
		/// Creates a new <see cref="Point"/> using a provided X and Y value
		/// </summary>
		/// <param name="X">The X coordinate</param>
		/// <param name="Y">The Y coordinate</param>
		public Point(ushort X, ushort Y)
		{
			this.X = X;
			this.Y = Y;
		}

		public static Point operator +(Point left, Point right)
		{
			return new Point((ushort)(left.X + right.X), (ushort)(left.Y + right.Y));
		}

		public static Point operator -(Point left, Point right)
		{
			return new Point((ushort)(left.X - right.X), (ushort)(left.Y - right.Y));
		}

		public static implicit operator Point(System.Drawing.Point point)
		{
			return new Point((ushort)point.X, (ushort)point.Y);
		}

		public static implicit operator Point(PointF point)
		{
			return new Point((ushort)point.X, (ushort)point.Y);
		}

		/// <inheritdoc/>
		public void WriteDataToStream(BinaryWriter writer)
		{
			writer.Write(this.X);
			writer.Write(this.Y);
		}
	}
}
