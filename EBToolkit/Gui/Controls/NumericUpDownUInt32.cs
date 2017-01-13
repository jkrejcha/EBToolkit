using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EBToolkit.Gui.Controls
{
	/// <summary>
	/// A <see cref="NumericUpDown"/> control which is limited in range to the
	/// range of a <see cref="UInt32"/>
	/// </summary>
	/// <seealso cref="UInt32"/>
	/// <seealso cref="NumericUpDown"/>
	/// <seealso cref="NumericUpDownByte"/>
	/// <seealso cref="NumericUpDownUInt16"/>
	public class NumericUpDownUInt32 : NumericUpDown
	{
		/// <summary>
		/// The field for the minimum value of this control
		/// </summary>
		private uint _minimum = UInt32.MinValue;

		/// <summary>
		/// The field for the maximum value of this control
		/// </summary>
		private uint _maximum = UInt32.MaxValue;

		/// <summary>
		/// The field for the value of this control
		/// </summary>
		private uint _value;

		/// <summary>
		/// The amount of decimal places. Always 0.
		/// </summary>
		public new int DecimalPlaces
		{
			get { return 0; }
		}

		/// <summary>
		/// The minimum value for this control. Defaults to <see cref="UInt32.MinValue"/>
		/// </summary>
		/// <seealso cref="UInt32.MinValue"/>
		/// <seealso cref="Maximum"/>
		/// <seealso cref="Value"/>
		[DefaultValue(UInt32.MinValue)]
		public new UInt32 Minimum
		{
			get { return this._minimum; }
			set
			{
				this._minimum = value;
				base.Minimum = this._minimum;
			}
		}

		/// <summary>
		/// The maximum value for this control. Defaults to <see cref="UInt32.MaxValue"/>
		/// </summary>
		/// <seealso cref="UInt32.MaxValue"/>
		/// <seealso cref="Minimum"/>
		/// <seealso cref="Value"/>
		[DefaultValue(UInt32.MaxValue)]
		public new UInt32 Maximum
		{
			get { return this._maximum; }
			set
			{
				this._maximum = value;
				base.Maximum = this._maximum;
			}
		}

		/// <summary>
		/// The value of this control. Defaults to <see cref="UInt32.MinValue"/>
		/// </summary>
		/// <seealso cref="UInt32.MinValue"/>
		/// <seealso cref="Minimum"/>
		/// <seealso cref="Maximum"/>
		[DefaultValue(UInt32.MinValue)]
		public new UInt32 Value
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

		/// <summary>
		/// Creates a new instance of a <see cref="NumericUpDownUInt32"/>
		/// </summary>
		public NumericUpDownUInt32()
		{
			this.Minimum = UInt32.MinValue;
			this.Maximum = UInt32.MaxValue;
			this.Value = this.Minimum;
			base.ValueChanged += new EventHandler(this.SyncValue);
		}

		/// <summary>
		/// A private helper method to sync the value of this control with
		/// the value of the underlying <see cref="NumericUpDown.Value"/>
		/// </summary>
		/// <param name="sender">Sender info. Ignored.</param>
		/// <param name="args">EventArgs. Ignored.</param>
		private void SyncValue(object sender, EventArgs args)
		{
			this._value = (uint)base.Value;
		}
	}
}
