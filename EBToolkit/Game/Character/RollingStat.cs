using System;

namespace EBToolkit.Game.Character
{
	/// <summary>
	/// Represents a statistic that can have a rolling value (in EarthBound this
	/// is used for <see cref="EarthboundCharacter.HP"/> and <see cref="EarthboundCharacter.PP"/>.
	/// </summary>
	public class RollingStat
	{
		/// <summary>
		/// The value of this rolling stat. The <see cref="RollingValue"/> will
	    /// eventually roll up or down to this value. Some events may cause this
	    /// to be set to the value of <see cref="RollingValue"/> (for example a 
		/// PC using a healing item or PSI action).
		/// </summary>
		public ushort Value;
		/// <summary>
		/// The rolling value of this rolling stat. This value will eventually 
		/// roll up/down to <see cref="Value"/>, however this may change 
		/// <see cref="Value"/> on certain occasions.
		/// </summary>
		public ushort RollingValue;
		/// <summary>
		/// The maximum value that the game will allow for this stat. While the
		/// game will accept values of <see cref="Value"/> and <see cref="RollingValue"/>
		/// higher than this, doing so may cause odd glitches.
		/// </summary>
		public ushort MaxValue;
	}
}
