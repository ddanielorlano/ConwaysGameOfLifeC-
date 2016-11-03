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
        public class CellTag
        {
            public bool Live { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }

        private const int _sizeX = 5;
        private const int _sizeY = 5;
        private Button[,] _btnBoard { get; set; }

        public Form1()
        {
            InitializeComponent();
            AddButtonsToBoard();
        }
        private void AddButtonsToBoard()
        {
            _btnBoard = new Button[_sizeX, _sizeY];

            for (int x = 0; x < _sizeX; x++)
            {
                for (int y = 0; y < _sizeY; y++)
                {
                    var btn = new Button
                    {
                        Tag = new CellTag
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
     
        private void CellCick(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.Red;
                var tag = button.Tag as CellTag;
                if (tag != null)
                {
                    tag.Live = true;
                }
            }
        }
        private bool[,] GetGridFromBtns()
        {
            bool[,] grid = new bool[_sizeX, _sizeY];
            for (int x = 0; x < _sizeX; x++)
            {
                for (int y = 0; y < _sizeY; y++)
                {
                    var tag = _btnBoard[x, y].Tag as CellTag;
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
            for (int x = 0; x < _sizeX; x++)
            {
                for (int y = 0; y < _sizeY; y++)
                {
                    var btn = _btnBoard[x, y];
                    var tag = btn.Tag as CellTag;

                    if (tag != null)
                    {
                        tag.Live = gameGrid[x, y];
                        if (tag.Live)
                        {
                            btn.ForeColor = Color.Red;
                            Console.WriteLine($"tag.Live={tag.Live}");
                        }
                        
                        //btn.ForeColor = Color.Beige;
                    }

                }
            }
        }

        private Game Game { get; set; }
        private Timer GameTimer { get; set; }

        private void startBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                Game = new Game();
                GameTimer = new Timer();
                GameTimer.Tick += GameTimer_Tick;
                GameTimer.Start();
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            var grid = GetGridFromBtns();
            if(Game != null)
            {
                var nextGrid = Game.Update(grid, _sizeX, _sizeY);
                UpdateBtnGrid(nextGrid);
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            StopTimer();
        }

        private void StopTimer()
        {
            if (GameTimer != null)
            {
                GameTimer.Stop();
            }
        }
    }
}
