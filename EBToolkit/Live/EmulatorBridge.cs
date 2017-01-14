using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBToolkit.Live
{
	//TODO: Change the terrible, terrible name.
	/// <summary>
	/// A abstract class that provides functions to read and write from memory
	/// and affect other parts of the game state live. <b style="color:red">Like
	/// some other classes, this is not complete and is subject to change very
	/// frequently. You have been warned.</b>
	/// </summary>
	/// <remarks>
	/// While this class could technically be used for any game, the purpose is
	/// to read/write state for the game EarthBound or any other supported game
	/// by this project.
	/// </remarks>
	public abstract class EmulatorBridge
	{
		/// <summary>
		/// Reads a <see cref="byte"/> from memory at a specified address.
		/// </summary>
		/// <param name="address">Memory address to read</param>
		/// <param name="bigEndian">Endianness of memory</param>
		/// <returns>The value of the <see cref="byte"/> at the location in memory</returns>
		public abstract byte PeekByte(long address, bool bigEndian = false);
		/// <summary>
		/// Reads a <see cref="ushort"/> from memory at a specified address.
		/// </summary>
		/// <param name="address">Memory address to read</param>
		/// <param name="bigEndian">Endianness of memory</param>
		/// <returns>The value of the <see cref="ushort"/> at the location in memory</returns>
		public abstract ushort PeekUInt16(long address, bool bigEndian = false);
		/// <summary>
		/// Reads a <see cref="uint"/> from memory at a specified address.
		/// </summary>
		/// <param name="address">Memory address to read</param>
		/// <param name="bigEndian">Endianness of memory</param>
		/// <returns>The value of the <see cref="uint"/> at the location in memory</returns>
		public abstract uint PeekUInt32(long address, bool bigEndian = false);

		/// <summary>
		/// Writes a <see cref="byte"/> to memory at a specified address
		/// </summary>
		/// <param name="address">Memory address to write to</param>
		/// <param name="value">Value of new memory</param>
		/// <param name="bigEndian">Endianness of memory</param>
		public abstract void Poke(long address, byte value, bool bigEndian = false);
		/// <summary>
		/// Writes a <see cref="ushort"/> to memory at a specified address
		/// </summary>
		/// <param name="address">Memory address to write to</param>
		/// <param name="value">Value of new memory</param>
		/// <param name="bigEndian">Endianness of memory</param>
		public abstract void Poke(long address, ushort value, bool bigEndian = false);

		/// <summary>
		/// Writes a <see cref="uint"/> to memory at a specified address
		/// </summary>
		/// <param name="address">Memory address to write to</param>
		/// <param name="value">Value of new memory</param>
		/// <param name="bigEndian">Endianness of memory</param>
		public abstract void Poke(long address, uint value, bool bigEndian = false);
	}
}
