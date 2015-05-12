using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DColor.Libraries
{
    static class GFXHelper
    {
        #region FIELDS
        private static List<GFX> gfx = new List<GFX>();
        #endregion

        /// <summary>
        /// Creates a new GFX
        /// </summary>
        /// <param name="texture">Texture</param>
        /// <param name="size">Size</param>
        /// <param name="position">Position</param>
        /// <param name="move">Movement</param>
        /// <param name="destroyOutScreen">Should it be destroyed outside of the screen</param>
        /// <param name="timer">Time in seconds it should be alive, can be 0 (Infinite)</param>
        /// <param name="options">Not in use</param>
        public static void CreateGFX(Texture2D texture, Vector2 size, Vector2 position, Vector2 move, bool destroyOutScreen, double timer, string options) {
            GFX t = new GFX(texture,size,position,move,destroyOutScreen,timer,options);
            gfx.Add(t);
        }

        /// <summary>
        /// Updates all GFX
        /// </summary>
        /// <param name="gt">GameTime</param>
        public static void Update(GameTime gt) {
            for (int i = gfx.Count - 1; i > -1; i--)
            {
                gfx[i].Update(gt);
                if (gfx[i].destroy == true)
                    gfx.RemoveAt(i);
            }
        }

        /// <summary>
        /// Draws all GFX
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        public static void Draw(SpriteBatch sb) {
            for (int i = 0; i < gfx.Count; i++) {
                gfx[i].Draw(sb);
            }
        }

    }
}
