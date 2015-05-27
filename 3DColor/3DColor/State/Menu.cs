using ContentLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DColor.State
{
    public class Menu : BaseState
    {
        #region Fields
        private const string BACKGROUND = "Graphics/General/Background";

        private const string FONT = "Fonts/Intro";

        private Texture2D t_background;

        private SpriteFont t_font;

        private Vector2 t_play_pos;
        private Vector2 t_options_pos;
        private Vector2 t_exit_pos;

        private Rectangle t_play_rect;
        private Rectangle t_options_rect;
        private Rectangle t_exit_rect;
        #endregion

        #region Constructor

        public Menu() : base() {
            LoadContent();
            SetFontPosition();
        }

        #endregion

        #region XNA Methods

        public override void Update(GameTime gt)
        {
            if (t_play_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased()) { 

            }

            else if (t_options_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased()) {
                Game1.state = new Options();   
            }

            else if (t_exit_rect.Contains(InputHandler.MousePosition())) {
                
            }

                base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.DrawString(t_font, "PLAY", t_play_pos, Color.White);
            sb.DrawString(t_font, "OPTIONS", t_options_pos, Color.White);
            sb.DrawString(t_font, "EXIT", t_exit_pos, Color.White);

        }

        #endregion

        #region General Methods

        private void SetFontPosition()
        {
            Vector2 temp;
            temp = t_font.MeasureString("PLAY");
            t_play_pos = new Vector2(Values.SCREEN_WIDTH / 2 - temp.X / 2, Values.SCREEN_HEIGHT / 2);
            t_play_rect = new Rectangle((int)t_play_pos.X, (int)t_play_pos.Y, (int)temp.X, (int)temp.Y);
            temp = t_font.MeasureString("OPTIONS");
            t_options_pos = new Vector2(Values.SCREEN_WIDTH / 2 - temp.X / 2, Values.SCREEN_HEIGHT / 2 + 120);
            t_options_rect = new Rectangle((int)t_options_pos.X, (int)t_options_pos.Y, (int)temp.X, (int)temp.Y);
            temp = t_font.MeasureString("EXIT");
            t_exit_pos = new Vector2(Values.SCREEN_WIDTH / 2 - temp.X / 2, Values.SCREEN_HEIGHT / 2 + 240);
            t_exit_rect = new Rectangle((int)t_exit_pos.X, (int)t_exit_pos.Y, (int)temp.X, (int)temp.Y);

        }

        public override void LoadContent()
        {
            t_background = TextureLibrary.GetTexture(BACKGROUND);
            t_font = FontLibrary.GetFont(FONT);
            base.LoadContent();
        }

        private void AnimateIn()
        { 
            
        }

        #endregion

    }
}
