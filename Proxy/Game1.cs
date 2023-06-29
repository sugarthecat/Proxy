using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Proxy
{
    public class Game1 : Game
    {
        public static Game1 instance;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GUI currentGUI;
        private GUI worldGUI;
        private GUI mainMenuGUI;
        private GUI settingsGUI;
        private bool mouseDown;
        private bool settingsActive;
        public Game1()
        {
            instance = this;
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 900;
            //_graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            settingsActive = false;
            mouseDown = false;
        }
        public int getScreenWidth()
        {
            return _graphics.PreferredBackBufferWidth;
        }
        public int getScreenHeight()
        {
            return _graphics.PreferredBackBufferHeight;
        }
        public void toggleSettings()
        {
            settingsActive = !settingsActive;
        }
        public void toggleFullscreen()
        {
            _graphics.ToggleFullScreen();
        }
        public void NavigateToMenu(string newMenu)
        {
            if (newMenu == "mainMenu")
            {
                currentGUI = mainMenuGUI;
            }
            if (newMenu == "world")
            {
                currentGUI = worldGUI;
            }
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            mainMenuGUI = new MainMenuGUI();
            currentGUI = mainMenuGUI;
            settingsGUI = new SettingsGUI();
            worldGUI = new WorldGUI();
            World.generateWorld();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Assets.Setup(Content);
            //BANNER_TXTR = Content.Load<Texture2D>("assets/banner");
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            if (!mouseDown && mouseState.LeftButton == ButtonState.Pressed)
            {
                if (settingsActive)
                {
                    settingsGUI.handleClick(new Point(mouseState.X, mouseState.Y));
                }
                else
                {
                    currentGUI.handleClick(new Point(mouseState.X, mouseState.Y));

                }
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            mouseDown = mouseState.LeftButton == ButtonState.Pressed;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            if(settingsActive)
            {
                settingsGUI.draw(_spriteBatch);
            }
            else
            {
                currentGUI.draw(_spriteBatch);
            }
            _spriteBatch.End(); 

            base.Draw(gameTime);
        }
    }
}