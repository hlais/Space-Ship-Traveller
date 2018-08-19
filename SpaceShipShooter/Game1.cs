using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShipShooter
{
 
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D asteriodSprite;
        Texture2D shipSprite;
        Texture2D spaceSprite;
        Texture2D timerSprite;

        SpriteFont spaceFont;
        SpriteFont timerFont;

        Ship player = new Ship();
       

        Controller gameController = new Controller();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            IsMouseVisible = true;
           
        }

  
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            asteriodSprite = Content.Load<Texture2D>("asteroid");
            shipSprite = Content.Load<Texture2D>("ship");
            spaceSprite = Content.Load<Texture2D>("space");

            timerFont = Content.Load<SpriteFont>("timerFont");
            spaceFont = Content.Load<SpriteFont>("spaceFont");
;
            
        }

      
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.shipUpdate(gameTime);
           

            gameController.astriodGeneration(gameTime);

            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                gameController.asteroids[i].AsteroidUpdate(gameTime);
            }
      
          
            
          

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(spaceSprite, new Vector2(0f, 0f), Color.White);
            spriteBatch.Draw(shipSprite, new Vector2(player.position.X-34, player.position.Y- 50), Color.White);
            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                Vector2 tempPos = gameController.asteroids[i].position;
                int tempRadius = gameController.asteroids[i].RADIUS_ASTEROID;
                spriteBatch.Draw(asteriodSprite, new Vector2(tempPos.X - tempRadius, tempPos.Y - tempRadius), Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
