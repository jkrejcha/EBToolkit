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

		/// <inheritdoc/>
		public virtual void WriteDataToStream(BinaryWriter Writer)
		{
			Item[] items = this.Items;
			for (int i = 0; i < items.Length; i++)
			{
				Item Item = items[i];
				Writer.Write((byte)Item);
			}
		}
	}
}
