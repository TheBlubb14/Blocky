using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocky.Model
{
    public class Structure : Entity
    {
        public Vector2 Size { get; set; }

        public Structure(Vector2 size)
        {
            Size = size;
        }
    }
}
