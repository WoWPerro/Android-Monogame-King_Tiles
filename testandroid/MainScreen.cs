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
using Microsoft.Xna.Framework.Media;

namespace testandroid
{
    class MainScreen : GameScreen
    {
        float prevLocX = 0;
        float prevLocY = 0;
        bool Lock = false;
        bool press = false;
        bool SwipeLeft = false;
        bool SwipeRight = false;
        bool SwipeUp = false;
        bool SwipeDown = false;
        private bool exit;
        Song mainsong;
        float currentTime = 0;
        bool changeScreen = false;

        int Score;
        Grid MainGrid = new Grid(6, 6);
        Texture2D image;
        Texture2D background;
        Texture2D currentbackground;
        Texture2D[] cards = new Texture2D[14];
        Texture2D[] backgrounds = new Texture2D[20];
        public override void LoadContent()
        {
            base.LoadContent();
            try
            {
                image = content.Load<Texture2D>("Blue");
                cards[0] = content.Load<Texture2D>("Cards/Hearts/As");
                cards[1] = content.Load<Texture2D>("Cards/Hearts/2");
                cards[2] = content.Load<Texture2D>("Cards/Hearts/3");
                cards[3] = content.Load<Texture2D>("Cards/Hearts/4");
                cards[4] = content.Load<Texture2D>("Cards/Hearts/5");
                cards[5] = content.Load<Texture2D>("Cards/Hearts/6");
                cards[6] = content.Load<Texture2D>("Cards/Hearts/7");
                cards[7] = content.Load<Texture2D>("Cards/Hearts/8");
                cards[8] = content.Load<Texture2D>("Cards/Hearts/9");
                cards[9] = content.Load<Texture2D>("Cards/Hearts/10");
                cards[10] = content.Load<Texture2D>("Cards/Hearts/11");
                cards[11] = content.Load<Texture2D>("Cards/Hearts/12");
                cards[12] = content.Load<Texture2D>("Cards/Hearts/13");

                background = content.Load<Texture2D>("surface");
                currentbackground = background;

                for (int i = 0; i< 20; i++)
                {
                    backgrounds[i] = content.Load<Texture2D>("Wallpaper_Phone/" + (i+1).ToString());
                }
                
                //Sounds
                mainsong = content.Load<Song>("SongCardGame");
                MediaPlayer.Play(mainsong);
                MediaPlayer.IsRepeating = true;

                //Efectos de sonido
                //this.cannonHit = Content.Load<SoundEffect>("Pop");
                //this.cannonShoot = Content.Load<SoundEffect>("CannonSound");
                //mySoundInstance = cannonShoot.CreateInstance();
            }
            catch (Exception e)
            {
                Console.WriteLine("===========================================================EXCEPTION==============================================");
                Console.WriteLine(e);
            }
            MainGrid.Generatenew();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }


        public override void Update(GameTime gameTime)
        {
            //---------------------------------INPUTS---------------------------------------------------
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                exit = true;
            }

            TouchCollection tc = TouchPanel.GetState();
            foreach (TouchLocation tl in tc)
            {
                if (tl.State == TouchLocationState.Pressed)
                {
                    if (!Lock)
                    {
                        prevLocX = tl.Position.X;
                        prevLocY = tl.Position.Y;
                        Lock = true;
                    }

                }

                if (tl.State == TouchLocationState.Moved)
                {
                    if (prevLocX > tl.Position.X + 100)
                    {
                        SwipeLeft = true;
                    }

                    else if (prevLocX < tl.Position.X - 100)
                    {
                        SwipeRight = true;
                    }

                    else if (prevLocY < tl.Position.Y - 100)
                    {
                        SwipeDown = true;
                    }

                    else if (prevLocY > tl.Position.Y + 100)
                    {
                        SwipeUp = true;
                    }
                }

                if (tl.State == TouchLocationState.Released)
                {
                    Lock = false;
                }

                currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (currentTime > 4)
                {
                    currentTime = 0;
                    changeScreen = true;
                }
            }

        }

        public override void Draw(SpriteBatch spritebatch)
        {
            if(changeScreen)
            {
                ChangeBackground();
                changeScreen = false;
            }
            spritebatch.Draw(currentbackground, destinationRectangle: new Rectangle(0, 0, testandroid.Activity1.ScreenWidth, testandroid.Activity1.ScreenHeight), color: Color.White);

            if (SwipeUp)
            {
                if (!MainGrid.Move(1))
                {
                    SwipeDown = false;
                    SwipeRight = false;
                    SwipeLeft = false;
                    SwipeUp = false;
                    MainGrid.Generatenew();
                    MainGrid.UpdatePositions();
                    MainGrid.checkColisions();
                    //DrawCards(spritebatch);
                }
            }

            else if (SwipeDown)
            {
                if (!MainGrid.Move(2))
                {
                    SwipeDown = false;
                    SwipeRight = false;
                    SwipeLeft = false;
                    SwipeUp = false;
                    MainGrid.Generatenew();
                    MainGrid.UpdatePositions();
                    MainGrid.checkColisions();
                    //DrawCards(spritebatch);

                }
            }
            
            else if (SwipeLeft)
            {
                if (!MainGrid.Move(3))
                {
                    SwipeDown = false;
                    SwipeRight = false;
                    SwipeLeft = false;
                    SwipeUp = false;
                    MainGrid.Generatenew();
                    MainGrid.UpdatePositions();
                    MainGrid.checkColisions();
                    //DrawCards(spritebatch);

                }
            }
            else if (SwipeRight)
            {
                if (!MainGrid.Move(4))
                {
                    SwipeDown = false;
                    SwipeRight = false;
                    SwipeLeft = false;
                    SwipeUp = false;
                    MainGrid.Generatenew();
                    MainGrid.UpdatePositions();
                    MainGrid.checkColisions();
                    //DrawCards(spritebatch);
                }
            }

            DrawCards(spritebatch);
        }

        void DrawCards(SpriteBatch spritebatch)
        {
            for (int i = 0; i < MainGrid.Tiles.Count; i++)
            {
                spritebatch.Draw(cards[MainGrid.Tiles[i]._image], destinationRectangle: 
                    new Rectangle((int)MainGrid.Tiles[i].GetXScreen(), 
                    (int)MainGrid.Tiles[i].GetYScreen(), 
                    ((testandroid.Activity1.ScreenWidth/6) - (testandroid.Activity1.ScreenWidth / 60)), 
                    (int)(testandroid.Activity1.ScreenWidth / 6 * 1.47f) - (testandroid.Activity1.ScreenWidth / 60)),
                    color: Color.White); //180 299
            }
        }

        void ChangeBackground()
        {
            currentbackground = backgrounds[MainGrid.RandomNumber(0, 19)];
        }
    }
}