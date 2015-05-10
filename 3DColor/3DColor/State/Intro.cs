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
    public class Intro : BaseState
    {
        #region TEXTUREPATHS
        private const string BACKGROUND = "Graphics/Intro/Background";
        private const string LOGO = "Graphics/Intro/Logo";
        private const string TEXT = "Graphics/Intro/Text";
        private const string CLOUD1 = "Graphics/Intro/Cloud1";
        #endregion

        #region FIELDS
        private Texture2D t_background;
        private Texture2D t_logo;
        private Texture2D t_text;
        private Texture2D t_cloud1;
        #endregion

        #region GFX FIELD
        private double cloudTimer = 5;
        private double cloudTimerSpawn = 0;
        #endregion

        public Intro() : base() { 
        
        }

        private void SpawnCloud() {
            Libraries.GFXHelper.CreateGFX(t_cloud1,new Vector2(t_cloud1.Bounds.Width, t_cloud1.Bounds.Height), new Vector2(300, 100), new Vector2(3, 0), true, 0, "");
        }

        #region Content, Draw, Update

        public override void LoadContent()
        {
            t_background = TextureLibrary.GetTexture(BACKGROUND);
            t_logo = TextureLibrary.GetTexture(LOGO);
            //t_text = TextureLibrary.GetTexture(TEXT);
            t_cloud1 = TextureLibrary.GetTexture(CLOUD1);
            base.LoadContent();
        }

        public override void Update(GameTime gt)
        {
            cloudTimerSpawn += gt.ElapsedGameTime.TotalSeconds;
            if (cloudTimerSpawn >= cloudTimer){
                SpawnCloud();
                cloudTimerSpawn = 0;
            }
            
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(t_background, Vector2.Zero, Color.White);
            sb.Draw(t_logo, new Rectangle(1920 / 2 - t_logo.Bounds.Width / 2, 1080 / 2 - t_logo.Bounds.Height / 2, t_logo.Bounds.Width, t_logo.Bounds.Height), Color.White);
            base.Draw(sb);
        }

        #endregion

    }
}
