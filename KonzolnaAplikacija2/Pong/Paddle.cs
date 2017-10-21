using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Pong
{
    /// <summary>
    /// Represents player paddle.
    /// </summary>
    public class Paddle : Sprite
    {
        /// <summary>
        /// Current paddle speed.
        /// </summary>
        public float Speed { get; set; }

        public Paddle(int width, int height, float initialSpeed) : base(width, height)
        {
            Speed = initialSpeed;
        }
        public override void DrawSpriteOnScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Vector2(X, Y), new Rectangle(0, 0, Width, Height), Color.GhostWhite);
        }

    }
}
