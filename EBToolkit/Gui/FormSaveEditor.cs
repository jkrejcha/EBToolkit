using System;
using System.Windows.Forms;

namespace EBToolkit.Gui
{
	/// <summary>
	/// A <see cref="Form"/> for the savegame editor
	/// </summary>
	public partial class FormSaveEditor : Form
	{
		/// <summary>
		/// Creates a new <see cref="FormSaveEditor"/>
		/// </summary>
		/// <seealso cref="FormSaveEditor"/>
		public FormSaveEditor()
		{
			InitializeComponent();
		}

        private void LoadTestButton_Click(object sender, EventArgs e)
        {
            FileDialog.ShowDialog();
        }
    }
}
