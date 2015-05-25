using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DColor.State
{
    public class BaseState
    {
        private Texture2D rect;

        private const string BOX = "Graphics/General/Box";


        public BaseState()
        {
            LoadContent();
        }

        public virtual void LoadContent() {
            rect = ContentLibrary.TextureLibrary.GetTexture(BOX);
        }

        public virtual void Update(GameTime gt) { 
        
        }

        public virtual void Draw(SpriteBatch sb) {
            sb.Draw(rect, new Rectangle(0, 780, 1920, 300), Values.CURRENT_NORMAL);
            sb.Draw(rect, new Rectangle(400, 580, 120, 200), Values.CURRENT_DARK);
            sb.Draw(rect, new Rectangle(1200, 680, 300, 100), Values.CURRENT_LIGHT);
        }
    }
}
