using System;

namespace EBToolkit.Game.Character
{
	/// <summary>
	/// Represents an enemy that can be in battle in EarthBound
	/// </summary>
	public class EarthboundEnemy : EarthboundCharacter
	{
		/// <summary>
		/// How much money is gained on defeat of this enemy
		/// </summary>
		public ushort Money;
		
		/// <summary>
		/// Whether a <see cref="EarthboundPartyMember"/> can run away from this
		/// enemy
		/// </summary>
		public bool CanRunAwayFrom;
	}
}
