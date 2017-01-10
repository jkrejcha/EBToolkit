using System;
using System.IO;

namespace EBToolkit.Game.Inventory
{
	public class Inventory : EarthboundSaveable
	{
		public readonly Item[] Items;

		public Inventory(int size)
		{
			this.Items = new Item[size];
		}

		public void Sort(SortMethod Method)
		{
			Item[] NewItems = new Item[0];
			Array.Copy(this.Items, NewItems, this.Items.Length);
			throw new NotImplementedException("Item sorting not implemented yet");
		}

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
