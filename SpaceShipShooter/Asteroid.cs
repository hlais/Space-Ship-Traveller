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
    class Asteroid
    {
        public Vector2 position;

        private int speed;
        public int RADIUS_ASTEROID = 59;

        public bool offScreen = false;
        static Random rand = new Random();

        public Asteroid(int newSpeed)
        {
            speed = newSpeed;
           
            position = new Vector2(1280+ RADIUS_ASTEROID, rand.Next(0,721));
        
        }

        public void AsteroidUpdate(GameTime gameTime)
        {
           float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X -= speed * deltaTime;
        }


    }
}
