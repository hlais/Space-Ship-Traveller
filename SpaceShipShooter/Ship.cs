using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShipShooter
{
    class Ship
    {
        
        public int speed = 180;

        static public Vector2 defaultPosition = new Vector2(640, 360);
        public Vector2 position = defaultPosition;

        Controller controller = new Controller();

        public void shipUpdate(GameTime gameTime, Controller gameController)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (gameController.inGame)
            {
                if (keyboardState.IsKeyDown(Keys.Down) && position.Y < 720)
                {
                    position.Y += speed * deltaTime;
                }
                if (keyboardState.IsKeyDown(Keys.Up) && position.Y > 0)
                {
                    position.Y -= speed * deltaTime;
                }
                if (keyboardState.IsKeyDown(Keys.Right) && position.X < 1280)
                {
                    position.X += speed * deltaTime;
                }
                if (keyboardState.IsKeyDown(Keys.Left) && position.X > 0)
                {
                    position.X -= speed * deltaTime;
                }
            }
        }
        
    }
}
