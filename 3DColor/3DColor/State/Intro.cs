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
        private const string TITLE = "Graphics/Intro/Title";
        private const string TEXT = "Graphics/Intro/Text";
        private const string CLOUD1 = "Graphics/Intro/Cloud1";
        #endregion

        #region FIELDS
        private Texture2D t_background;
        private Texture2D t_title;
        private Texture2D t_text;
        private Texture2D t_cloud1;
        #endregion

        public Intro() : base() { 
        
        }

        public override void LoadContent()
        {
            t_background = TextureLibrary.GetTexture(BACKGROUND);
            t_title = TextureLibrary.GetTexture(TITLE);
            t_text = TextureLibrary.GetTexture(TEXT);
            t_cloud1 = TextureLibrary.GetTexture(CLOUD1);
            base.LoadContent();
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(t_background, Vector2.Zero, Color.White);
            sb.Draw(t_title,
            base.Draw(sb);
        }

    }
}
