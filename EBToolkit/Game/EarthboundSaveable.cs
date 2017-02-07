using System;
using System.IO;

namespace EBToolkit.Game
{
	/// <summary>
	/// An interface that represents an object that is saveable in the EarthBound
	/// save game.
	/// </summary>
	public interface EarthboundSaveable
	{
		/// <summary>
		/// Writes data to a <see cref="BinaryWriter"/>, probably to be written
		/// to a save file
		/// </summary>
		/// <param name="writer"><see cref="BinaryWriter"/> to use</param>
		void WriteDataToStream(BinaryWriter writer);
	}
}
