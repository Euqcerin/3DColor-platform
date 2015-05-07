using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLibrary;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ContentLibrary;

namespace _3DColor.State
{
    class Intro : BaseState
    {
        #region TEXTUREPATHS
        private const string BACKGROUND = "Graphics/Intro/Background";
        private const string NAME = "Graphics/Intro/Name";
        private const string TEXT = "Graphics/Intro/Text";
        #endregion

        #region FIELDS
        private Texture2D t_background;
        private Texture2D t_name;
        private Texture2D t_text;
        #endregion

        public Intro() : base() { 
        
        }

        public override void LoadContent()
        {
            t_background = TextureLibrary.GetTexture(BACKGROUND);
            t_name = TextureLibrary.GetTexture(NAME);
            t_text = TextureLibrary.GetTexture(TEXT);
            base.LoadContent();
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }

    }
}
