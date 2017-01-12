using System;

namespace EBToolkit.Game
{
	/// <summary>
	/// Represents a background that can be used in the game EarthBound
	/// </summary>
	public class Background
	{
		//TODO: Documentation

		public readonly ushort Layer0;
		public readonly ushort Layer1;

		public Background(ushort Layer0, ushort Layer1)
		{
			this.Layer0 = Layer0;
			this.Layer1 = Layer1;
			System.Diagnostics.Debug.WriteLine("Warning: This has not been implemented correctly really");
		}
	}
}