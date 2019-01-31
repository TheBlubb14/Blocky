﻿using Blocky.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Blocky
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BlockyGame : Game
    {
        public int Width => graphics.GraphicsDevice.Viewport.Width;
        public int Height => graphics.GraphicsDevice.Viewport.Height;

        GraphicsDeviceManager graphics;

        Texture2D bottomTexture;
        Rectangle bottomRectangle;

        private EntityManager entityManager;
        private SpriteManager spriteManager;

        public BlockyGame()
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
            this.Window.AllowUserResizing = true;

            entityManager = new EntityManager(this);
            spriteManager = new SpriteManager(this, entityManager);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteManager.Load();

            entityManager.Load("playerTexture", new Vector2(Width / 2, Height / 2), new Player());
            entityManager.Load("bottomTexture", new Vector2(0, Height - 100), new Structure(new Vector2(Width, Height)));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteManager.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}