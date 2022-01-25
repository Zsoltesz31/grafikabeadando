using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrafikaDLL;

namespace OszlopEpito
{
    public partial class Form2 : Form
    {
        Graphics g;
        bool grabbed = false;
        GameStats gs = new GameStats(10);
        public int selectedHeight;
        int dx;
        int dy;
        bool collisionWithObstacle = false;
        bool outOfCanvas = false;
        bool collideWithTower = false;
        public Form2()
        {

            InitializeComponent();
            this.TopMost = true;
            gs.CanvasWidth = canvas.Width;
            gs.CanvasHeight = canvas.Height;
            gs.generateObjects();
            heightSelection.SelectedIndex = 0;

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (gs.Gamestarted)
            {
                g = e.Graphics;
                if (collisionWithObstacle)
                {
                    grabbed = false;
                    gs.resetObjects();
                    collisionWithObstacle = false;
                }
                g.FillRectangle(Brushes.Blue, gs.PlaceToBuild);
                g.FillRectangle(Brushes.Blue, gs.Brick);
                paintTower();
                modifyTexts();

                GenerateFog();
            }


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            selectedHeight = int.Parse(heightSelection.SelectedItem.ToString());
            gs.RequiredTowerHeight = selectedHeight;
            leiras.Visible = false;
            heightSelection.Enabled = false;
            button1.Enabled = false;
            gs.Gamestarted = true;
            button2.Enabled = true;
            modifyTexts();
            canvas.Invalidate();
        }

        private void DrawObstacles()
        {

            for (int i = 0; i < gs.GeneratedObstacles.Length; i++)
            {
                g.DrawRectangle(new Pen(Color.Red), gs.GeneratedObstacles[i]);
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (e.Catch(gs.Brick, out dx, out dy))
                    {
                        grabbed = true;
                    }
                    
                    break;
                case MouseButtons.Middle: break;
                case MouseButtons.Right: break;
                default: break;
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    grabbed = false;
                    outOfCanvas = false;
                    collideWithTower = false;
                    checkGamestatus();
                    canvas.Invalidate();
                    break;
                case MouseButtons.Middle: break;
                case MouseButtons.Right: break;
                default: break;
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (grabbed)
                    {                    
     
                        if (!outOfCanvas && !collideWithTower)
                        {
                            gs.Brick.X = e.X - dx;
                            gs.Brick.Y = e.Y - dy;
                        }
                        outOfCanvas = isRectOutOfCanvas();
                        for (int i = 0; i < gs.Tower.Count; i++)
                        {
                            if (TowerSideCollision(gs.Tower[i]))
                            {
                                collideWithTower = true;
                                break;
                            }
                        }
                        ObstacleCollision();
                        Build();
                        modifyTexts();
                        canvas.Invalidate();
                    }
                    break;
                case MouseButtons.Middle: break;
                case MouseButtons.Right: break;
                default: break;
            }
        }

        public void ObstacleCollision()
        {
            if (gs.GeneratedObstacles.Any(r => r.IntersectsWith(gs.Brick)))
            {
                MessageBox.Show("Sajnos vesztettél! Próbáld újra!");
                collisionWithObstacle = true;

            }
        }

        public bool TowerCollision(Rectangle rect)
        {
            if ((gs.Brick.X + gs.Brick.Width > rect.X && gs.Brick.X + gs.Brick.Width < rect.X + rect.Width
               || gs.Brick.X > rect.X && gs.Brick.X < rect.X + rect.Width)
               && gs.Brick.Y + gs.Brick.Height == rect.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TowerSideCollision(Rectangle rect)
        {
            if ((gs.Brick.Left < rect.Right &&
               gs.Brick.Right > rect.Right &&
               gs.Brick.Bottom > rect.Top &&
               gs.Brick.Top <rect.Bottom) ||
               (gs.Brick.Right > rect.Left &&
               gs.Brick.Left < rect.Left &&
               gs.Brick.Bottom > rect.Top &&
               gs.Brick.Top < rect.Bottom))
            {
                return true;
                
            }
            else
            {
                return false;
            }
        }

        public bool isRectOutOfCanvas()
        {
            if (gs.Brick.X < 0 || gs.Brick.X > canvas.Width - gs.Brick.Width || gs.Brick.Y < 0 || gs.Brick.Y > canvas.Height - gs.Brick.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Build()
        {
            Rectangle brick = gs.Brick;
            if (gs.Tower.Count == 0)
            {
                
                if (gs.Brick.IntersectsWith(gs.PlaceToBuild))
                {
                    brick.X = gs.PlaceToBuild.X + (gs.PlaceToBuild.Width / 2) - (gs.Brick.Width / 2);
                    brick.Y = gs.PlaceToBuild.Y - gs.PlaceToBuild.Height - 1;
                    gs.Tower.Add(brick);
                    gs.resetBrick();
                    grabbed = false;
                }
            }
            else
            {
                if (TowerCollision(gs.Tower[gs.Tower.Count - 1]))
                {
                    
                    brick.X = gs.PlaceToBuild.X + (gs.PlaceToBuild.Width / 2) - (gs.Brick.Width / 2);
                    brick.Y = gs.Tower[gs.Tower.Count - 1].Y - gs.Brick.Height;
                    gs.Tower.Add(brick);
                    gs.resetBrick();
                    grabbed = false;
                }
            }
        }
        public void paintTower()
        {
            for (int i = 0; i < gs.Tower.Count; i++)
            {
                g.FillRectangle(Brushes.Blue, gs.Tower[i]);
            }

        }

        public void GenerateFog()
        {
            Point p0 = new Point(gs.GeneratedObstacles[1].Left, gs.GeneratedObstacles[1].Top);
            Point p1 = new Point(gs.GeneratedObstacles[1].Right, gs.GeneratedObstacles[1].Top);
            Point p2 = new Point(gs.GeneratedObstacles[1].Left, gs.GeneratedObstacles[1].Bottom);
            PointF[] ObstaclePoints = new PointF[7];
            Rectangle fog = new Rectangle(gs.Brick.X - gs.Brick.Width, gs.Brick.Y - gs.Brick.Height+10, gs.Brick.Width + 40, gs.Brick.Height + 40);
            g.DrawRectangle(Pens.Black, gs.Brick.X-gs.Brick.Width,gs.Brick.Y-gs.Brick.Height+10,gs.Brick.Width+40,gs.Brick.Height+40);
            for (int j = 0; j < gs.GeneratedObstacles.Length; j++)
            {

                g.Clip(Pens.Red, fog, gs.GeneratedObstacles[j]);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            leiras.Visible = true;
            heightSelection.Enabled = true;
            button1.Enabled = true;
            gs.Gamestarted = false;
            gs.resetObjects();
            canvas.Invalidate();
        }

        private void checkGamestatus()
        {
            if (gs.checkIfYouWon())
            {
                MessageBox.Show("Gratulálok nyertél!");
                gs.resetObjects();
                leiras.Visible = true;
                heightSelection.Enabled = true;
                button1.Enabled = true;
                gs.Gamestarted = false;
                gs.resetObjects();
                requiredHeightTxt.Text = "Elérendő magasság: ";
                currentHeightTxt.Text = "Jelenlegi magasság: ";
                canvas.Invalidate();
            }
        }

        private void modifyTexts()
        {
            requiredHeightTxt.Text  = "Elérendő magasság: " + gs.RequiredTowerHeight;
            currentHeightTxt.Text = "Jelenlegi magasság: " + gs.Tower.Count;
        }
    }


}
