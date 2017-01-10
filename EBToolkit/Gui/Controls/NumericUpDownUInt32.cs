using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EBToolkit.Gui.Controls
{
	public class NumericUpDownUInt32 : NumericUpDown
	{
		private uint _minimum = 0u;

		private uint _maximum = 4294967295u;

		private uint _value;

		public new int DecimalPlaces
		{
			get
			{
				return 0;
			}
		}

		[DefaultValue(0u)]
		public new uint Minimum
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

		[DefaultValue(4294967295u)]
		public new uint Maximum
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

		[DefaultValue(0u)]
		public new uint Value
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

		public NumericUpDownUInt32()
		{
			this.Minimum = 0u;
			this.Maximum = 4294967295u;
			this.Value = this.Minimum;
			base.ValueChanged += new EventHandler(this.SyncValue);
		}

		private void SyncValue(object sender, EventArgs args)
		{
			this._value = (uint)base.Value;
		}
	}
}
