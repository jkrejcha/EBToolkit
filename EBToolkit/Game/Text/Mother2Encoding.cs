using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBToolkit.Game.Text
{
	/// <summary>
	/// An encoding used in Mother 2
	/// </summary>
	public class Mother2Encoding : Encoding
	{
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

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
