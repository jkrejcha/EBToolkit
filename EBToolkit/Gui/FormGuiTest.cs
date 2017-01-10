using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EBToolkit.Gui
{
	public class FormGuiTest : Form
	{
		private IContainer components = null;

		public FormGuiTest()
		{
			this.InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(284, 261);
			base.Name = "FormGuiTest";
			this.Text = "GuiTest";
			base.ResumeLayout(false);
		}
	}
}
