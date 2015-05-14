using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _3DColor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private FrameCounter frameCounter = new FrameCounter();

        public static State.BaseState state;

        private SpriteFont sf;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            state = new State.Intro();

            this.graphics.PreferredBackBufferWidth = 1920;
            this.graphics.PreferredBackBufferHeight = 1080;
            this.graphics.SynchronizeWithVerticalRetrace = false;
            this.IsFixedTimeStep = false;
            //this.graphics.IsFullScreen = true;
            this.graphics.ApplyChanges();

            Values.SCREEN_HEIGHT = GraphicsDevice.PresentationParameters.BackBufferHeight;
            Values.SCREEN_WIDTH = GraphicsDevice.PresentationParameters.BackBufferWidth;
            Values.SCREEN_IS_FULLSCREEN = false;

            //Input.InitInput();

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

            ContentLibrary.TextureLibrary.Content = Content;
            ContentLibrary.FontLibrary.Content = Content;
            sf = ContentLibrary.FontLibrary.GetFont("Fonts/Basicfont");


            state.LoadContent();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gt)
        {
            //Input.UpdateCurrent();
            // Allows the game to exit
            //if (Input.CurrentKeyboardState.IsKeyDown(Keys.Escape))
            //    this.Exit();
            frameCounter.Update((float)gt.ElapsedGameTime.TotalSeconds);
            state.Update(gt);

            Libraries.GFXHelper.Update(gt);

            //Input.UpdatePrevious();
            base.Update(gt);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            state.Draw(spriteBatch);
            Libraries.GFXHelper.Draw(spriteBatch);
            var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);
            spriteBatch.DrawString(sf, fps, new Vector2(1, 1), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
