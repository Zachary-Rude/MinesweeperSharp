using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Samples;

namespace Minesweeper
{
	public partial class Form1: Form
	{
		int boardWidth = 15;
		int boardHeight = 15;
		int oldWidth;
		int oldHeight;
		int totalBombs = 99;
		byte[,] Positions = new byte[16, 30];
		Button[,] ButtonList = new Button[16, 30];
		TaskDialog taskDialog;
		int timerMS = 0;
		int timer = 0;
		bool timerStarted = false;
		int bombsFound = 0;
		public Form1()
		{
			InitializeComponent();
			timer1.Stop();
			Positions = new byte[boardWidth, boardHeight];
			ButtonList = new Button[boardWidth, boardHeight];
			this.Icon = Properties.Resources.icon;
			menuStrip1.Renderer = new ToolStripAeroRenderer(ToolbarTheme.Toolbar);
			TaskDialogButton btnPlayAgain = new TaskDialogButton()
			{
				ButtonId = 100,
				ButtonText = "&Play Again"
			};
			TaskDialogButton btnClose = new TaskDialogButton()
			{
				ButtonId = 101,
				ButtonText = "&Close"
			};
			taskDialog = new TaskDialog()
			{
				WindowTitle = "MinesweeperSharp",
				MainInstruction = "Game Over!",
				Content = $"Score: {points} {(points == 1 ? "point" : "points")}\r\nFlags used: {totalBombs - flag} {(totalBombs - flag == 1 ? "flag" : "flags")}\r\nTime taken: {timer} {(timer == 1 ? "second" : "seconds")}\r\nDo you want to try again?",
				MainIcon = TaskDialogIcon.Information,
				Buttons = new TaskDialogButton[] { btnPlayAgain, btnClose }
			};
			GenerateBombs();
			GeneratePositionValue();
			GenerateButtons();
			label1.Focus();
		}
		protected T[,] ResizeArray<T>(T[,] original, int x, int y)
		{
			T[,] newArray = new T[x, y];
			int minX = Math.Min(original.GetLength(0), newArray.GetLength(0));
			int minY = Math.Min(original.GetLength(1), newArray.GetLength(1));

			for (int i = 0; i < minY; ++i)
				Array.Copy(original, i * original.GetLength(0), newArray, i * newArray.GetLength(0), minX);

			return newArray;
		}

		Random rnd = new Random();
		private void GenerateBombs()
		{
			int bombs = 0;
			while (bombs < totalBombs)
			{
				int x = rnd.Next(0, boardWidth - 1);
				int y = rnd.Next(0, boardHeight - 1);

				if (Positions[x, y] == 0)
				{
					Positions[x, y] = 10;
					bombs++;
				}
			}
		}

		private void GeneratePositionValue()
		{
			for (int x = 0; x < boardWidth; x++)
			{
				for (int y = 0; y < boardHeight; y++)
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

							if (checkerX == -1 || checkerY == -1 || checkerX > boardWidth - 1 || checkerY > boardHeight - 1)
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
			for (int x = 0; x < boardWidth; x++)
			{
				for (int y = 0; y < boardHeight; y++)
				{
					Button btn = new Button();
					btn.Parent = pnlBody;
					btn.Location = new Point(xLoc, yLoc);
					btn.Size = new Size(25, 22);
					btn.Font = new Font("Consolas", 8.25F);
					btn.Tag = $"{x},{y}";
					btn.Click += BtnClick;
					btn.MouseDown += BtnMouseDown;
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
			if (!timerStarted)
			{
				timerStarted = true;
				timer1.Start();
			}
			if (value == 10)
			{
				timerStarted = false;
				timer1.Stop();
				btnRestart.Image = Properties.Resources.dizzy_face_1f635;
				btn.Font = new Font("Segoe UI Emoji", 8.25F);
				btn.Text = "💣";

				pnlBody.Enabled = false;
				taskDialog.MainInstruction = "Game Over!";
				taskDialog.Content = $"Score: {points} {(points == 1 ? "point" : "points")}\r\nFlags used: {totalBombs - flag} {(totalBombs - flag == 1 ? "flag" : "flags")}\r\nTime taken: {timer} {(timer == 1 ? "second" : "seconds")}\r\nDo you want to try again?";
				int dr = taskDialog.Show();
				if (dr == 101)
					this.Close();
				else
					btnRestart.PerformClick();
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

					if (checkerX == -1 || checkerY == -1 || checkerX > boardWidth - 1 || checkerY > boardHeight - 1)
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
			btnRestart.Image = Properties.Resources.slightly_smiling_face_1f642;
			if (e.Button == MouseButtons.Right)
			{
				Button btn = (Button)sender;
				if (string.IsNullOrEmpty(btn.Text))
				{
					if (flag > 0)
					{
						btn.Text = "🚩";
						btn.Font = new Font("Segoe UI Emoji", 8.25F);
						btn.Click -= BtnClick;
						flag--;
						int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
						int y = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));
						if (Positions[x, y] == 10)
						{
							bombsFound++;
							if (bombsFound == totalBombs)
							{
								timer1.Stop();
								timerStarted = false;
								btnRestart.Image = Properties.Resources.smiling_face_with_sunglasses_1f60e;
								pnlBody.Enabled = false;
								taskDialog.MainInstruction = "You Win!!";
								taskDialog.Content = $"Score: {points} {(points == 1 ? "point" : "points")}\r\nFlags used: {totalBombs - flag} {(totalBombs - flag == 1 ? "flag" : "flags")}\r\nTime taken: {timer} {(timer == 1 ? "second" : "seconds")}\r\nDo you want to try again?";
								int dr = taskDialog.Show();
								if (dr == 101)
									this.Close();
								else
									btnRestart.PerformClick();
							}
						}
					}
				}
				else if (!int.TryParse(btn.Text, out _))
				{
					btn.Text = "";
					btn.Font = new Font("Consolas", 8.25F);
					btn.Click += BtnClick;
					flag++;
					int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
					int y = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));
					if (Positions[x, y] == 10)
						bombsFound--;
				}
				textBox1.Text = flag.ToString();
			}
		}

		private void BtnMouseDown(object sender, MouseEventArgs e)
		{
			btnRestart.Image = Properties.Resources.face_with_open_mouth_1f62e;
		}

		private void btnRestart_Click(object sender, EventArgs e)
		{
			timerStarted = false;
			btnRestart.Image = Properties.Resources.slightly_smiling_face_1f642;
			points = 0;
			flag = totalBombs;
			textBox1.Text = flag.ToString();
			timerMS = 0;
			timer = 0;
			textBox2.Text = timer.ToString();

			for (int x = 0; x < boardWidth; x++)
			{
				for (int y = 0; y < boardHeight; y++)
				{
					ButtonList[x, y].Dispose();
				}
			}

			this.Width = ((boardWidth == boardHeight ? boardWidth : boardHeight) * 25) + 22;
			this.Height = ((boardHeight == boardWidth ? boardHeight : boardWidth) * 22) + 152;
			byte[,] newPositions = new byte[boardWidth, boardHeight];
			Button[,] newButtonList = new Button[boardWidth, boardHeight];
			Positions = newPositions;
			ButtonList = newButtonList;
			pnlBody.Enabled = true;
			pnlBody.Controls.Clear();
			GenerateBombs();
			GeneratePositionValue();
			GenerateButtons();
			label1.Focus();
		}

		private void btnRestart_Enter(object sender, EventArgs e)
		{
			label1.Focus();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timerMS += 100;
			if (timerMS == 1000)
			{
				timer++;
				timerMS = 0;
				textBox2.Text = timer.ToString();
			}
		}

		private void difficultyMenu_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
			bool sameItem = clickedItem.Checked;
			foreach (ToolStripMenuItem item in difficultyToolStripMenuItem.DropDownItems)
			{
				item.Checked = item == clickedItem;
			}

			if (!sameItem)
			{
				oldWidth = boardWidth;
				oldHeight = boardHeight;
				timerStarted = false;
				btnRestart.Image = Properties.Resources.slightly_smiling_face_1f642;
				points = 0;
				timerMS = 0;
				timer = 0;
				textBox2.Text = timer.ToString();

				for (int x = 0; x < oldWidth; x++)
				{
					for (int y = 0; y < oldHeight; y++)
					{
						ButtonList[x, y].Dispose();
					}
				}
				if (clickedItem == beginnerToolStripMenuItem)
				{
					boardWidth = 8;
					boardHeight = 8;
					totalBombs = 10;
				}
				else if (clickedItem == intermediateToolStripMenuItem)
				{
					boardWidth = 15;
					boardHeight = 15;
					totalBombs = 30;
				}
				else if (clickedItem == expertToolStripMenuItem)
				{
					boardWidth = 30;
					boardHeight = 16;
					totalBombs = 99;
				}
				flag = totalBombs;
				textBox1.Text = flag.ToString();

				this.Width = ((boardWidth == boardHeight ? boardWidth : boardHeight) * 25) + 22;
				this.Height = ((boardHeight == boardWidth ? boardHeight : boardWidth) * 22) + 152;
				byte[,] newPositions = new byte[boardWidth, boardHeight];
				Button[,] newButtonList = new Button[boardWidth, boardHeight];
				Positions = newPositions;
				ButtonList = newButtonList;
				pnlBody.Enabled = true;
				pnlBody.Controls.Clear();
				GenerateBombs();
				GeneratePositionValue();
				GenerateButtons();
				label1.Focus();
			}
		}
	}
}
