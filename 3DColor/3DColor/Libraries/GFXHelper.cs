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

        struct GFX {

            private Texture2D texture;
            private Vector2 position;
            private Vector2 size;
            private Vector2 movement;
            private bool destroyOutScreen;
            private bool timerDestroy;
            private double timer;
            private string options;

            private bool destroy;

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

            public void Update(GameTime gt) {
                if (timerDestroy == true)
                    timer -= gt.ElapsedGameTime.TotalSeconds;
                position += movement;
                
            }

            public void Draw(SpriteBatch sb) {
                sb.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), Color.White);
            }

            /// <summary>
            /// Checks if the GFX needs to be destroyed
            /// </summary>
            private void CheckDestroy() {
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


        private static List<GFX> gfx;

        /// <summary>
        /// Creates and updates a moving or stationary GFX
        /// </summary>
        /// <param name="texture">Texture</param>
        /// <param name="rect">Rectangle</param>
        /// <param name="move">Movement</param>
        /// <param name="destroyOutScreen">Destroys the GFX if it's outside the screen</param>
        /// <param name="timer">Destroys the timer after a certain time, can be 0</param>
        /// <param name="options">Empty for now</param>
        public static void CreateGFX(Texture2D texture, Vector2 size, Vector2 position, Vector2 move, bool destroyOutScreen, double timer, string options) {
            if (gfx == null)
                gfx = new List<GFX>();

            GFX t = new GFX(texture,size,position,move,destroyOutScreen,timer,options);
            gfx.Add(t);
        }

        public static void Update(GameTime gt) {
            if (gfx != null)
                for (int i = 0; i < gfx.Count; i++) {
                    gfx[i].Update(gt);
                }
        }

        public static void Draw(SpriteBatch sb) {
            if (gfx != null)
                for (int i = 0; i < gfx.Count; i++) {
                    gfx[i].Draw(sb);
                }
        }

    }
}
