using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Blocky.Model
{
    public class Entity : IDisposable
    {
        public Vector2 Position { get; set; }

        public Texture2D Texture { get; set; }

        public Entity()
        {

        }

        public void Load()
        {

        }

        public void Dispose()
        {
            Texture?.Dispose();
            Texture = null;
        }
    }
}
