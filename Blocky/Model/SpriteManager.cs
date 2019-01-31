using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocky.Model
{
    public class SpriteManager : IDisposable
    {
        private readonly BlockyGame blockyGame;
        private SpriteBatch spriteBatch;
        private EntityManager entityManager;

        public SpriteManager(BlockyGame blockyGame, EntityManager entityManager)
        {
            this.blockyGame = blockyGame;
            this.entityManager = entityManager;
        }

        public void Load()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(blockyGame.GraphicsDevice);
        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront);

            foreach (var entity in entityManager.Entities)
            {
                switch (entity)
                {
                    case Structure structure:
                        spriteBatch.Draw(entity.Texture, new Rectangle(entity.Position.ToPoint(), structure.Size.ToPoint()), Color.White);
                        break;

                    default:
                        spriteBatch.Draw(entity.Texture, entity.Position, Color.White);
                        break;
                }
            }

            spriteBatch.End();
        }

        public void Dispose()
        {
            entityManager?.Dispose();
            entityManager = null;

            spriteBatch?.Dispose();
            spriteBatch = null;
        }
    }
}
