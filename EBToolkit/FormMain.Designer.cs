namespace EBToolkit
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.TCMain = new System.Windows.Forms.TabControl();
			this.TPCalculators = new System.Windows.Forms.TabPage();
			this.TPCheats = new System.Windows.Forms.TabPage();
			this.btnSaveEditor = new System.Windows.Forms.Button();
			this.TPLive = new System.Windows.Forms.TabPage();
			this.TCMain.SuspendLayout();
			this.TPCheats.SuspendLayout();
			this.SuspendLayout();
			// 
			// TCMain
			// 
			this.TCMain.Controls.Add(this.TPCalculators);
			this.TCMain.Controls.Add(this.TPCheats);
			this.TCMain.Controls.Add(this.TPLive);
			this.TCMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TCMain.Location = new System.Drawing.Point(0, 0);
			this.TCMain.Name = "TCMain";
			this.TCMain.SelectedIndex = 0;
			this.TCMain.Size = new System.Drawing.Size(664, 376);
			this.TCMain.TabIndex = 1;
			// 
			// TPCalculators
			// 
			this.TPCalculators.Location = new System.Drawing.Point(4, 22);
			this.TPCalculators.Name = "TPCalculators";
			this.TPCalculators.Padding = new System.Windows.Forms.Padding(3);
			this.TPCalculators.Size = new System.Drawing.Size(656, 350);
			this.TPCalculators.TabIndex = 0;
			this.TPCalculators.Text = "Calculators";
			this.TPCalculators.UseVisualStyleBackColor = true;
			// 
			// TPCheats
			// 
			this.TPCheats.Controls.Add(this.btnSaveEditor);
			this.TPCheats.Location = new System.Drawing.Point(4, 22);
			this.TPCheats.Name = "TPCheats";
			this.TPCheats.Padding = new System.Windows.Forms.Padding(3);
			this.TPCheats.Size = new System.Drawing.Size(656, 350);
			this.TPCheats.TabIndex = 1;
			this.TPCheats.Text = "Cheats";
			this.TPCheats.UseVisualStyleBackColor = true;
			// 
			// btnSaveEditor
			// 
			this.btnSaveEditor.Location = new System.Drawing.Point(8, 6);
			this.btnSaveEditor.Name = "btnSaveEditor";
			this.btnSaveEditor.Size = new System.Drawing.Size(143, 23);
			this.btnSaveEditor.TabIndex = 0;
			this.btnSaveEditor.Text = "Save Editor...";
			this.btnSaveEditor.UseVisualStyleBackColor = true;
			// 
			// TPLive
			// 
			this.TPLive.Location = new System.Drawing.Point(4, 22);
			this.TPLive.Name = "TPLive";
			this.TPLive.Padding = new System.Windows.Forms.Padding(3);
			this.TPLive.Size = new System.Drawing.Size(656, 350);
			this.TPLive.TabIndex = 2;
			this.TPLive.Text = "EarthBound Live";
			this.TPLive.UseVisualStyleBackColor = true;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 376);
			this.Controls.Add(this.TCMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "EarthBound Toolkit";
			this.TCMain.ResumeLayout(false);
			this.TPCheats.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl TCMain;
		private System.Windows.Forms.TabPage TPCalculators;
		private System.Windows.Forms.TabPage TPCheats;
		private System.Windows.Forms.Button btnSaveEditor;
		private System.Windows.Forms.TabPage TPLive;
	}
}