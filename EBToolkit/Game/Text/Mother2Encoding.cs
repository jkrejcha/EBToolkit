using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBToolkit.Game.Text
{
	/// <summary>
	/// An encoding used in Mother 2. Unlike an <see cref="EarthboundEncoding"/>,
	/// it is not just an <see cref="ASCIIEncoding"/> shifted <see cref="EarthboundEncoding.ByteShift"/>
	/// number of bytes, but rather it's own character set entirely, because of
	/// the fact that is uses Japanese characters.
	/// </summary>
	/// <remarks>
	/// It does not seem to match any known common Japanese encoding, but rather
	/// use its own.
	/// </remarks>
	public class Mother2Encoding : Encoding
	{
		/// <inheritdoc/>
		public override int GetByteCount(char[] chars, int index, int count)
		{
			Contract.Requires<ArgumentNullException>(chars != null);
			Contract.Requires<ArgumentOutOfRangeException>(index >= 0 && index < chars.Length);
			Contract.Requires<ArgumentOutOfRangeException>(count >= 0);
			Contract.Requires<ArgumentOutOfRangeException>(index + count < chars.Length);
			throw new NotImplementedException();
		}

		/// <inheritdoc/>
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc/>
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc/>
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Return the max byte count for this encoding
		/// </summary>
		/// <param name="charCount">The amount of characters</param>
		/// <returns><paramref name="charCount"/></returns>
		public override int GetMaxByteCount(int charCount)
		{
			return charCount;
		}

		/// <summary>
		/// Return the max character count for this encoding
		/// </summary>
		/// <param name="byteCount">The amount of bytes encoded</param>
		/// <returns><paramref name="byteCount"/></returns>
		public override int GetMaxCharCount(int byteCount)
		{
			return byteCount;
		}
	}
}
