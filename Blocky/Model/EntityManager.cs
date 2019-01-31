using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Blocky.Model
{
    public class EntityManager : IDisposable
    {
        public List<Entity> Entities;

        private readonly BlockyGame blockyGame;

        public EntityManager(BlockyGame blockyGame)
        {
            this.blockyGame = blockyGame;
            Entities = new List<Entity>();
        }

        public void Load<T>(string texture, Vector2 position, T entity = null) where T : Entity
        {
            if (entity == null)
                entity = Activator.CreateInstance<T>();

            entity.Texture = blockyGame.Content.Load<Texture2D>(texture);
            entity.Position = position;
            Entities.Add(entity);
        }

        public void Dispose()
        {
            foreach (var entity in Entities)
                entity?.Dispose();

            Entities = null;
        }
    }
}