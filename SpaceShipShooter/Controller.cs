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
    class Controller
    {
        public List<Asteroid> asteroids = new List<Asteroid>();
        public double timer = 2d;
        public double maxTime = 2d;

        public int nextSpeed = 220;

        public void astriodGeneration(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (timer <= 0)
            {
                asteroids.Add(new Asteroid(nextSpeed));
                //reseting timer
                timer = maxTime;
                
                if (maxTime > 0.5)
                {
                    maxTime -= 0.1d;
                }
                if (nextSpeed < 720)
                {
                    nextSpeed += 4;
                }
            }
        }

    }
}
