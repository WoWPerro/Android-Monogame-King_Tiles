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

using Android.Content.PM;
using Android.Graphics.Drawables;


using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace testandroid
{
    public class SplashScreen : GameScreen
    {
        int SCREENSIZE_Y = testandroid.Activity1.ScreenHeight;
        int SCREENSIZE_X = testandroid.Activity1.ScreenWidth;
        Texture2D image;
        Texture2D image2;
        public override void LoadContent()
        {
            base.LoadContent();
            try
            {
                image = content.Load<Texture2D>("WowperroFirmaWhite");
                image2 = content.Load<Texture2D>("LOGOYT(512x512)");
            }
            catch (Exception e)
            {
                Console.WriteLine("===========================================================EXCEPTION==============================================");
                Console.WriteLine(e);
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(image, destinationRectangle: new Rectangle(0, SCREENSIZE_Y/2, SCREENSIZE_X, (int)Math.Round(SCREENSIZE_X * 0.38f)), color: Color.White);
            spritebatch.Draw(image2, destinationRectangle: new Rectangle(0, 50, SCREENSIZE_X, SCREENSIZE_X), color: Color.White);
        }
    }
}