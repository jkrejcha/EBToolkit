using System;

namespace EBToolkit.Game.Character
{
	/// <summary>
	/// A stat that can change based on equipment
	/// </summary>
	public class EquipmentChangeableStat : Stat
	{
		/// <summary>
		/// The base value of this stat before the bonus from equipment is applied
		/// </summary>
		public byte BaseValue;

		/// <summary>
		/// The extra value that the equipment provides for this stat
		/// </summary>
		public byte Difference
		{
			get { return (byte)(Value - BaseValue); }
		}
	}
}
