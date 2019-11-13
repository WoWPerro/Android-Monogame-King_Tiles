using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace testandroid
{
    class Grid
    {
        int SCREENSIZE_Y = testandroid.Activity1.ScreenHeight;
        int SCREENSIZE_X = testandroid.Activity1.ScreenWidth;
        float TileSizeX = 0;
        float TileSizeY = 0;
        public static int _xSize = 0;
        public static int _ySize = 0;
        public List<Tile> Tiles = new List<Tile>();
        float GridSizeX;
        float GridSizeY;

        public Grid(int x, int y)
        {
            _xSize = x;
            _ySize = y;
            GridSizeX = SCREENSIZE_X / x;
            GridSizeY = SCREENSIZE_Y / y;
            TileSizeX = GridSizeX;
            TileSizeY = GridSizeY;
        }

        public bool Move(int x)
        {
            bool moving = false;
            switch (x)
            {
                case 1:
                    //Arriba
                    for (int i = 0; i < Tiles.Count; i++)
                    {
                        if (Tiles[i].GetYScreen() < 0)
                        {
                            //Dont move
                        }

                        else if (CheckOcupied(Tiles[i].GetX(), Tiles[i].GetY() - 1))
                        {
                            Tile temp = GetTile(Tiles[i].GetX(), Tiles[i].GetY() - 1);
                            if (temp._image == Tiles[i]._image)
                            {
                                Tiles[i].advanceY(false);
                                moving = true;
                                if(temp.GetYScreen() >= Tiles[i].GetYScreen()- 150 && temp.GetYScreen() <= Tiles[i].GetYScreen()+ 150 && temp.GetXScreen() >= Tiles[i].GetXScreen() - 150 && temp.GetXScreen() <= Tiles[i].GetXScreen() + 150)
                                {
                                    //Evolve();
                                    Tiles.Remove(temp);
                                    try
                                    {
                                        Tiles[i]._image += 1;
                                    }
                                    catch (Exception)
                                    {
                                        Tiles[i - 1]._image += 1;
                                    }
                                }
                            }

                            else
                            {
                                //Dont move
                            }
                        }

                        else
                        {
                            Tiles[i].advanceY(false);
                            moving = true;
                        }
                    }
                    break;

                case 2:
                    //Abajo
                    for (int i = 0; i < Tiles.Count; i++)
                    {
                        if (Tiles[i].GetYScreen() + TileSizeY > SCREENSIZE_Y)
                        {
                            //Dont move
                        }

                        else if (CheckOcupied(Tiles[i].GetX(), Tiles[i].GetY() + 1))
                        {
                            Tile temp = GetTile(Tiles[i].GetX(), Tiles[i].GetY() + 1);
                            if (temp._image == Tiles[i]._image)
                            {
                                Tiles[i].advanceY(true);
                                moving = true;
                                if (temp.GetYScreen() >= Tiles[i].GetYScreen() - 150 && temp.GetYScreen() <= Tiles[i].GetYScreen() + 150 && temp.GetXScreen() >= Tiles[i].GetXScreen() - 150 && temp.GetXScreen() <= Tiles[i].GetXScreen() + 150)
                                {
                                    //Evolve();
                                    Tiles.Remove(temp);
                                    try
                                    {
                                        Tiles[i]._image += 1;
                                    }
                                    catch (Exception)
                                    {
                                        Tiles[i - 1]._image += 1;
                                    }
                                }
                            }

                            else
                            {
                                //Dont move
                            }
                        }

                        else
                        {
                            Tiles[i].advanceY(true);
                            moving = true;
                        }
                    }
                    break;

                case 3:
                    //Izquierda
                    for (int i = 0; i < Tiles.Count; i++)
                    {
                        if (Tiles[i].GetXScreen() < 0)
                        {
                            //Dont move
                        }

                        else if (CheckOcupied(Tiles[i].GetX() - 1, Tiles[i].GetY()))
                        {
                            Tile temp = GetTile(Tiles[i].GetX() - 1, Tiles[i].GetY());
                            if (temp._image == Tiles[i]._image)
                            {
                                Tiles[i].advanceX(false);
                                moving = true;
                                if (temp.GetXScreen() >= Tiles[i].GetXScreen() - 150 && temp.GetXScreen() <= Tiles[i].GetXScreen() + 150 && temp.GetYScreen() >= Tiles[i].GetYScreen() - 150 && temp.GetYScreen() <= Tiles[i].GetYScreen() + 150)
                                {
                                    //Evolve();
                                    Tiles.Remove(temp);
                                    try
                                    {
                                        Tiles[i]._image += 1;
                                    }
                                    catch (Exception)
                                    {
                                        Tiles[i - 1]._image += 1;
                                    }
                                }
                            }

                            else
                            {
                                //Dont move
                            }
                        }

                        else
                        {
                            Tiles[i].advanceX(false);
                            moving = true;
                        }
                    }
                    break;

                case 4:
                    //Derecha
                    for (int i = 0; i < Tiles.Count; i++)
                    {
                        if (Tiles[i].GetXScreen() > SCREENSIZE_X - TileSizeX)
                        {
                            //Dont move
                        }

                        else if (CheckOcupied(Tiles[i].GetX() + 1, Tiles[i].GetY()))
                        {
                            Tile temp = GetTile(Tiles[i].GetX() + 1, Tiles[i].GetY());
                            if (temp._image == Tiles[i]._image)
                            {
                                Tiles[i].advanceX(true);
                                moving = true;
                                if (temp.GetXScreen() >= Tiles[i].GetXScreen() - 150 && temp.GetXScreen() <= Tiles[i].GetXScreen() + 150 && temp.GetYScreen() >= Tiles[i].GetYScreen() - 150 && temp.GetYScreen() <= Tiles[i].GetYScreen() + 150)
                                {
                                    //Evolve();
                                    Tiles.Remove(temp);
                                    try
                                    {
                                        Tiles[i]._image += 1;
                                    }
                                    catch(Exception)
                                    {
                                        Tiles[i - 1]._image += 1;
                                    }
                                }
                            }

                            else
                            {
                                //Dont move
                            }
                        }

                        else
                        {
                            Tiles[i].advanceX(true);
                            moving = true;
                        }
                    }
                    break;
            }
            return moving;
        }

        bool CheckLoose()
        {
            bool lost = true;

            if (Tiles.Count < _xSize*_ySize)
            {
                lost = false;
            }
            else if (Tiles.Count == _xSize * _ySize)
            {

            }
            return lost;
        }

        bool CheckOcupied(int x, int y)
        {
            if (Tiles.Count == 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Tiles.Count; i++)
                {
                    if (Tiles[i].GetX() == x && Tiles[i].GetY() == y)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        public void Generatenew()
        {
            int a = 0;
            int b = 0;
            bool c = true;
            if (!CheckLoose())
            {
                while(c)
                {
                    a = RandomNumber(0, _xSize);
                    b = RandomNumber(0, _ySize);
                    if (!CheckOcupied(a, b))
                    {
                        c = false;
                    }
                }

                Tiles.Add(new Tile(a,b, GridSizeX, GridSizeY));
            }
            else
            {
                //gameover
            }
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public Tile GetTile(int x, int y)
        {
            if (Tiles.Count == 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < Tiles.Count; i++)
                {
                    if (Tiles[i].GetX() == x && Tiles[i].GetY() == y)
                    {
                        return Tiles[i];
                    }
                }
                return null;
            }
        }

        public void UpdatePositions()
        {
            if (Tiles.Count == 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < Tiles.Count; i++)
                {
                    Tiles[i].updatePositions();
                }
            }
        }

        public void checkColisions()
        {
            for (int i = 0; i < Tiles.Count; i++)
            {
                try
                {
                    if(GetTile(Tiles[i].GetX() + 1, Tiles[i].GetY()) != null)
                    {
                        Tile temp = GetTile(Tiles[i].GetX() + 1, Tiles[i].GetY());
                        if (temp._image == Tiles[i]._image)
                        {
                            if (temp.GetXScreen() >= Tiles[i].GetXScreen() - 50 && temp.GetXScreen() <= Tiles[i].GetXScreen() + 50 && temp.GetYScreen() >= Tiles[i].GetYScreen() - 50 && temp.GetYScreen() <= Tiles[i].GetYScreen() + 50)
                            {
                                Tiles.Remove(Tiles[i]);
                                try
                                {
                                    temp._image += 1;
                                }
                                catch (Exception)
                                {
                                    //Tiles[i - 1]._image += 1;
                                }
                            }
                        }
                    }

                    if (GetTile(Tiles[i].GetX() - 1, Tiles[i].GetY()) != null)
                    {
                        Tile temp1 = GetTile(Tiles[i].GetX() - 1, Tiles[i].GetY());
                        if (temp1._image == Tiles[i]._image)
                        {
                            if (temp1.GetXScreen() >= Tiles[i].GetXScreen() - 50 && temp1.GetXScreen() <= Tiles[i].GetXScreen() + 50 && temp1.GetYScreen() >= Tiles[i].GetYScreen() - 50 && temp1.GetYScreen() <= Tiles[i].GetYScreen() + 50)
                            {
                                //Evolve();
                                Tiles.Remove(Tiles[i]);
                                try
                                {
                                    temp1._image += 1;
                                }
                                catch (Exception)
                                {
                                    //Tiles[i - 1]._image += 1;
                                }
                            }
                        }
                    }

                    if(GetTile(Tiles[i].GetX(), Tiles[i].GetY() + 1) != null)
                    {
                        Tile temp2 = GetTile(Tiles[i].GetX(), Tiles[i].GetY() + 1);
                        if (temp2._image == Tiles[i]._image)
                        {
                            if (temp2.GetXScreen() >= Tiles[i].GetXScreen() - 50 && temp2.GetXScreen() <= Tiles[i].GetXScreen() + 50 && temp2.GetYScreen() >= Tiles[i].GetYScreen() - 50 && temp2.GetYScreen() <= Tiles[i].GetYScreen() + 50)
                            {
                                //Evolve();
                                Tiles.Remove(Tiles[i]);
                                try
                                {
                                    temp2._image += 1;
                                }
                                catch (Exception)
                                {
                                    //Tiles[i - 1]._image += 1;
                                }
                            }
                        }
                    }

                    if(GetTile(Tiles[i].GetX(), Tiles[i].GetY() - 1) != null)
                    {
                        Tile temp3 = GetTile(Tiles[i].GetX(), Tiles[i].GetY() - 1);

                        if (temp3._image == Tiles[i]._image)
                        {
                            if (temp3.GetXScreen() >= Tiles[i].GetXScreen() - 50 && temp3.GetXScreen() <= Tiles[i].GetXScreen() + 50 && temp3.GetYScreen() >= Tiles[i].GetYScreen() - 50 && temp3.GetYScreen() <= Tiles[i].GetYScreen() + 50)
                            {
                                //Evolve();
                                Tiles.Remove(Tiles[i]);
                                try
                                {
                                    temp3._image += 1;
                                }
                                catch (Exception)
                                {
                                    //Tiles[i - 1]._image += 1;
                                }
                            }
                        }
                    }
                    
                }
                catch (Exception)
                {

                }
                
            }
        }
    }
}