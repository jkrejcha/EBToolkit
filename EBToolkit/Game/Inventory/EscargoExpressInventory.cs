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

		/// <summary>
		/// Creates a new inventory for Escargo Express with a maximum size of
		/// <see cref="EscargoExpressInventorySize"/>
		/// </summary>
		/// <seealso cref="EscargoExpressInventory"/>
		/// <seealso cref="EscargoExpressInventorySize"/>
		public EscargoExpressInventory() : base(EscargoExpressInventorySize) { }
	}
}
