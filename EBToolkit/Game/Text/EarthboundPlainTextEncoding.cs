using System;

namespace EBToolkit.Game.Text
{
	/// <summary>
	/// An encoding used for plain text in the EarthBound game.
	/// </summary>
	public class EarthboundPlainTextEncoding : EarthboundEncoding
	{
		public const byte PlainTextByteShift = 0x30;

		public EarthboundPlainTextEncoding()
		{
			this.ByteShift = PlainTextByteShift;
		}
	}
}
