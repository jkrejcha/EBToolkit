namespace EBToolkit.Gui
{
	partial class FormSaveEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSaveEditor));
            this.LoadTestButton = new System.Windows.Forms.Button();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // LoadTestButton
            // 
            resources.ApplyResources(this.LoadTestButton, "LoadTestButton");
            this.LoadTestButton.Name = "LoadTestButton";
            this.LoadTestButton.UseVisualStyleBackColor = true;
            this.LoadTestButton.Click += new System.EventHandler(this.LoadTestButton_Click);
            // 
            // FileDialog
            // 
            resources.ApplyResources(this.FileDialog, "FileDialog");
            this.FileDialog.SupportMultiDottedExtensions = true;
            // 
            // FormSaveEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoadTestButton);
            this.MaximizeBox = false;
            this.Name = "FormSaveEditor";
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.Button LoadTestButton;
        private System.Windows.Forms.OpenFileDialog FileDialog;
    }
}