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
            private Rectangle rect;
            private Vector2 movement;
            private bool destroyOutScreen;
            private double timer;
            private string options;

            public GFX(Texture2D texture, Rectangle rect, Vector2 move, bool destroyOutScreen, double timer, string options)
            {
                this.texture = texture;
                this.rect = rect;
                this.movement = move;
                this.destroyOutScreen = destroyOutScreen;
                this.timer = timer;
                this.options = options;
            }

            public void Update(GameTime gt) { 
            
            }

            public void Draw(SpriteBatch sb) { 
            
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
        public static void CreateGFX(Texture2D texture, Rectangle rect, Vector2 move, bool destroyOutScreen, double timer, string options) {
            if (gfx == null)
                gfx = new List<GFX>();

            GFX t = new GFX(texture,rect,move,destroyOutScreen,timer,options);
            gfx.Add(t);
        }

        public static void Update(GameTime gt) {
            for (int i = 0; i < gfx.Count; i++) {
                gfx[i].Update(gt);
            }
        }

        public static void Draw(SpriteBatch sb) {
            for (int i = 0; i < gfx.Count; i++) {
                gfx[i].Draw(sb);
            }
        }

    }
}
