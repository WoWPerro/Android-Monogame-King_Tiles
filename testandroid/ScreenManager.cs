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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace testandroid
{
    public class ScreenManager
    {

         private static ScreenManager instance;
        public Vector2 Dimensions { private set; get; }
        public ContentManager Content { private set; get; }

        GameScreen currentScreen;
        GameScreen MainGameScreen = new MainScreen();
        GameScreen SplashScreen = new SplashScreen();
        GameScreen TitleScreen = new Resources.TitleScreen();

        float currentTime = 0f;
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();

                return instance;
            }
        }

        public ScreenManager()
        {
            Dimensions = new Vector2(200, 200);
            currentScreen = SplashScreen;
        }
        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gametime)
        {
            currentScreen.Update(gametime);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            currentScreen.Draw(spritebatch);
        }

        public void ChangeScreen(int x)
        {
            switch(x)
            {
                case 1:
                    currentScreen = SplashScreen;
                    break;
                case 2:
                    currentScreen = TitleScreen;
                    break;
                case 3:
                    currentScreen = MainGameScreen;
                    break;
            }
        }
    }
}