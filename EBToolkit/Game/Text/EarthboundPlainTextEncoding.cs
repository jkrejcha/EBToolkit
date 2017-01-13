using System;

namespace EBToolkit.Game.Text
{
	/// <summary>
	/// An encoding used for plain text in the EarthBound game.
	/// </summary>
	public class EarthboundPlainTextEncoding : EarthboundEncoding
	{
		/// <summary>
		/// A value that represents how far up plain text in EarthBound's encoding
		/// is shifted up from ASCII
		/// </summary>
		public const byte PlainTextByteShift = 0x30;

		/// <inheritdoc/>
		public EarthboundPlainTextEncoding()
		{
			this.ByteShift = PlainTextByteShift;
		}
	}
}
