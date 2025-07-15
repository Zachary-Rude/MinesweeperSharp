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
    public partial class Form1: Form
    {
		byte[,] Positions = new byte[15, 15];
		Button[,] ButtonList = new Button[15, 15];

        public Form1()
        {
            InitializeComponent();
			this.Icon = Properties.Resources.icon;
			GenerateBombs();
			GeneratePositionValue();
			GenerateButtons();
        }

		Random rnd = new Random();
		private void GenerateBombs()
		{
			int bombs = 0;
			while (bombs < 30)
			{
				int x = rnd.Next(0, 14);
				int y = rnd.Next(0, 14);

				if (Positions[x,y] == 0)
				{
					Positions[x, y] = 10;
					bombs++;
				}
			}
		}

		private void GeneratePositionValue()
		{
			for (int x = 0; x < 15; x++)
			{
				for (int y = 0; y < 15; y++)
				{
					if (Positions[x, y] == 10)
						continue;
					int bombCount = 0;
					for (int counterX = -1; counterX < 2; counterX++)
					{
						int checkerX = x + counterX;

						for (int counterY = -1; counterY < 2; counterY++)
						{
							int checkerY = y + counterY;

							if (checkerX == -1 || checkerY == -1 || checkerX > 14 || checkerY > 14)
								continue;

							if (checkerY == y && checkerX == x)
								continue;

							if (Positions[checkerX, checkerY] == 10)
								bombCount++;
						}
					}

					if (bombCount == 0)
						Positions[x, y] = 20;
					else
						Positions[x, y] = (byte)bombCount;
				}
			}
		}

		private void GenerateButtons()
		{
			int xLoc = 3;
			int yLoc = 6;
			for (int x = 0; x < 15; x++)
			{
				for (int y = 0; y < 15; y++)
				{
					Button btn = new Button();
					btn.Parent = pnlBody;
					btn.Location = new Point(xLoc, yLoc);
					btn.Size = new Size(25, 22);
					btn.Font = new Font("Consolas", 8.25F);
					btn.Tag = $"{x},{y}";
					btn.Click += BtnClick;
					btn.MouseUp += BtnMouseUp;
					btn.Enter += btnRestart_Enter;
					xLoc += 25;
					ButtonList[x, y] = btn;
				}
				yLoc += 22;
				xLoc = 3;
			}
		}

		private void BtnClick(object sender, EventArgs e)
		{
			Button btn = (Button)sender;

			int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
			int y = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));
			byte value = Positions[x, y];

			if (value == 10)
			{
				btn.Font = new Font("Segoe UI Emoji", 8.25F);
				btn.Text = "💣";

				pnlBody.Enabled = false;
				MessageBox.Show(string.Format("Game Over!\r\nYou got {0} {1} and used {2} {3}.", points, (points == 1 ? "point" : "points"), 30 - flag, (30 - flag == 1 ? "flag" : "flags")), "MinesweeperSharp", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else if (value == 20)
			{
				btn.FlatStyle = FlatStyle.Flat;
				btn.FlatAppearance.BorderSize = 1;
				btn.Enabled = false;
				OpenAdjacentEmptyTile(btn);
				points++;
			}
			else
			{
				btn.FlatStyle = FlatStyle.Flat;
				btn.FlatAppearance.BorderSize = 1;
				btn.FlatAppearance.BorderColor = SystemColors.ControlDark;
				btn.FlatAppearance.MouseDownBackColor = btn.BackColor;
				btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
				btn.Text = Positions[x, y].ToString();
				switch (Positions[x, y])
				{
					case 1:
						btn.ForeColor = Color.DodgerBlue;
						break;
					case 2:
						btn.ForeColor = Color.ForestGreen;
						break;
					case 3:
						btn.ForeColor = Color.Red;
						break;
					case 4:
						btn.ForeColor = Color.MidnightBlue;
						break;
					case 5:
						btn.ForeColor = Color.DarkRed;
						break;
					case 6:
						btn.ForeColor = Color.LightSeaGreen;
						break;
					case 7:
						btn.ForeColor = SystemColors.ControlText;
						break;
					case 8:
						btn.ForeColor = SystemColors.ControlDarkDark;
						break;
					case 9:
						btn.ForeColor = Color.Violet;
						break;
				}
				points++;
			}
			btn.Click -= BtnClick;
			textBox2.Text = points.ToString();
		}

		private void OpenAdjacentEmptyTile(Button btn)
		{
			int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
			int y = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));
			List<Button> emptyButtons = new List<Button>();

			for (int counterX = -1; counterX < 2; counterX++)
			{
				int checkerX = x + counterX;

				for (int counterY = -1; counterY < 2; counterY++)
				{
					int checkerY = y + counterY;

					if (checkerX == -1 || checkerY == -1 || checkerX > 14 || checkerY > 14)
						continue;

					if (checkerY == y && checkerX == x)
						continue;

					Button btnAdjacent = ButtonList[checkerX, checkerY];
					int xAdjacent = Convert.ToInt32(btnAdjacent.Tag.ToString().Split(',').GetValue(0));
					int yAdjacent = Convert.ToInt32(btnAdjacent.Tag.ToString().Split(',').GetValue(1));

					byte value = Positions[xAdjacent, yAdjacent];

					if (value == 20)
					{
						if (btnAdjacent.FlatStyle != FlatStyle.Flat)
						{
							btnAdjacent.FlatStyle = FlatStyle.Flat;
							btn.FlatAppearance.BorderSize = 1;
							btn.FlatAppearance.BorderColor = SystemColors.ControlDark;
							btnAdjacent.Enabled = false;
							emptyButtons.Add(btnAdjacent);
						}
					}
					else if (value != 10)
					{
						btnAdjacent.PerformClick();
					}
				}
			}

			foreach (var btnEmpty in emptyButtons)
			{
				OpenAdjacentEmptyTile(btnEmpty);
			}
		}

		int flag = 30;

		int points = 0;
		private void BtnMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				Button btn = (Button)sender;
				if (string.IsNullOrEmpty(btn.Text))
				{
					btn.Text = "🚩";
					btn.Font = new Font("Segoe UI Emoji", 8.25F);
					btn.Click -= BtnClick;
					flag--;
				}
				else if (!int.TryParse(btn.Text, out _))
				{
					btn.Text = "";
					btn.Font = new Font("Consolas", 8.25F);
					btn.Click += BtnClick;
					flag++;
				}
				textBox1.Text = flag.ToString();
			}
		}

		private void btnRestart_Click(object sender, EventArgs e)
		{
			points = 0;
			textBox2.Text = points.ToString();
			flag = 30;
			textBox1.Text = flag.ToString();

			for (int x = 0; x < 15; x++)
			{
				for (int y = 0; y < 15; y++)
				{
					ButtonList[x, y].Dispose();
				}
			}

			pnlBody.Enabled = true;
			pnlBody.Controls.Clear();
			ButtonList = new Button[15, 15];
			Positions = new byte[15, 15];

			GenerateBombs();
			GeneratePositionValue();
			GenerateButtons();
		}

		private void btnRestart_Enter(object sender, EventArgs e)
		{
			label1.Focus();
		}
	}
}
