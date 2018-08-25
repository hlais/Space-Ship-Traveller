using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace SpaceShipShooter
{
 
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D asteriodSprite;
        Texture2D shipSprite;
        Texture2D spaceSprite;
      

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

            player.shipUpdate(gameTime,gameController);
           

            gameController.astriodGeneration(gameTime);

            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                gameController.asteroids[i].AsteroidUpdate(gameTime);

                if (gameController.asteroids[i].position.X < (0 - gameController.asteroids[i].RADIUS_ASTEROID))
                {
                    gameController.asteroids[i].offScreen = true;
                }

                int sum = gameController.asteroids[i].RADIUS_ASTEROID + 30;
                if (Vector2.Distance(gameController.asteroids[i].position, player.position) < sum)
                {
                    gameController.inGame = false;
                    player.position =  Ship.defaultPosition;
                    i = gameController.asteroids.Count;
                    gameController.asteroids.Clear();
                
                }

            }
            gameController.asteroids.RemoveAll(x => x.offScreen);

      
          
            
          

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(spaceSprite, new Vector2(0f, 0f), Color.White);
            spriteBatch.Draw(shipSprite, new Vector2(player.position.X-34, player.position.Y- 50), Color.White);

            if (gameController.inGame == false)
            {
                string menuMessage = "Press ENTER to begin!";
                Vector2 sizeOfText = spaceFont.MeasureString(menuMessage);
                spriteBatch.DrawString(spaceFont, menuMessage, new Vector2(640 - sizeOfText.X / 2, 200), Color.White);
            }
            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                Vector2 tempPos = gameController.asteroids[i].position;
                int tempRadius = gameController.asteroids[i].RADIUS_ASTEROID;
                spriteBatch.Draw(asteriodSprite, new Vector2(tempPos.X - tempRadius, tempPos.Y - tempRadius), Color.White);
            }
            spriteBatch.DrawString(timerFont, $"{Math.Round(gameController.totalGameTimer)}", new Vector2(3, 3), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
