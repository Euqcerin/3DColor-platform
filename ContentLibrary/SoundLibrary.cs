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
    public class SoundLibrary
    {

        public static ContentManager Content;

        /// <summary>
        /// Loads a soundeffect
        /// </summary>
        /// <param name="sName">Searchpath for the soundeffect</param>
        /// <returns>Returns soundeffect</returns>
        public static SoundEffect GetSoundEffect(string sName) 
        {
            SoundEffect soundeffect = null;
            soundeffect = Content.Load<SoundEffect>(sName);
            return soundeffect;    
        }
    }
}
