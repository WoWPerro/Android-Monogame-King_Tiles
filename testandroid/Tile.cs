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
    class Tile
    {
        float gridSizeX;
        float gridSizeY;
        public int _image;
        float _x;
        float _y;
        int SCREENSIZE_Y = testandroid.Activity1.ScreenHeight;
        int SCREENSIZE_X = testandroid.Activity1.ScreenWidth;
        float TileSizeX = 0;
        float TileSizeY = 0;
        float sum = 0;
        private int _posX;
        private int _posY;
        int counter = 1;

        public Tile(int x, int y, float GX, float GY)
        {
            _posX = x;
            _posY = y;
            gridSizeX = GX;
            gridSizeY = GY;
            _x = x* gridSizeX;
            _y = y* gridSizeY;
            TileSizeX = SCREENSIZE_X/6;
            TileSizeY = SCREENSIZE_Y/6;
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public void advanceX(bool positive)
        {
            if(positive)
            {
                _x+= 30;
                UpdateIndex();
            }
            else
            {
                _x-= 30;
                UpdateIndex();
            }
        }

        public void advanceY(bool positive)
        {
            if (positive)
            {
                _y+= 30;
                UpdateIndex();
            }
            else
            {
                _y-= 30;
                UpdateIndex();
            }
        }

        public int GetX()
        {
            return _posX;
        }

        public int GetY()
        {
            return _posY;
        }

        public float GetXScreen()
        {
            return _x;
        }

        public float GetYScreen()
        {
            return _y;
        }
        public void SetX(int x)
        {
            _posX = x;
        }

        public void SetY(int y)
        {
            _posY = y;
        }

        void Evolve()
        {
            _image++;
        }

        void UpdateIndex()
        {
            for (int i = 0; i < 7; i++)
            {
                if (_x + TileSizeX/2 > gridSizeX*i && _x + TileSizeX / 2 < gridSizeX*(i + 1))
                {
                    _posX = i;
                }
                if (_y + TileSizeY / 2 > gridSizeY * i && _y + TileSizeY / 2 < gridSizeY * (i + 1))
                {
                    _posY = i;
                }
            }
                
        }

        public void updatePositions()
        {
            _x = _posX * gridSizeX;
            _y = _posY * gridSizeY;
        }
    }
}