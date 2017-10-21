using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GenericListLib;
using System.Collections.Generic;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// Bottom paddle object
        /// </summary>
        public Paddle BottomPaddle { get; private set; }
        /// <summary>
        /// Top paddle object
        /// </summary>
        public Paddle TopPaddle { get; private set; }

        /// <summary>
        /// Ball reference
        /// </summary>
        public Ball Ball { get; private set; }
        public Backgorund Background { get; private set; }

        public SoundEffect HitSound { get; private set; }

        public Song Music { get; private set; }
        private IGenericList<Sprite> SpritesForDrawList = new GenericList<Sprite>();

        public List<Wall> Walls { get; set; }
        public List<Wall> Goals { get; set; }


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 900,
                PreferredBackBufferWidth = 500

            };
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
            var screenBounds = GraphicsDevice.Viewport.Bounds;
            BottomPaddle = new Paddle(GameConstants.PaddleDefaultWidth, GameConstants.PaddleDefaulHeight, GameConstants.PaddleDefaulSpeed);
            BottomPaddle.X = screenBounds.Width / 2f - BottomPaddle.Width / 2f;
            BottomPaddle.Y = screenBounds.Bottom - BottomPaddle.Height;

            TopPaddle = new Paddle(GameConstants.PaddleDefaultWidth, GameConstants.PaddleDefaulHeight, GameConstants.PaddleDefaulSpeed);
            TopPaddle.X = screenBounds.Width / 2f - BottomPaddle.Width /2;
            TopPaddle.Y = 0;

            Ball = new Ball(GameConstants.DefaultBallSize, GameConstants.BallMaxSpeed, GameConstants.DefaultBallBumpSpeedIncreaseFactor);
            //{
            //   float X = 0;
            // float Y = 0;
            //};
            Walls = new List<Wall>()
            {
                new Wall(-GameConstants.WallDefaultSize,0, GameConstants.WallDefaultSize, screenBounds.Height),
                new Wall(screenBounds.Right,0, GameConstants.WallDefaultSize, screenBounds.Height)
            };
            Goals = new List<Wall>() {
                new Wall(0,screenBounds.Height, screenBounds.Width, GameConstants.WallDefaultSize),
                new Wall(screenBounds.Top, -GameConstants.WallDefaultSize, screenBounds.Width, GameConstants.WallDefaultSize)
            };
            Ball.X = screenBounds.Width / 2f - Ball.Width /2f;
            Ball.Y = screenBounds.Height / 2f - Ball.Height / 2f;
            Ball.Speed = 0.2f;
            Background = new Backgorund(screenBounds.Width, screenBounds.Height);
            SpritesForDrawList.Add(Background);
            SpritesForDrawList.Add(BottomPaddle);
            SpritesForDrawList.Add(TopPaddle);
            SpritesForDrawList.Add(Ball);
            System.Console.WriteLine("jurij");
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

            //Set Textures
            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");
            BottomPaddle.Texture = paddleTexture;
            TopPaddle.Texture = paddleTexture;
            Ball.Texture = Content.Load<Texture2D>("ball");
            Background.Texture = Content.Load<Texture2D>("background");

            // Load sound
            // Start background music
            HitSound = Content.Load<SoundEffect>("Hit");
            Music = Content.Load<Song>("music");

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Music);

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

            var touchState = Keyboard.GetState();
            var screenBounds = GraphicsDevice.Viewport.Bounds;

            if (touchState.IsKeyDown(Keys.Left))
            {
                BottomPaddle.X -= (float)gameTime.ElapsedGameTime.TotalMilliseconds * BottomPaddle.Speed;
            }
            if (touchState.IsKeyDown(Keys.Right))
            {
                BottomPaddle.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds * BottomPaddle.Speed;
            }
            if (touchState.IsKeyDown(Keys.A))
            {
                TopPaddle.X -= (float)gameTime.ElapsedGameTime.TotalMilliseconds * TopPaddle.Speed;
            }
            if (touchState.IsKeyDown(Keys.D))
            {
                TopPaddle.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds * TopPaddle.Speed;
            }
            BottomPaddle.X = MathHelper.Clamp(BottomPaddle.X, screenBounds.Left, screenBounds.Right - BottomPaddle.Width);
            TopPaddle.X = MathHelper.Clamp(TopPaddle.X, screenBounds.Left, screenBounds.Right - TopPaddle.Width);
            
            var ballPositionChange = Ball.Direction * (float)(gameTime.ElapsedGameTime.TotalMilliseconds * Ball.Speed);
            Ball.X += ballPositionChange.X;
            Ball.Y += ballPositionChange.Y;
            
            foreach (Wall zid in Walls) {
                if (CollisionDetector.Overlaps(Ball, zid))
                {
                    Ball.Direction = new Vector2(-Ball.Direction.X, Ball.Direction.Y);
                }
            }
            if (CollisionDetector.Overlaps(Ball,TopPaddle) || CollisionDetector.Overlaps(Ball,BottomPaddle))
            {
                Ball.Direction = new Vector2(Ball.Direction.X, -Ball.Direction.Y);
                if((Ball.Speed = Ball.Speed * GameConstants.DefaultBallBumpSpeedIncreaseFactor) <= GameConstants.BallMaxSpeed)
                {
                    Ball.Speed = Ball.Speed * GameConstants.DefaultBallBumpSpeedIncreaseFactor;
                }
            }
            foreach(Wall gol in Goals)
            {
                if (CollisionDetector.Overlaps(Ball, gol))
                {
                    Ball.X = screenBounds.Width / 2f - Ball.Width / 2f;
                    Ball.Y = screenBounds.Height / 2f - Ball.Height / 2f;
                    Ball.Direction = new Vector2(1,  1);
                    Ball.Speed = 0.2f;

                }

            }
base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            for(int i = 0; i < SpritesForDrawList.Count; i++)
            {
                SpritesForDrawList.GetElement(i).DrawSpriteOnScreen(spriteBatch);
            }

            // End drawing 
            // Send all gathered details to the graphic card in one batch.

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
