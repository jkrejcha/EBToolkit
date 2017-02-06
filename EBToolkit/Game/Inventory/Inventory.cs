using System;
using System.Collections.Generic;
using System.IO;

namespace EBToolkit.Game.Inventory
{
	/// <summary>
	/// Represents a container for multiple <see cref="Item"/>s.
	/// </summary>
	public class Inventory : EarthboundSaveable//, IList<Item>
	{
		/// <summary>
		/// An array of items that are contained within this <see cref="Inventory"/>
		/// </summary>
		public readonly Item[] Items;

		/// <summary>
		/// Creates an inventory of a specified size
		/// </summary>
		/// <param name="size">The size of the new inventory</param>
		public Inventory(int size)
		{
			this.Items = new Item[size];
		}

		/// <summary>
		/// Sort items in the inventory according to a specific method.
		/// </summary>
		/// <param name="method">The method to sort items by</param>
		public void Sort(SortMethod method)
		{
			Item[] NewItems = new Item[0];
			Array.Copy(this.Items, NewItems, this.Items.Length);
			throw new NotImplementedException("Item sorting not implemented yet");
		}

		/// <inheritdoc/>
		public virtual void WriteDataToStream(BinaryWriter writer)
		{
			Item[] items = this.Items;
			for (int i = 0; i < items.Length; i++)
			{
				Item Item = items[i];
				writer.Write((byte)Item);
			}
		}

		/// <summary>
		/// The method to sort items by
		/// </summary>
		public enum SortMethod
		{
			/// <summary>
			/// Sort items by how good they are
			/// </summary>
			Best,
			/// <summary>
			/// Sort items by their English name
			/// </summary>
			Alpha,
			/// <summary>
			/// Sort items by their numeric ID
			/// </summary>
			Numeric,
		}
	}
}
