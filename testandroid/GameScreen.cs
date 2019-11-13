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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

public struct Button
{
    private int _x;
    private int _y;
    private int _w;
    private int _h;
    public Button(int x, int y, int w, int h)
    {
        _x = x;
        _y = y;
        _w = w;
        _h = h;
    }

    public int GetX()
    {
        return _x;
    }
    public int GetY()
    {
        return _y;
    }
    public int GetW()
    {
        return _w;
    }
    public int GetH()
    {
        return _h;
    }

    public void SetX(int x)
    {
        _x = x;
    }
    public void SetY(int y)
    {
        _y = y;
    }
    public void SetW(int w)
    {
        _w = w;
    }
    public void SetH(int h)
    {
        _h = h;
    }


}

namespace testandroid
{
    public class GameScreen
    {
        

        protected ContentManager content;
        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gametime)
        {
           
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            
        }
    }
}