using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife
{
    public partial class Form1 : Form
    {
        private const int _sizeX = 50;
        private const int _sizeY = 50;
        private Button[,] _btnBoard { get; set; }

        public Form1()
        {
            InitializeComponent();
            AddButtonsToBoard();
        }
        private void AddButtonsToBoard()
        {
            _btnBoard = new Button[_sizeX, _sizeY];

            for (int x = 0; x < _sizeX - 1; x++)
            {
                for (int y = 0; y < _sizeY - 1; y++)
                {
                    var btn = new Button
                    {
                        Tag = new Tag
                        {
                            Live = false,
                            X = x,
                            Y = y
                        }

                    };
                    btn.Click += new EventHandler(CellCick);
                    btn.Height = 10;
                    btn.Size = new Size(15, 15);

                    _btnBoard[x, y] = btn;
                    this.flowLayoutPanel1.Controls.Add(btn);
                }
            }

        }
        public class Tag
        {
            public bool Live { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }
        private void CellCick(object sender, EventArgs e)
        {

            var button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.Red;
                var tag = button.Tag as Tag;
                if (tag != null)
                {
                    tag.Live = false;
                }
            }
        }
        private bool[,] GetGridFromBtns()
        {
            bool[,] grid = new bool[_sizeX, _sizeY];
            for (int x = 0; x < _sizeX - 1; x++)
            {
                for (int y = 0; y < _sizeY - 1; y++)
                {
                    var tag = _btnBoard[x, y].Tag as Tag;
                    if (tag != null)
                    {
                        grid[x, y] = tag.Live;
                    }

                }
            }
            return grid;
        }
        private void UpdateBtnGrid(bool [,] gameGrid)
        {
            for (int x = 0; x < _sizeX - 1; x++)
            {
                for (int y = 0; y < _sizeY - 1; y++)
                {
                    var btn = _btnBoard[x, y];
                    var tag = btn.Tag as Tag;

                    if (tag != null)
                    {
                        tag.Live = gameGrid[x, y];
                        if (tag.Live)
                        {
                            btn.ForeColor = Color.Red;
                        }
                        btn.ForeColor = Color.Beige;
                    }

                }
            }
        }
        private void startBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                var grid = GetGridFromBtns();
                Timer t = new Timer
                {
                    Enabled = true,
                    
                };
            }
        }
    }
}
