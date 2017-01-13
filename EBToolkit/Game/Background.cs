using System;

namespace EBToolkit.Game
{
	/// <summary>
	/// Represents a background that can be used in the game EarthBound
	/// </summary>
	public class Background
	{
		//TODO: Documentation

		/// <summary>
		/// Layer 0
		/// </summary>
		public readonly ushort Layer0;
		/// <summary>
		/// Layer 1
		/// </summary>
		public readonly ushort Layer1;

		/// <summary>
		/// Creates a new <see cref="Background"/> from two layers
		/// </summary>
		/// <param name="Layer0">The ID of layer 0 (<see cref="Layer0"/>)</param>
		/// <param name="Layer1">The ID of layer 1 (<see cref="Layer1"/>)</param>
		public Background(ushort Layer0, ushort Layer1)
		{
			this.Layer0 = Layer0;
			this.Layer1 = Layer1;
			System.Diagnostics.Debug.WriteLine("Warning: This has not been implemented correctly really");
		}
	}
}