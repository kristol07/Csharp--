using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public partial class Form1 : Form
    {

        public Button button1;
        public List<TextBox> textboxes;

        private string[,] sudokuTable;

        public Form1()
        {

            sudokuTable = new string[9, 9];

            Width = 410;
            Height = 500;

            textboxes = new List<TextBox>();
            int numberOfTextbox = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    textboxes.Add(new TextBox() { Size = new Size(30, 30) });
                    textboxes[numberOfTextbox].Location = new Point(30 + 40 * i, 30 + 40 * j);
                    this.Controls.Add(textboxes[numberOfTextbox]);
                    textboxes[numberOfTextbox].TextChanged += new EventHandler(textbox_TextChanged);
                    numberOfTextbox++;
                }
            }

            button1 = new Button();
            button1.Size = new Size(110, 50);
            button1.Location = new Point(150, 400);
            button1.Text = "Solve";
            this.Controls.Add(button1);
            button1.Click += new EventHandler(button1_Click);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] mySudokuTable = new int[9,9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (string.IsNullOrWhiteSpace(sudokuTable[i,j]))
                    {
                        mySudokuTable[i, j] = 0;
                    }
                    else
                    {
                        mySudokuTable[i, j] = Int32.Parse(sudokuTable[i, j]);
                    }
                }
            }

            SudokuSolver mySudoku = new SudokuSolver(mySudokuTable);

            mySudoku.Solve();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    textboxes[i * 9 + j].Text = mySudoku.SodokuTable[i,j].ToString();
                }
            }

        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudokuTable[i, j] = textboxes[i * 9 + j].Text;
                }
            }
        }

    }
}
