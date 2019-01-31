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

        public Entity()
        {
            Velocity = 1;
            Delta = new Vector2(0, 0);
            DeltaMax = new Vector2(5, 5);
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
            Delta += new Vector2(0, 2);
        }

        public void MooveDown()
        {
            //Position = new Vector2(Position.X, Position.Y + 1);
            Delta += new Vector2(0, -2);
        }

        public void Update()
        {
            float deltaX = 0;
            float deltaY = 0;

            if (Delta.X > 0)
                deltaX = Math.Max(0, Delta.X - Velocity);
            else if (Delta.X < 0)
                deltaX = Math.Min(0, Delta.X + Velocity);

            if (Delta.Y > 0)
                deltaY = Math.Max(0, Delta.Y - Velocity);
            else if (Delta.X < 0)
                deltaY = Math.Min(0, Delta.Y + Velocity);

            Delta = new Vector2(Math.Min(deltaX, DeltaMax.X), Math.Min(deltaY, DeltaMax.Y));

            Position += Delta;
        }

        public void Dispose()
        {
            Texture?.Dispose();
            Texture = null;
        }
    }
}
