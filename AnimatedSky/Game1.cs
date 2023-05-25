using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimatedSky
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _background;

        // First cloud layer
        Texture2D _layer1;
        private float _scrollX1;
        private float _scrollY1;

        // Second cloud layer
        Texture2D _layer2;
        private float _scrollX2;
        private float _scrollY2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 960,
                PreferredBackBufferHeight = 640
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _background = Content.Load<Texture2D>("Backgrounds/SkyBackground");
            _layer1 = Content.Load<Texture2D>("Backgrounds/SkyBackgroundLayer1");
            _layer2 = Content.Load<Texture2D>("Backgrounds/SkyBackgroundLayer2");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Scroll layer 1
            _scrollX1 += 0.5f;
            _scrollY1 += 0.5f;

            // Scroll layer 2
            _scrollX2 += 1.0f;
            _scrollY2 += 0.8f;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            // Draw the background
            _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            // Draw the scrolling layers
            _spriteBatch.Draw(_layer1, Vector2.Zero, new Rectangle((int)(-_scrollX1), (int)(-_scrollY1), _layer1.Width, _layer1.Height), Color.White);
            _spriteBatch.Draw(_layer2, Vector2.Zero, new Rectangle((int)(-_scrollX2), (int)(-_scrollY2), _layer2.Width, _layer2.Height), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}