using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DColor
{
    class GFX
    {

        #region FIELDS
        private Texture2D texture;
        private Vector2 position;
        private Vector2 size;
        private Vector2 movement;
        private bool destroyOutScreen;
        private bool timerDestroy;
        private double timer;
        private string options;

        public bool destroy;

        #endregion

        /// <summary>
        /// Creates a new GFX which is then managed by GFXHelper
        /// </summary>
        /// <param name="texture">Texture</param>
        /// <param name="size">Size</param>
        /// <param name="position">Position</param>
        /// <param name="move">Movement</param>
        /// <param name="destroyOutScreen">Should it be destroyed outside of the screen</param>
        /// <param name="timer">Time in seconds it should be alive, can be 0 (Infinite)</param>
        /// <param name="options">Not in use</param>
        public GFX(Texture2D texture, Vector2 size, Vector2 position, Vector2 move, bool destroyOutScreen, double timer, string options)
        {
            this.texture = texture;
            this.size = size;
            this.position = position;
            this.movement = move;
            this.destroyOutScreen = destroyOutScreen;
            this.timer = timer;
            this.options = options;

            if (timer == 0)
                timerDestroy = false;
            else
                timerDestroy = true;

            destroy = false;
        }

        /// <summary>
        /// Updates the GFX
        /// </summary>
        /// <param name="gt">GameTime</param>
        public void Update(GameTime gt)
        {
            if (timerDestroy == true)
                timer -= gt.ElapsedGameTime.TotalSeconds;
            position = new Vector2(position.X + movement.X, position.Y);
            CheckDestroy();

        }

        /// <summary>
        /// Draws this GFX on the screen
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), Color.White);
        }

        /// <summary>
        /// Checks if the GFX needs to be destroyed
        /// </summary>
        private void CheckDestroy()
        {
            if (destroyOutScreen)
            {
                if (position.X >= 2000)
                    destroy = true;
                if (position.X <= (0 - size.X))
                    destroy = true;
            }

            if (timerDestroy)
                if (timer <= 0)
                    destroy = true;
        }

    }
}
