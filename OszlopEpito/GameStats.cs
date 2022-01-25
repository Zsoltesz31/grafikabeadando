using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OszlopEpito
{
    public class GameStats
    {
        private static bool PlaceToBuildIsNotGenerated = true;
        private static bool ObstaclesAreNotGenerated = true;
        private static bool BrickIsNotGenerated = true;
        private static int PlaceToBuildWidth = 200;
        private static int PlaceToBuildHeight = 20;
        private static int BrickHeight = 30;
        private static int BrickWidth = 20;
        private static int ObstacleCount = 7;
        private int canvasHeight;
        private int canvasWidth;
        private int requiredTowerHeight;
        private int currentTowerHeight = 0;
        private List<Rectangle> tower = new List<Rectangle>();
        public Rectangle[] generatedObstacles = new Rectangle[ObstacleCount];
        private Rectangle placeToBuild;
        public Rectangle Brick;
        private bool gamestarted = false;

        Random rnd = new Random();


        public bool Gamestarted
        {
            get { return gamestarted; }
            set { gamestarted = value; }
        }

        public int CanvasHeight
        {
            get { return canvasHeight; }
            set { canvasHeight = value; }
        }

        public int CanvasWidth
        {
            get { return canvasWidth; }
            set { canvasWidth = value; }
        }

        public Rectangle PlaceToBuild
        {
            get { return placeToBuild; }
            set { placeToBuild = value; }
        }

        public int RequiredTowerHeight
        {
            get { return requiredTowerHeight; }
            set { requiredTowerHeight = value; }
        }
        public int CurrentTowerHeight
        {
            get { return currentTowerHeight; }
            set { currentTowerHeight = value; }
        }
        public List<Rectangle> Tower
        {
            get { return tower; }
            set { tower = value; }
        }

        public Rectangle[] GeneratedObstacles
        {
            get { return generatedObstacles; }
            set { generatedObstacles = value; }
        }



        public GameStats(int towerheight)
        {
            requiredTowerHeight = towerheight;
        }

        public Rectangle generatePlaceToBuild()
        {
 
            if (PlaceToBuildIsNotGenerated)
            {
                placeToBuild = new Rectangle(rnd.Next(0, CanvasWidth - PlaceToBuildWidth), 0 + CanvasHeight - PlaceToBuildHeight - 1, PlaceToBuildWidth, PlaceToBuildHeight);
                PlaceToBuildIsNotGenerated = false;
            }
            return placeToBuild;
        }

        public Rectangle generateBrick()
        {
            Rectangle dummyBrick = Brick;
            if (BrickIsNotGenerated)
            {
                do
                {
                    dummyBrick = new Rectangle(rnd.Next(CanvasWidth - BrickWidth), CanvasHeight - BrickHeight - 1, BrickWidth, BrickHeight);
                } while (dummyBrick.IntersectsWith(PlaceToBuild));
            }
            BrickIsNotGenerated = false;
            return dummyBrick;
        }

        public void generateObstacle(Rectangle brick, Rectangle brick2)
        {
            Rectangle rect;
            
            if (ObstaclesAreNotGenerated)
            {
                for (int i = 0; i < GeneratedObstacles.Length; i++)
                {
                    GeneratedObstacles[i] = new Rectangle();
                }
                for (int i = 0; i < ObstacleCount; i++)
                {
                    int counter = 0;
                    do
                    {
                        int Rheight = 50;
                        int Rwidth = 50;
                        rect = new Rectangle(rnd.Next(CanvasWidth - Rwidth - 20), rnd.Next(CanvasHeight - Rheight - 35), Rwidth, Rheight);
                        counter++;
                    }
                    while (CheckObstacleIntersection(rect, brick));
                    Console.WriteLine(counter);
                    FillUpObstacles(rect, i);
                }
            }
            ObstaclesAreNotGenerated = false;

            
        }

        private bool CheckObstacleIntersection(Rectangle rect, Rectangle brick)
        {
            
            for (int i = 0; i < GeneratedObstacles.Length; i++)
            {
               

                if ( GeneratedObstacles[i].IntersectsWith(brick) || GeneratedObstacles[i].IntersectsWith(rect))
                {
                    return true;
                }
            }
            return false;
             
        }

        private void FillUpObstacles(Rectangle rect, int counter)
        {
            GeneratedObstacles[counter] = rect;
        }


        public void resetObjects()
        {
            PlaceToBuildIsNotGenerated = true;
            ObstaclesAreNotGenerated = true;
            BrickIsNotGenerated = true;
            Tower.Clear();
            PlaceToBuild = generatePlaceToBuild();
            Brick = generateBrick();
            generateObstacle(PlaceToBuild,Brick);
        }

        public void generateObjects()
        {
            PlaceToBuild = generatePlaceToBuild();
            Brick = generateBrick();
            generateObstacle(PlaceToBuild,Brick);
        }

        public void resetBrick()
        {
            BrickIsNotGenerated = true;
            ObstaclesAreNotGenerated = true;
            generateObstacle(PlaceToBuild,Brick);
            Brick = generateBrick();

        }

        public bool checkIfYouWon()
        {
            if (Tower.Count==RequiredTowerHeight)
            {
                return true;
            }
            return false;
        }





    }
}
