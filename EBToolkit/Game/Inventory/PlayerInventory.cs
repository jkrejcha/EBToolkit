using System;

namespace EBToolkit.Game.Inventory
{
	/// <summary>
	/// Represents a <see cref="Game.Character.EarthboundPartyMember"/>'s inventory
	/// </summary>
	public class PlayerInventory : Inventory
	{
		public const int PlayerInventorySize = 14;

		public PlayerInventory() : base(PlayerInventorySize) { }
	}
}
