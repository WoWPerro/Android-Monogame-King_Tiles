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
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace testandroid.Resources
{

    class TitleScreen : GameScreen
    {
        Texture2D buttonsprite1;
        Texture2D buttonsprite2;
        Texture2D background;
        int SCREENSIZE_Y = testandroid.Activity1.ScreenHeight;
        int SCREENSIZE_X = testandroid.Activity1.ScreenWidth;
        bool touch;
        Button Start = new Button(0, 0, 0, 0);
        Button Exit = new Button(0, 0, 0, 0);
        public static bool pressStart = false;
        public static bool realeseStart = false;
        public static bool pressExit = false;
        public static bool realeseExit = false;
        private bool exit;

        public override void LoadContent()
        {
            Start.SetH(200);
            Start.SetW(400);
            Start.SetX((SCREENSIZE_X / 2) - (Start.GetW() / 2));
            Start.SetY((SCREENSIZE_Y / 2) - (Start.GetH() - 300));

            Exit.SetH(200);
            Exit.SetW(400);
            Exit.SetX((SCREENSIZE_X / 2) - (Start.GetW() / 2));
            Exit.SetY((SCREENSIZE_Y / 2) - (Start.GetH() + 300));

            base.LoadContent();
            try
            {
                buttonsprite1 = content.Load<Texture2D>("StartButton");
                buttonsprite2 = content.Load<Texture2D>("Quit");
                background = content.Load<Texture2D>("surface2");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                exit = true;
            }

            TouchCollection tc = TouchPanel.GetState();
            foreach (TouchLocation tl in tc)
            {
                if (tl.State == TouchLocationState.Pressed)
                {
                    if (tl.Position.X > Start.GetX() && tl.Position.X < Start.GetX() + Start.GetW() && tl.Position.Y > Start.GetY() && tl.Position.Y < Start.GetY() + Start.GetH())
                    {
                        pressStart = true;
                        pressExit = false;
                    }
                    else if (tl.Position.X > Exit.GetX() && tl.Position.X < Exit.GetX() + Exit.GetW() && tl.Position.Y > Exit.GetY() && tl.Position.Y < Exit.GetY() + Exit.GetH())
                    {
                        pressExit = true;
                        pressStart = false;
                    }
                    else
                    {
                        pressStart = false;
                        pressExit = false;
                    }
                }
                if (tl.State == TouchLocationState.Released)
                {
                    if (tl.Position.X > Start.GetX() && tl.Position.X < Start.GetX() + Start.GetW() && tl.Position.Y > Start.GetY() && tl.Position.Y < Start.GetY() + Start.GetH())
                    {
                        realeseStart = true;
                        realeseExit = false;
                    }
                    else if (tl.Position.X > Exit.GetX() && tl.Position.X < Exit.GetX() + Exit.GetW() && tl.Position.Y > Exit.GetY() && tl.Position.Y < Exit.GetY() + Exit.GetH())
                    {
                        realeseExit = true;
                        realeseStart = false;
                    }
                    else
                    {
                        pressStart = false;
                        pressExit = false;
                    }
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(background, destinationRectangle: new Rectangle(0, 0, testandroid.Activity1.ScreenWidth, testandroid.Activity1.ScreenHeight), color: Color.White);
            spritebatch.Draw(buttonsprite1, destinationRectangle: new Rectangle(Start.GetX(),Start.GetY(),Start.GetW(),Start.GetH()), color: Color.White);
            spritebatch.Draw(buttonsprite2, destinationRectangle: new Rectangle(Exit.GetX(), Exit.GetY(), Exit.GetW(), Exit.GetH()), color: Color.White);
        }
    }
}
