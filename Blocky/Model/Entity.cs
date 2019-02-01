using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Blocky.Model
{
    public class Entity : IDisposable
    {
        public Vector2 Position { get; set; }

        public Texture2D Texture { get; set; }

        public float Velocity { get; set; }

        public Vector2 Delta { get; set; }

        public Vector2 DeltaMax { get; set; }

        public Vector2 InitialSpawn  { get; set; }

        public Entity()
        {
            // Trägheit
            Velocity = 0.5f;

            // die Geschwindigkeit
            Delta = new Vector2(0, 0);

            // max Geschwindigkeit
            DeltaMax = new Vector2(15, 15);
        }

        public void Load()
        {

        }

        public void MooveLeft()
        {
            //Position = new Vector2(Position.X - 1, Position.Y);
            Delta += new Vector2(-2, 0);
        }

        public void MooveRight()
        {
            //Position = new Vector2(Position.X + 1, Position.Y);
            Delta += new Vector2(2, 0);
        }

        public void MooveUp()
        {
            //Position = new Vector2(Position.X, Position.Y - 1);
            Delta += new Vector2(0, -2);
        }

        public void MooveDown()
        {
            //Position = new Vector2(Position.X, Position.Y + 1);
            Delta += new Vector2(0, 2);
        }

        public void Center()
        {
            Delta = new Vector2(0, 0);
            Position = InitialSpawn;
        }

        public void Update()
        {
            float deltaX = 0;
            float deltaY = 0;

            float newDeltaX = 0;
            float newDeltaY = 0;

            if (Delta.X > 0)
            {
                deltaX = Math.Max(0, Delta.X - Velocity);
                newDeltaX = Math.Min(deltaX, DeltaMax.X);
            }
            else if (Delta.X < 0)
            {
                deltaX = Math.Min(0, Delta.X + Velocity);
                newDeltaX = Math.Max(deltaX, -DeltaMax.X);
            }

            if (Delta.Y > 0)
            {
                deltaY = Math.Max(0, Delta.Y - Velocity);
                newDeltaY = Math.Min(deltaY, DeltaMax.Y);
            }
            else if (Delta.Y < 0)
            {
                deltaY = Math.Min(0, Delta.Y + Velocity);
                newDeltaY = Math.Max(deltaY, -DeltaMax.Y);
            }

            Delta = new Vector2(newDeltaX, newDeltaY);

            Console.WriteLine(Delta);
            Position += Delta;
        }

        public void Dispose()
        {
            Texture?.Dispose();
            Texture = null;
        }
    }
}
