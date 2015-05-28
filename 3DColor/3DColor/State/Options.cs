using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _3DColor.State
{
    public class Options : BaseState
    {
        #region Fields

        private const string BACKGROUND = "Graphics/General/Background";
        private const string BOX = "Graphics/General/Box";
        private const string FONT = "Fonts/Options";
        private const string FRAME = "Graphics/Options/Frame";

        private Texture2D t_box;
        private Texture2D t_background;
        private Texture2D t_frame;
        private SpriteFont t_font;

        #region Controller fields
        private const string CONTROLLER = "Graphics/Options/Controller";
        private const string KEYBOARD = "Graphics/Options/Keyboard";

        private Texture2D t_keyboard;
        private Texture2D t_controller;

        private Rectangle t_controller_rect;
        private Rectangle t_keyboard_rect;
        
        //0 - Keyboard
        //1 - Controller
        private int t_current_controller;

        #endregion

        #region Color scheme fields

        private const string BLUE = "Graphics/Options/Blue";
        private const string GREEN = "Graphics/Options/Green";
        private const string GRAY = "Graphics/Options/Gray";
        private const string ORANGE = "Graphics/Options/Orange";
        private const string PURPLE = "Graphics/Options/Purple";

        private Texture2D tex_blue;
        private Texture2D tex_green;
        private Texture2D tex_gray;
        private Texture2D tex_orange;
        private Texture2D tex_purple;

        private Rectangle t_blue_rect;
        private Rectangle t_green_rect;
        private Rectangle t_orange_rect;
        private Rectangle t_purple_rect;
        private Rectangle t_gray_rect;

        private Rectangle t_current_color_rect;

        private string t_color_scheme;

        //0 - Blue
        //1 - Gray
        //2 - Green
        //3 - Orange
        //4 - Purple
        private int t_current_color;

        #endregion

        #endregion

        #region Contructor
        public Options() : base() 
        {
            t_color_scheme = "Blue";

            LoadContent();
            InitColorRect();
            InitControllersOption();
        }

        #endregion

        #region XNA Methods

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="gt">Gametime</param>
        public override void Update(GameTime gt)
        {

            ChangeColorScheme();
            ChangeController();

            if (InputHandler.KeyReleased(Keys.B))
                Game1.state = new Menu();

            base.Update(gt);
        }
        
        /// <summary>
        /// Draw methos
        /// </summary>
        /// <param name="sb">Spritebatch</param>
        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);


            //sb.DrawString(t_font, "Color scheme: " + t_color_scheme.ToString(), new Vector2(1, 100), Color.White);

            sb.Draw(tex_blue, t_blue_rect, Color.White);
            sb.Draw(tex_gray, t_gray_rect, Color.White);
            sb.Draw(tex_green, t_green_rect, Color.White);
            sb.Draw(tex_orange, t_orange_rect, Color.White);
            sb.Draw(tex_purple, t_purple_rect, Color.White);
            sb.Draw(t_frame, t_current_color_rect, Color.White);

            if (t_current_controller == 0) //Keyboard
                sb.Draw(t_frame, t_keyboard_rect, Color.White);
            else
                sb.Draw(t_frame, t_controller_rect, Color.White);
            sb.Draw(t_keyboard, t_keyboard_rect, Color.White);
            sb.Draw(t_controller, t_controller_rect, Color.White);

        }

        #endregion

        #region General Methods

        /// <summary>
        /// Loads all the content needed for the optiosn screen
        /// </summary>
        public override void LoadContent()
        {
            t_box = TextureLibrary.GetTexture(BOX);
            t_font = FontLibrary.GetFont(FONT);
            t_background = TextureLibrary.GetTexture(BACKGROUND);
            t_keyboard = TextureLibrary.GetTexture(KEYBOARD);
            t_controller = TextureLibrary.GetTexture(CONTROLLER);
            t_frame = TextureLibrary.GetTexture(FRAME);

            tex_blue = TextureLibrary.GetTexture(BLUE);
            tex_gray = TextureLibrary.GetTexture(GRAY);
            tex_green = TextureLibrary.GetTexture(GREEN);
            tex_orange = TextureLibrary.GetTexture(ORANGE);
            tex_purple = TextureLibrary.GetTexture(PURPLE);

            base.LoadContent();
        }

        /// <summary>
        /// Draws all the text on the options screen
        /// </summary>
        /// <param name="sb"></param>
        private void DrawText(SpriteBatch sb)
        {
            sb.DrawString(t_font, "Blue", new Vector2(98, 438), Color.Black);
            sb.DrawString(t_font, "Blue", new Vector2(100, 440), Color.White);
            sb.DrawString(t_font, "Green", new Vector2(298, 438), Color.Black);
            sb.DrawString(t_font, "Green", new Vector2(300, 440), Color.White);
            sb.DrawString(t_font, "Orange", new Vector2(498, 438), Color.Black);
            sb.DrawString(t_font, "Orange", new Vector2(500, 440), Color.White);
            sb.DrawString(t_font, "Purple", new Vector2(698, 438), Color.Black);
            sb.DrawString(t_font, "Purple", new Vector2(700, 440), Color.White);
            sb.DrawString(t_font, "Gray", new Vector2(898, 438), Color.Black);
            sb.DrawString(t_font, "Gray", new Vector2(900, 440), Color.White);
        }

        /// <summary>
        /// Initiates all the color options
        /// </summary>
        private void InitColorRect()
        {
            t_blue_rect = new Rectangle((int)(Values.SCREEN_WIDTH * 0.05), (int)(Values.SCREEN_HEIGHT - (Values.SCREEN_WIDTH * 0.1 + 300)), 150, 150);
            t_green_rect = new Rectangle((int)(Values.SCREEN_WIDTH * 0.075 + 150), (int)(Values.SCREEN_HEIGHT - (Values.SCREEN_WIDTH * 0.1 + 300)), 150, 150);
            t_orange_rect = new Rectangle((int)(Values.SCREEN_WIDTH * 0.1 + 300), (int)(Values.SCREEN_HEIGHT - (Values.SCREEN_WIDTH * 0.1 + 300)), 150, 150);
            t_purple_rect = new Rectangle((int)(Values.SCREEN_WIDTH * 0.125 + 450), (int)(Values.SCREEN_HEIGHT - (Values.SCREEN_WIDTH * 0.1 + 300)), 150, 150);
            t_gray_rect = new Rectangle((int)(Values.SCREEN_WIDTH * 0.15 + 600), (int)(Values.SCREEN_HEIGHT - (Values.SCREEN_WIDTH * 0.1 + 300)), 150, 150);
            t_current_color_rect = t_blue_rect;
            t_current_color = 0;
        }

        /// <summary>
        /// Initiates all the controller options
        /// </summary>
        private void InitControllersOption()
        { 
            t_keyboard_rect = new Rectangle((int)(Values.SCREEN_WIDTH * 0.05), (int)(Values.SCREEN_HEIGHT - (Values.SCREEN_WIDTH * 0.05 + 150)), 150, 150);
            t_controller_rect = new Rectangle((int)((Values.SCREEN_WIDTH * 0.075) + 150), (int)(Values.SCREEN_HEIGHT - (Values.SCREEN_WIDTH * 0.05 + 150)), 150, 150);
            t_current_controller = 0;

        }

        /// <summary>
        /// Changes the color scheme if a color scheme is clicked
        /// </summary>
        private void ChangeColorScheme()
        {

            if (t_blue_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
            {
                t_color_scheme = "Blue";
                Values.CURRENT_DARK = Values.BLUE_DARK;
                Values.CURRENT_NORMAL = Values.BLUE_NORMAL;
                Values.CURRENT_LIGHT = Values.BLUE_LIGHT;
                t_current_color = 0;
                t_current_color_rect = t_blue_rect;
            }
            else if (t_green_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
            {
                t_color_scheme = "Green"; 
                Values.CURRENT_DARK = Values.GREEN_DARK;
                Values.CURRENT_NORMAL = Values.GREEN_NORMAL;
                Values.CURRENT_LIGHT = Values.GREEN_LIGHT;
                t_current_color = 1;
                t_current_color_rect = t_green_rect;
            }
            else if (t_orange_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
            {
                t_color_scheme = "Orange";
                Values.CURRENT_DARK = Values.ORANGE_DARK;
                Values.CURRENT_NORMAL = Values.ORANGE_NORMAL;
                Values.CURRENT_LIGHT = Values.ORANGE_LIGHT;
                t_current_color = 2;
                t_current_color_rect = t_orange_rect;
            }
            else if (t_purple_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
            {
                t_color_scheme = "Purple";
                Values.CURRENT_DARK = Values.PURPLE_DARK;
                Values.CURRENT_NORMAL = Values.PURPLE_NORMAL;
                Values.CURRENT_LIGHT = Values.PURPLE_LIGHT;
                t_current_color = 3;
                t_current_color_rect = t_purple_rect;
            }
            else if (t_gray_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
            {
                t_color_scheme = "Gray";
                Values.CURRENT_DARK = Values.GRAY_DARK;
                Values.CURRENT_NORMAL = Values.GRAY_NORMAL;
                Values.CURRENT_LIGHT = Values.GRAY_LIGHT;
                t_current_color = 4;
                t_current_color_rect = t_gray_rect;
            }
        
        }

        private void ChangeController() 
        {
            if (t_keyboard_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
                t_current_controller = 0;
            else if (t_controller_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
                t_current_controller = 1;
        }

        #endregion

    }
}
