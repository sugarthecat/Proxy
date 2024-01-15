using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Proxy
{
    public class Game1 : Game
    {
        public static Game1 instance;
        private GraphicsDeviceManager _graphics;
        private int _height;
        private bool _isBorderless;
        private bool _isFullscreen;
        private SpriteBatch _spriteBatch;
        private int _width;
        private GUI currentGUI;
        private MainMenuGUI mainMenuGUI;
        private KeyboardState previousKeyboardState;
        private MouseState previousMouseState;
        private bool settingsActive;
        private SettingsGUI settingsGUI;
        private TimeSpan tickLength;
        private TimeSpan timeTillNextTick;
        private bool windowActive;
        private WorldGUI worldGUI;
        public Game1()
        {
            timeTillNextTick = new TimeSpan(0, 0, 0, 1);
            tickLength = new TimeSpan(0, 0, 0, 1);
            instance = this;
            _graphics = new GraphicsDeviceManager(this);
            _width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2;
            _height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2;
            _graphics.PreferredBackBufferWidth = _width;
            _graphics.PreferredBackBufferHeight = _height;
            //_graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            _isFullscreen = true;
            _isBorderless = true;
            windowActive = false;
            settingsActive = false;
            previousMouseState = Mouse.GetState();
            this.Activated += windowOpened;
            this.Deactivated += windwoClosed;
        }

        public static int GetLargestScreenDimension()
        {
            if (instance.Window.ClientBounds.Width > instance.Window.ClientBounds.Height)
            {
                return instance.Window.ClientBounds.Width;
            }
            else
            {
                return instance.Window.ClientBounds.Height;
            }
        }

        public static int GetScreenHeight()
        {
            return instance.Window.ClientBounds.Height;
        }

        public static int GetScreenWidth()
        {
            return instance.Window.ClientBounds.Width;
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

        public void ToggleFullscreen()
        {
            if (_isFullscreen)
            {
                _graphics.PreferredBackBufferWidth = _width;
                _graphics.PreferredBackBufferHeight = _height;
                _graphics.HardwareModeSwitch = !_isBorderless;

                _graphics.IsFullScreen = false;
                _isFullscreen = false;
                _graphics.ApplyChanges();
            }
            else
            {
                _width = Window.ClientBounds.Width;
                _height = Window.ClientBounds.Height;

                _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                _graphics.HardwareModeSwitch = !_isBorderless;

                _graphics.IsFullScreen = true;
                _isFullscreen = true;
                _graphics.ApplyChanges();
            }
        }

        public void ToggleSettings()
        {
            settingsActive = !settingsActive;
        }

        public void windowOpened(object sendet, EventArgs args)
        {
            windowActive = true;
        }

        public void windwoClosed(object sendet, EventArgs args)
        {
            windowActive = false;
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            if (settingsActive)
            {
                settingsGUI.Draw(_spriteBatch);
            }
            else
            {
                currentGUI.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            mainMenuGUI = new MainMenuGUI();
            currentGUI = mainMenuGUI;
            settingsGUI = new SettingsGUI();
            worldGUI = new WorldGUI();
            World.GenerateWorld();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Assets.Setup(Content);
            //BANNER_TXTR = Content.Load<Texture2D>("assets/banner");
        }

        protected override void Update(GameTime gameTime)
        {
            if (currentGUI == worldGUI)
            {
                timeTillNextTick -= gameTime.ElapsedGameTime;
                if (timeTillNextTick < TimeSpan.Zero)
                {
                    timeTillNextTick = tickLength;
                    World.DoWorldTick();
                }
            }
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            if (windowActive)
            {
                if (previousMouseState.LeftButton != ButtonState.Pressed && mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (settingsActive)
                    {
                        settingsGUI.HandleClick(new Point(mouseState.X, mouseState.Y));
                    }
                    else
                    {
                        currentGUI.HandleClick(new Point(mouseState.X, mouseState.Y));
                    }
                }
                if (currentGUI == worldGUI)
                {
                    if (previousMouseState.RightButton == ButtonState.Pressed && mouseState.RightButton == ButtonState.Pressed)
                    {
                        World.Move(mouseState.X - previousMouseState.X, mouseState.Y - previousMouseState.Y);
                    }
                    World.Scale(mouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue);
                }
                if (keyboardState.IsKeyDown(Keys.Escape) && !previousKeyboardState.IsKeyDown(Keys.Escape))
                {
                    ToggleSettings();
                }
            }
            mainMenuGUI.RescaleElements();
            settingsGUI.RescaleElements();
            worldGUI.RescaleElements();

            // TODO: Add your update logic here

            previousMouseState = mouseState;
            previousKeyboardState = keyboardState;
            base.Update(gameTime);
        }
    }
}