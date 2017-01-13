using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EBToolkit.Gui.Controls
{
	/// <summary>
	/// A <see cref="NumericUpDown"/> control which is limited in range to the
	/// range of a <see cref="UInt16"/>
	/// </summary>
	/// <seealso cref="UInt16"/>
	/// <seealso cref="NumericUpDown"/>
	/// <seealso cref="NumericUpDownByte"/>
	/// <seealso cref="NumericUpDownUInt32"/>
	public class NumericUpDownUInt16 : NumericUpDown
	{
		/// <summary>
		/// The field for the minimum value of this control
		/// </summary>
		private ushort _minimum = UInt16.MinValue;

		/// <summary>
		/// The field for the maximum value of this control
		/// </summary>
		private ushort _maximum = UInt16.MaxValue;

		/// <summary>
		/// The field for the value of this control
		/// </summary>
		private ushort _value;

		/// <summary>
		/// The amount of decimal places. Always 0.
		/// </summary>
		public new int DecimalPlaces
		{
			get { return 0; }
		}

		/// <summary>
		/// The minimum value for this control. Defaults to <see cref="UInt16.MinValue"/>
		/// </summary>
		/// <seealso cref="UInt16.MinValue"/>
		/// <seealso cref="Maximum"/>
		/// <seealso cref="Value"/>
		[DefaultValue(UInt16.MinValue)]
		public new UInt16 Minimum
		{
			get { return this._minimum; }
			set
			{
				this._minimum = value;
				base.Minimum = this._minimum;
			}
		}

		/// <summary>
		/// The maximum value for this control. Defaults to <see cref="UInt16.MaxValue"/>
		/// </summary>
		/// <seealso cref="UInt16.MaxValue"/>
		/// <seealso cref="Minimum"/>
		/// <seealso cref="Value"/>
		[DefaultValue(UInt16.MaxValue)]
		public new UInt16 Maximum
		{
			get { return this._maximum; }
			set
			{
				this._maximum = value;
				base.Maximum = this._maximum;
			}
		}

		/// <summary>
		/// The value of this control. Defaults to <see cref="UInt16.MinValue"/>
		/// </summary>
		/// <seealso cref="UInt16.MinValue"/>
		/// <seealso cref="Minimum"/>
		/// <seealso cref="Maximum"/>
		[DefaultValue(UInt16.MinValue)]
		public new UInt16 Value
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
		/// Creates a new instance of a <see cref="NumericUpDownUInt16"/>
		/// </summary>
		public NumericUpDownUInt16()
		{
			this.Minimum = UInt16.MinValue;
			this.Maximum = UInt16.MaxValue;
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
			this._value = (ushort)base.Value;
		}
	}
}
