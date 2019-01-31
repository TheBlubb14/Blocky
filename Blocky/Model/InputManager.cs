using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocky.Model
{
    public class InputManager
    {
        private readonly HashSet<Entity> entities;
        private readonly HashSet<Effect> effects;

        public InputManager()
        {
            entities = new HashSet<Entity>();
            effects = new HashSet<Effect>();
        }

        public void AddEntity(Entity entity)
        {
            if (!entities.Contains(entity))
                entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            if (entities.Contains(entity))
                entities.Remove(entity);
        }

        public void AddEffect(Effect effect)
        {
            if (!effects.Contains(effect))
                effects.Add(effect);
        }

        public void RemoveEffect(Effect effect)
        {
            if (effects.Contains(effect))
                effects.Remove(effect);
        }

        public void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();

            foreach (var entity in entities)
            {
                if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
                    entity.MooveLeft();

                if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
                    entity.MooveUp();

                if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
                    entity.MooveRight();

                if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
                    entity.MooveDown();

                entity.Update();
            }
        }
    }
}
