using System;

namespace EBToolkit.Game.Inventory
{
	/// <summary>
	/// Represents the storage of Escargo Express
	/// </summary>
	public class EscargoExpressInventory : Inventory
	{
		/// <summary>
		/// The amount of items that Escargo Express can hold.
		/// </summary>
		public const int EscargoExpressInventorySize = 36;

		public EscargoExpressInventory() : base(EscargoExpressInventorySize) { }
	}
}
