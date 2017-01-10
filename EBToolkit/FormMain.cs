using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EBToolkit
{
	public class FormMain : Form
	{
		private IContainer components = null;

		private TabControl TCMain;

		private TabPage TPCalculators;

		private TabPage TPCheats;

		private Button btnSaveEditor;

		private TabPage TPLive;

		public FormMain()
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
			this.TCMain = new TabControl();
			this.TPCalculators = new TabPage();
			this.TPCheats = new TabPage();
			this.btnSaveEditor = new Button();
			this.TPLive = new TabPage();
			this.TCMain.SuspendLayout();
			this.TPCheats.SuspendLayout();
			base.SuspendLayout();
			this.TCMain.Controls.Add(this.TPCalculators);
			this.TCMain.Controls.Add(this.TPCheats);
			this.TCMain.Controls.Add(this.TPLive);
			this.TCMain.Dock = DockStyle.Fill;
			this.TCMain.Location = new Point(0, 0);
			this.TCMain.Name = "TCMain";
			this.TCMain.SelectedIndex = 0;
			this.TCMain.Size = new Size(691, 355);
			this.TCMain.TabIndex = 0;
			this.TPCalculators.Location = new Point(4, 22);
			this.TPCalculators.Name = "TPCalculators";
			this.TPCalculators.Padding = new Padding(3);
			this.TPCalculators.Size = new Size(683, 329);
			this.TPCalculators.TabIndex = 0;
			this.TPCalculators.Text = "Calculators";
			this.TPCalculators.UseVisualStyleBackColor = true;
			this.TPCheats.Controls.Add(this.btnSaveEditor);
			this.TPCheats.Location = new Point(4, 22);
			this.TPCheats.Name = "TPCheats";
			this.TPCheats.Padding = new Padding(3);
			this.TPCheats.Size = new Size(683, 329);
			this.TPCheats.TabIndex = 1;
			this.TPCheats.Text = "Cheats";
			this.TPCheats.UseVisualStyleBackColor = true;
			this.btnSaveEditor.Location = new Point(8, 6);
			this.btnSaveEditor.Name = "btnSaveEditor";
			this.btnSaveEditor.Size = new Size(143, 23);
			this.btnSaveEditor.TabIndex = 0;
			this.btnSaveEditor.Text = "Save Editor...";
			this.btnSaveEditor.UseVisualStyleBackColor = true;
			this.TPLive.Location = new Point(4, 22);
			this.TPLive.Name = "TPLive";
			this.TPLive.Padding = new Padding(3);
			this.TPLive.Size = new Size(683, 329);
			this.TPLive.TabIndex = 2;
			this.TPLive.Text = "EarthBound Live";
			this.TPLive.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(691, 355);
			base.Controls.Add(this.TCMain);
			base.Name = "FormMain";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Earthbound Toolkit";
			this.TCMain.ResumeLayout(false);
			this.TPCheats.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
