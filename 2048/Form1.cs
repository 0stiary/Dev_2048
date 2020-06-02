using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _2048
{
	public partial class Form1 : Form
	{

		PictureBox[,] cells = new PictureBox[4, 4];

		int[,] map = new int[4, 4];
		Label[,] labels = new Label[4, 4];

		int score = 0;
		int value = 2;

		Random rand = new Random();

		public Form1()
		{
			InitializeComponent();
		}

		private void CreateMap()
		{
			for(int i = 0; i < 4; i++)
			{
				for(int j = 0; j < 4; j++)
				{
					PictureBox cell = new PictureBox();
					cell.Location = new Point(15 + 66 * j, 40 + 66 * i);
					cell.Size = new Size(60, 60);
					cell.BackColor = SystemColors.ActiveBorder;
					this.Controls.Add(cell);
				}
			}
		}

		private void NewCell()
		{

			int a = rand.Next(0, 4);
			int b = rand.Next(0, 4);

			while(cells[a, b] != null)
			{
				a = rand.Next(0, 4);
				b = rand.Next(0, 4);
			}

			map[a, b] = 1;
			cells[a, b] = new PictureBox();

			labels[a, b] = new Label();
			labels[a, b].Text = (rand.Next(1,3) * value).ToString();
			labels[a, b].Size = new Size(60, 60);
			labels[a, b].TextAlign = ContentAlignment.MiddleCenter;
			labels[a, b].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point);

			cells[a, b].Controls.Add(labels[a, b]);
			cells[a, b].Location = new Point(15 + 66 * b, 40 + 66 * a);
			cells[a, b].Size = new Size(60, 60);
			cells[a, b].BorderStyle = BorderStyle.Fixed3D;
			ChangeColor(Convert.ToInt32(labels[a,b].Text), a, b);
			this.Controls.Add(cells[a, b]);
			cells[a, b].BringToFront();
		}

		private void ChangeColor(int sum, int i, int j)
		{
			if(sum % (value * 1024) == 0) cells[i, j].BackColor = Color.OrangeRed;
			else if(sum % (value * 512) == 0) cells[i, j].BackColor = Color.Pink;
			else if(sum % (value * 256) == 0) cells[i, j].BackColor = Color.Red;
			else if(sum % (value * 128) == 0) cells[i, j].BackColor = Color.DarkViolet;
			else if(sum % (value * 64) == 0) cells[i, j].BackColor = Color.Blue;
			else if(sum % (value * 32) == 0) cells[i, j].BackColor = Color.Brown;
			else if(sum % (value * 16) == 0) cells[i, j].BackColor = Color.Coral;
			else if(sum % (value * 8) == 0) cells[i, j].BackColor = Color.Cyan;
			else if(sum % (value * 4) == 0) cells[i, j].BackColor = Color.Maroon;
			else if(sum % (value * 2) == 0) cells[i, j].BackColor = Color.Green;
			else if(sum % (value) == 0) cells[i, j].BackColor = Color.DarkOrange;

			;
		}

		private void Pressed_Key(object sender, KeyEventArgs e)
		{
			bool ifMoved = false;
			switch(e.KeyCode.ToString())
			{
				case "Right":
				{
					for(int k = 0; k < 4; k++)
					{
						for(int l = 2; l >= 0; l--)
						{
							if(map[k, l] == 1)
							{
								for(int j = l + 1; j < 4; j++)
								{
									if(map[k, j] == 0)
									{
										map[k, j - 1] = 0;
										map[k, j] = 1;
										cells[k, j] = cells[k, j - 1];
										cells[k, j - 1] = null;
										labels[k, j] = labels[k, j - 1];
										labels[k, j - 1] = null;
										cells[k, j].Location = new Point(cells[k, j].Location.X + 66, cells[k, j].Location.Y);
										ifMoved = true;
										Thread.Sleep(7);
									}
									else
									{
										int a = int.Parse(labels[k, j].Text);
										int b = int.Parse(labels[k, j - 1].Text);
										if(a == b)
										{
											labels[k, j].Text = (a + b).ToString();
											map[k, j - 1] = 0;
											//map[k, j] = 1;
											this.Controls.Remove(cells[k, j - 1]);
											this.Controls.Remove(labels[k, j - 1]);
											cells[k, j - 1] = null;
											labels[k, j - 1] = null;

											score += a + b;
											score_label.Text = "Score : " + score;

											ChangeColor(a + b, k, j);

											ifMoved = true;
										}
									}
								}
							}
						}
					}
					if(ifMoved)
						NewCell();
					break;
				}
				case "Left":
				{
					for(int k = 0; k < 4; k++)
					{
						for(int l = 1; l < 4; l++)
						{
							if(map[k, l] == 1)
							{
								for(int j = l - 1; j >= 0; j--)
								{
									if(map[k, j] == 0)
									{
										map[k, j + 1] = 0;
										map[k, j] = 1;
										cells[k, j] = cells[k, j + 1];
										cells[k, j + 1] = null;
										labels[k, j] = labels[k, j + 1];
										labels[k, j + 1] = null;
										cells[k, j].Location = new Point(cells[k, j].Location.X - 66, cells[k, j].Location.Y);

										ifMoved = true;
										Thread.Sleep(7);
									}
									else
									{
										int a = int.Parse(labels[k, j].Text);
										int b = int.Parse(labels[k, j + 1].Text);
										if(a == b)
										{
											labels[k, j].Text = (a + b).ToString();
											map[k, j + 1] = 0;
											//map[k, j] = 1;
											this.Controls.Remove(cells[k, j + 1]);
											this.Controls.Remove(labels[k, j + 1]);
											cells[k, j + 1] = null;
											labels[k, j + 1] = null;

											score += a + b;
											score_label.Text = "Score : " + score;

											ChangeColor(a + b, k, j);

											ifMoved = true;
										}
									}
								}
							}
						}
					}
					if(ifMoved)
						NewCell();
					break;
				}
				case "Down":
				{
					for(int k = 2; k >= 0; k--)     //rows
					{
						for(int l = 0; l < 4; l++)      //columns
						{
							if(map[k, l] == 1)
							{
								for(int j = k + 1; j < 4; j++)      //cells
								{
									if(map[j, l] == 0)
									{
										map[j - 1, l] = 0;
										map[j, l] = 1;
										cells[j, l] = cells[j - 1, l];
										cells[j - 1, l] = null;
										labels[j, l] = labels[j - 1, l];
										labels[j - 1, l] = null;
										cells[j, l].Location = new Point(cells[j, l].Location.X, cells[j, l].Location.Y + 66);

										ifMoved = true;
										Thread.Sleep(7);
									}
									else                //Сократить?
									{
										int a = int.Parse(labels[j, l].Text);
										int b = int.Parse(labels[j - 1, l].Text);
										if(a == b)
										{
											labels[j, l].Text = (a + b).ToString();
											map[j - 1, l] = 0;
											//map[j, l] = 1;
											this.Controls.Remove(cells[j - 1, l]);
											this.Controls.Remove(labels[j - 1, l]);
											cells[j - 1, l] = null;
											labels[j - 1, l] = null;

											score += a + b;
											score_label.Text = "Score : " + score;

											ChangeColor(a + b, j, l);

											ifMoved = true;
										}
									}
								}
							}
						}
					}
					if(ifMoved)
						NewCell();
					break;
				}
				case "Up":
				{
					for(int k = 1; k < 4; k++)     //rows
					{
						for(int l = 0; l < 4; l++)      //columns
						{
							if(map[k, l] == 1)
							{
								for(int j = k - 1; j >= 0; j--)      //cells
								{
									if(map[j, l] == 0)
									{
										map[j + 1, l] = 0;
										map[j, l] = 1;
										cells[j, l] = cells[j + 1, l];
										cells[j + 1, l] = null;
										labels[j, l] = labels[j + 1, l];
										labels[j + 1, l] = null;
										cells[j, l].Location = new Point(cells[j, l].Location.X, cells[j, l].Location.Y - 66);

										ifMoved = true;
										Thread.Sleep(7);
									}
									else                //Сократить?
									{
										int a = int.Parse(labels[j, l].Text);
										int b = int.Parse(labels[j + 1, l].Text);
										if(a == b)
										{
											labels[j, l].Text = (a + b).ToString();
											map[j + 1, l] = 0;
											//map[j, l] = 1;
											this.Controls.Remove(cells[j + 1, l]);
											this.Controls.Remove(labels[j + 1, l]);
											cells[j + 1, l] = null;
											labels[j + 1, l] = null;

											score += a + b;
											score_label.Text = "Score : " + score;

											ChangeColor(a + b, j, l);

											ifMoved = true;
										}
									}
								}
							}
						}
					}
					if(ifMoved)
						NewCell();
					break;
				}


				default:
				break;
			}
		}

		private void value_list_SelectedValueChanged(object sender, EventArgs e)
		{
			value = Convert.ToInt32(value_list.SelectedItem.ToString());
			Controls.Remove(value_list);

			KeyDown += new KeyEventHandler(Pressed_Key);
			CreateMap();
			NewCell();
		}
	}
}
