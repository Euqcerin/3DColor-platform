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
    class FontLibrary
    {

        public static ContentManager Content;

        /// <summary>
        /// Loads a font
        /// </summary>
        /// <param name="sName">Searchpath of the font</param>
        /// <returns>Returns font</returns>
        public static SpriteFont GetFont(string sName)
        {
            SpriteFont font = null;
            font = Content.Load<SpriteFont>(sName);
            return font;
        }
    }
}
