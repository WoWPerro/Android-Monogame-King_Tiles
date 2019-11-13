using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using testandroid.Resources;

namespace testandroid
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {



        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private float currentTime;
        bool change = false;
        bool lock1 = true;
        bool lock2 = true;

        public int Width { get; set; }
        public int Height { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.Portrait;
            //int x1 = testandroid.Activity1.ScreenWidth;
            //int y1 = testandroid.Activity1.ScreenHeight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            testandroid.Activity1.ScreenWidth = GraphicsDevice.Viewport.Width;
            testandroid.Activity1.ScreenHeight = GraphicsDevice.Viewport.Height;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //_tex = Content.Load<Texture2D>("dev");
            //_WowLOGO = Content.Load<Texture2D>("WowperroFirmaWhite");
            ScreenManager.Instance.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            ScreenManager.Instance.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            ScreenManager.Instance.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            if (lock1)
            {
                currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (currentTime >= 5)
                {
                    change = true;
                }
            }


            if (change)
            {
                ScreenManager.Instance.UnloadContent();
                ScreenManager.Instance.ChangeScreen(2);
                ScreenManager.Instance.LoadContent(Content);
                change = false;
                lock1 = false;
            }

            if (TitleScreen.pressExit && TitleScreen.realeseExit)
            {
                Exit();
            }

            else if(TitleScreen.pressStart && TitleScreen.realeseStart && lock2)
            {
                ScreenManager.Instance.UnloadContent();
                ScreenManager.Instance.ChangeScreen(3);
                ScreenManager.Instance.LoadContent(Content);
                lock2 = false;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            ScreenManager.Instance.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
