using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLibrary;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ContentLibrary;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace _3DColor.State
{
    public class Intro : BaseState
    {
        #region Fields
        private const string BACKGROUND = "Graphics/General/Background";
        private const string LOGO = "Graphics/Intro/Logo";
        private const string TEXT = "Graphics/Intro/Text";
        private const string CLOUD1 = "Graphics/Intro/Cloud1";

        private Texture2D t_background;
        private Texture2D t_logo;
        private Texture2D t_text;
        private Texture2D t_cloud1;

        private double cloudTimer = 2;
        private double cloudTimerSpawn = 0;
        #endregion

        #region Constructor

        public Intro() : base() {
            LoadContent();
        }

        #endregion

        #region General Methods

        private void SpawnCloud() {
            Random rand = new Random();
            Libraries.GFXHelper.CreateGFX(t_cloud1,new Vector2(t_cloud1.Bounds.Width, t_cloud1.Bounds.Height), new Vector2(300, 100), new Vector2(3, 0), true, 5, "");
        }

        #endregion 

        #region XNA Methods

        public override void LoadContent()
        {
            t_background = TextureLibrary.GetTexture(BACKGROUND);
            t_logo = TextureLibrary.GetTexture(LOGO);
            t_cloud1 = TextureLibrary.GetTexture(CLOUD1);
            base.LoadContent();
        }

        public override void Update(GameTime gt)
        {
            cloudTimerSpawn += gt.ElapsedGameTime.TotalSeconds;
            if (cloudTimerSpawn >= cloudTimer){
                //SpawnCloud();
                cloudTimerSpawn = 0;
            }

            if (InputHandler.KeyReleased(Keys.N))
                Game1.state = new State.Menu();

            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Draw(t_logo, new Rectangle(1920 / 2 - t_logo.Bounds.Width / 2, 1080 / 2 - t_logo.Bounds.Height / 2, t_logo.Bounds.Width, t_logo.Bounds.Height), Color.White);

        }

        #endregion

    }
}
