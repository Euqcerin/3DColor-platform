using ContentLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DColor.State
{
    class LevelSelect : BaseState
    {

        struct LevelRect {

            public Texture2D t_texture {
                get { return t_texture; }
                private set { t_texture = value; }
            }

            public Rectangle t_rectangle {
                get { return t_rectangle; }
                private set { t_rectangle = value; }
            }

            public LevelRect(int pos, Texture2D texture) {
                t_rectangle = new Rectangle(0, pos * (Values.SCREEN_HEIGHT / 15) + pos * (Values.SCREEN_HEIGHT / 30), Values.SCREEN_WIDTH / 3, Values.SCREEN_HEIGHT / 15);
                t_texture = texture;
            }

        }

        private const string SELECT_1 = "LevelSelect/SelectBackground1";
        private const string SELECT_2 = "LevelSelect/SelectBackground2";

        private const int t_number_of_levels = 7;
        private List<LevelRect> Levels = new List<LevelRect>();
        public Texture2D text_background_select_1;
        public Texture2D text_background_select_2;

        public LevelSelect() : base() {
            LoadContent();
            InitLevels();
        }

        public override void LoadContent()
        {
            text_background_select_1 = TextureLibrary.GetTexture(SELECT_1);
            text_background_select_2 = TextureLibrary.GetTexture(SELECT_2);
            base.LoadContent();
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < t_number_of_levels; i++)
                sb.Draw(Levels[i].t_texture, Levels[i].t_rectangle, Color.White);
            base.Draw(sb);
        }

        private void InitLevels()
        {
            for (int i = 0; i < t_number_of_levels; i++)
            { 
                if(i%2 == 0)
                    Levels.Add(new LevelRect(i, text_background_select_1));
                else
                    Levels.Add(new LevelRect(i, text_background_select_2));
            }
        }
    }
}
