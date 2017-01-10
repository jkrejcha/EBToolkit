using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EBToolkit.Gui.Controls
{
	public class NumericUpDownByte : NumericUpDown
	{
		private byte _minimum = 0;

		private byte _maximum = 255;

		private byte _value;

		public new int DecimalPlaces
		{
			get
			{
				return 0;
			}
		}

		[DefaultValue(0)]
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

		[DefaultValue(0)]
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
			this.Minimum = 0;
			this.Maximum = 255;
			this.Value = this.Minimum;
			base.ValueChanged += new EventHandler(this.SyncValue);
		}

		private void SyncValue(object sender, EventArgs args)
		{
			this._value = (byte)base.Value;
		}
	}
}
