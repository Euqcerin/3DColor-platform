﻿using Microsoft.Xna.Framework.Graphics;
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

        #region Structs

        struct ColorRect {

            Texture2D t_texture;
            Rectangle t_rect;
            Color t_color;

            public ColorRect(Texture2D t, Rectangle r, Color c) {
                t_texture = t;
                t_rect = r;
                t_color = c;
            }

            public void Draw(SpriteBatch sb) {
                sb.Draw(t_texture, t_rect, t_color);
            }
        }

        #endregion

        #region Fields

        private List<ColorRect> l_color_rect = new List<ColorRect>();

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

        private Rectangle t_blue_rect;
        private Rectangle t_green_rect;
        private Rectangle t_orange_rect;
        private Rectangle t_purple_rect;
        private Rectangle t_gray_rect;

        private Rectangle t_current_rect;

        private Rectangle t_choosencolor_left;
        private Rectangle t_choosencolor_right;
        private Rectangle t_choosencolor_top;
        private Rectangle t_choosencolor_bot;

        private string t_color_scheme;

        #endregion

        #endregion

        #region Contructor
        public Options() : base() 
        {
            t_color_scheme = "Blue";

            LoadContent();
            InitColorRect();
            InitControllersOption();
            t_current_rect = t_blue_rect;

            t_choosencolor_left = new Rectangle(t_current_rect.X - 20, t_current_rect.Y - 20, 5, t_current_rect.Height + 40);
            t_choosencolor_right = new Rectangle(t_current_rect.X + t_current_rect.Width + 15, t_current_rect.Y - 20, 5, t_current_rect.Height + 40);
            t_choosencolor_top = new Rectangle(t_current_rect.X - 20, t_current_rect.Y - 20, t_current_rect.Width + 40, 5);
            t_choosencolor_bot = new Rectangle(t_current_rect.X - 20, t_current_rect.Y + t_current_rect.Height + 15, t_current_rect.Width + 40, 5);
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

            if (InputHandler.KeyReleased(Keys.B))
                Game1.state = new Menu();

            t_choosencolor_left = new Rectangle(t_current_rect.X - 20, t_current_rect.Y - 20, 5, t_current_rect.Height + 40);
            t_choosencolor_right = new Rectangle(t_current_rect.X + t_current_rect.Width + 15, t_current_rect.Y - 20, 5, t_current_rect.Height + 40);
            t_choosencolor_top = new Rectangle(t_current_rect.X - 20, t_current_rect.Y - 20, t_current_rect.Width + 40, 5);
            t_choosencolor_bot = new Rectangle(t_current_rect.X - 20, t_current_rect.Y + t_current_rect.Height + 15, t_current_rect.Width + 40, 5);

            base.Update(gt);
        }
        
        /// <summary>
        /// Draw methos
        /// </summary>
        /// <param name="sb">Spritebatch</param>
        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);

            for (int i = 0; i < l_color_rect.Count; i++)
                l_color_rect[i].Draw(sb);

            sb.DrawString(t_font, "Color scheme: " + t_color_scheme.ToString(), new Vector2(1, 100), Color.White);
            sb.Draw(t_box, t_choosencolor_left, Color.White);
            sb.Draw(t_box, t_choosencolor_right, Color.White); 
            sb.Draw(t_box, t_choosencolor_top, Color.White);
            sb.Draw(t_box, t_choosencolor_bot, Color.White);
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
        /// Initiates all the color rectangles
        /// </summary>
        private void InitColorRect()
        {
            //Blue
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(100, 500, 100, 100), Values.BLUE_DARK));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(130, 530, 100, 100), Values.BLUE_NORMAL));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(160, 560, 100, 100), Values.BLUE_LIGHT));
            t_blue_rect = new Rectangle(100, 500, 160, 160);

            //Green
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(300, 500, 100, 100), Values.GREEN_DARK));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(330, 530, 100, 100), Values.GREEN_NORMAL));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(360, 560, 100, 100), Values.GREEN_LIGHT));
            t_green_rect = new Rectangle(300, 500, 160, 160);

            //Orange
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(500, 500, 100, 100), Values.ORANGE_DARK));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(530, 530, 100, 100), Values.ORANGE_NORMAL));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(560, 560, 100, 100), Values.ORANGE_LIGHT));
            t_orange_rect = new Rectangle(500, 500, 160, 160);

            //Purple
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(700, 500, 100, 100), Values.PURPLE_DARK));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(730, 530, 100, 100), Values.PURPLE_NORMAL));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(760, 560, 100, 100), Values.PURPLE_LIGHT));
            t_purple_rect = new Rectangle(700, 500, 160, 160);

            //Gray
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(900, 500, 100, 100), Values.GRAY_DARK));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(930, 530, 100, 100), Values.GRAY_NORMAL));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(960, 560, 100, 100), Values.GRAY_LIGHT));
            t_gray_rect = new Rectangle(900, 500, 160, 160);

        }

        private void InitControllersOption()
        { 
            //Keyboard
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
                t_current_rect = t_blue_rect;
            }
            else if (t_green_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
            {
                t_color_scheme = "Green"; 
                Values.CURRENT_DARK = Values.GREEN_DARK;
                Values.CURRENT_NORMAL = Values.GREEN_NORMAL;
                Values.CURRENT_LIGHT = Values.GREEN_LIGHT;
                t_current_rect = t_green_rect;
            }
            else if (t_orange_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
            {
                t_color_scheme = "Orange";
                Values.CURRENT_DARK = Values.ORANGE_DARK;
                Values.CURRENT_NORMAL = Values.ORANGE_NORMAL;
                Values.CURRENT_LIGHT = Values.ORANGE_LIGHT;
                t_current_rect = t_orange_rect;
            }
            else if (t_purple_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
            {
                t_color_scheme = "Purple";
                Values.CURRENT_DARK = Values.PURPLE_DARK;
                Values.CURRENT_NORMAL = Values.PURPLE_NORMAL;
                Values.CURRENT_LIGHT = Values.PURPLE_LIGHT;
                t_current_rect = t_purple_rect;
            }
            else if (t_gray_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
            {
                t_color_scheme = "Gray";
                Values.CURRENT_DARK = Values.GRAY_DARK;
                Values.CURRENT_NORMAL = Values.GRAY_NORMAL;
                Values.CURRENT_LIGHT = Values.GRAY_LIGHT;
                t_current_rect = t_gray_rect;
            }
        
        }

        #endregion

    }
}
