using System;
using System.IO;

namespace EBToolkit.Game.Inventory
{
	/// <summary>
	/// Represents a <see cref="Game.Character.EarthboundPartyMember"/>'s inventory
	/// </summary>
	public class PlayerInventory : Inventory
	{
		public const int PlayerInventorySize = 14;

		public readonly byte[] Equips = { 0, 0, 0, 0 };

		public PlayerInventory() : base(PlayerInventorySize) { }

		/// <inheritdoc/>
		public override void WriteDataToStream(BinaryWriter Writer)
		{
			base.WriteDataToStream(Writer);
			foreach (byte Equip in Equips) Writer.Write(Equip);
		}
	}
}
