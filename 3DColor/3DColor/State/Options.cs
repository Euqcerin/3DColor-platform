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

        private List<ColorRect> l_color_rect = new List<ColorRect>();

        private const string BOX = "Graphics/Options/Box";

        private const string FONT = "Fonts/Options";

        private Texture2D t_box;

        private SpriteFont t_font;


        public Options() : base() 
        {
            LoadContent();
            InitColorRect();
        }

        private void InitColorRect() 
        { 
            //Blue
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(100, 500, 100, 100), Values.BLUE_DARK));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(130, 530, 100, 100), Values.BLUE_NORMAL));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(160, 560, 100, 100), Values.BLUE_LIGHT));

            //Green
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(300, 500, 100, 100), Values.GREEN_DARK));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(330, 530, 100, 100), Values.GREEN_NORMAL));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(360, 560, 100, 100), Values.GREEN_LIGHT));

            //Orange
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(500, 500, 100, 100), Values.ORANGE_DARK));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(530, 530, 100, 100), Values.ORANGE_NORMAL));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(560, 560, 100, 100), Values.ORANGE_LIGHT));

            //Purple
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(700, 500, 100, 100), Values.PURPLE_DARK));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(730, 530, 100, 100), Values.PURPLE_NORMAL));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(760, 560, 100, 100), Values.PURPLE_LIGHT));

            //Gray
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(900, 500, 100, 100), Values.GRAY_DARK));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(930, 530, 100, 100), Values.GRAY_NORMAL));
            l_color_rect.Add(new ColorRect(t_box, new Rectangle(960, 560, 100, 100), Values.GRAY_LIGHT));
                                                                 
        }

        public override void LoadContent()
        {
            t_box = TextureLibrary.GetTexture(BOX);
            t_font = FontLibrary.GetFont(FONT);

            base.LoadContent();
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < l_color_rect.Count; i++) {
                l_color_rect[i].Draw(sb);
            }

            sb.DrawString(t_font, "Blue", new Vector2(100, 440), Color.White);
            sb.DrawString(t_font, "Green", new Vector2(300, 440), Color.White);
            sb.DrawString(t_font, "Orange", new Vector2(500, 440), Color.White);
            sb.DrawString(t_font, "Purple", new Vector2(700, 440), Color.White);
            sb.DrawString(t_font, "Gray", new Vector2(900, 440), Color.White);

            base.Draw(sb);
        }

    }
}
