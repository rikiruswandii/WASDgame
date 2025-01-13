using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WASDgame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _playerTexture;
        private Vector2 _playerPosition;
        private float _playerSpeed = 200f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _playerPosition = new Vector2(100, 100);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _playerTexture = new Texture2D(GraphicsDevice, 50, 50);

            Color[] data = new Color[50 * 50];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            _playerTexture.SetData(data);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (state.IsKeyDown(Keys.W)) _playerPosition.Y -= _playerSpeed * deltaTime;
            if (state.IsKeyDown(Keys.S)) _playerPosition.Y += _playerSpeed * deltaTime;
            if (state.IsKeyDown(Keys.A)) _playerPosition.X -= _playerSpeed * deltaTime;
            if (state.IsKeyDown(Keys.D)) _playerPosition.X += _playerSpeed * deltaTime;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_playerTexture, _playerPosition, Color.Red);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
