using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class CustomDifficultySelector: Form
    {
		Form1 parentForm;
        public CustomDifficultySelector()
        {
            InitializeComponent();
        }

		public CustomDifficultySelector(Form1 form)
		{
			parentForm = form;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			parentForm.boardWidth = (int)numHeight.Value;
			parentForm.boardHeight = (int)numWidth.Value;
			parentForm.totalBombs = (int)numBombs.Value;
		}
	}
}
