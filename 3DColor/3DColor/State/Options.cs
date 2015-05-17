using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentLibrary;
using Microsoft.Xna.Framework;

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

        private Texture2D t_box;
        private Texture2D t_background;
        private SpriteFont t_font;

        private Rectangle t_blue_rect;
        private Rectangle t_green_rect;
        private Rectangle t_orange_rect;
        private Rectangle t_purple_rect;
        private Rectangle t_gray_rect;

        private string t_color_scheme;
        
        #endregion

        #region Contructor
        public Options() : base() 
        {
            t_color_scheme = "Blue";

            LoadContent();
            InitColorRect();
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

            base.Update(gt);
        }

        /// <summary>
        /// Draw methos
        /// </summary>
        /// <param name="sb">Spritebatch</param>
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(t_background, new Rectangle(0, 0, 1920, 1080), Color.White);

            for (int i = 0; i < l_color_rect.Count; i++)
                l_color_rect[i].Draw(sb);

            sb.DrawString(t_font, "Color scheme: " + t_color_scheme.ToString(), new Vector2(1, 100), Color.White);

            base.Draw(sb);
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

        /// <summary>
        /// Changes the color scheme if a color scheme is clicked
        /// </summary>
        private void ChangeColorScheme()
        {

            if (t_blue_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
                t_color_scheme = "Blue";
            else if (t_green_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
                t_color_scheme = "Green";
            else if (t_orange_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
                t_color_scheme = "Orange";
            else if (t_purple_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
                t_color_scheme = "Purple";
            else if (t_gray_rect.Contains(InputHandler.MousePosition()) && InputHandler.MouseReleased())
                t_color_scheme = "Gray";
        
        }

        #endregion

    }
}
