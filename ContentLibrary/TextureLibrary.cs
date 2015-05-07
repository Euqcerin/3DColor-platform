using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ContentLibrary
{
    public class TextureLibrary
    {
        public static ContentManager Content;

        /// <summary>
        /// Loads a texture
        /// </summary>
        /// <param name="sName">Searchpath of the texture</param>
        /// <returns>Returns texture</returns>
        public static Texture2D GetTexture(string sName)
        {
            Texture2D texture = null;
            texture = Content.Load<Texture2D>(sName);
            return texture;
        }
    }
}
