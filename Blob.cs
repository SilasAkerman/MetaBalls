using System;
using System.Numerics;
using Raylib_cs;

namespace MetaBalls
{
    class Blob
    {
        const int speed = 4;

        Vector2 pos = Vector2.Zero;
        Vector2 vel = Vector2.Zero;
        int size;

        Random rand = new Random();

        public Blob()
        {
            pos.X = rand.Next(Program.WIDTH);
            pos.Y = rand.Next(Program.HEIGHT);

            vel.X = (float)rand.NextDouble() * 2 * speed - speed;
            vel.Y = (float)rand.NextDouble() * 2 - 1;

            size = rand.Next(5, 25);
        }

        public double CalculateMetaValue(Vector2 pixelPos)
        {
            double distance = Vector2.Distance(pixelPos, pos);
            return size / distance;
        }

        public void Display()
        {
            Raylib.DrawCircleLines((int)pos.X, (int)pos.Y, size, Color.BLACK);
        }

        public void Update()
        {
            pos += vel;
            edges();
        }
        private void edges()
        {
            if (pos.X + size > Program.WIDTH || pos.X - size < 0)
            {
                vel.X *= -1;
            }
            if (pos.Y + size > Program.HEIGHT || pos.Y - size < 0)
            {
                vel.Y *= -1;
            }
        }
    }
}
