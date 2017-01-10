using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EBToolkit.Gui.Controls
{
	public class NumericUpDownByte : NumericUpDown
	{
		private byte _minimum = Byte.MinValue;

		private byte _maximum = Byte.MaxValue;

		private byte _value;

		public new int DecimalPlaces
		{
			get
			{
				return 0;
			}
		}

		[DefaultValue(Byte.MinValue)]
		public new byte Minimum
		{
			get
			{
				return this._minimum;
			}
			set
			{
				this._minimum = value;
				base.Minimum = this._minimum;
			}
		}

		[DefaultValue(255)]
		public new byte Maximum
		{
			get
			{
				return this._maximum;
			}
			set
			{
				this._maximum = value;
				base.Maximum = this._maximum;
			}
		}

		[DefaultValue(Byte.MinValue)]
		public new byte Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
				base.Value = this._value;
			}
		}

		public NumericUpDownByte()
		{
			this.Minimum = Byte.MinValue;
			this.Maximum = Byte.MaxValue;
			this.Value = this.Minimum;
			base.ValueChanged += new EventHandler(this.SyncValue);
		}

		private void SyncValue(object sender, EventArgs args)
		{
			this._value = (byte)base.Value;
		}
	}
}
