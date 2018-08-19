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
        public Vector2 position = new Vector2(100, 100);
        public int speed = 180;

        public void shipUpdate(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

           
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                position.Y += speed * deltaTime;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                position.Y -= speed * deltaTime;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                position.X += speed * deltaTime;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                position.X -= speed* deltaTime;
            }
        }
        
    }
}
