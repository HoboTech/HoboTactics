using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Win8ShooterGame
{
    class Square
    {
        Vector2 center = new Vector2(200 ,200);
        float sideLenght;
        Line s1, s2, s3, s4;

        public void Initialize(Texture2D texture)
        {
            s1 = new Line();
            s2 = new Line();
            s3 = new Line();
            s4 = new Line();

            s1.Initialize(texture);
            s2.Initialize(texture);
            s3.Initialize(texture);
            s4.Initialize(texture);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 corner_1 = new Vector2(500, 500);
            Vector2 corner_2 = new Vector2(600, 500);
            Vector2 corner_3 = new Vector2(600, 600);
            Vector2 corner_4 = new Vector2(500, 600);
            
            s1.Draw(spriteBatch, corner_1, corner_2, Color.Red);
            s2.Draw(spriteBatch, corner_2, corner_3, Color.Red);
            s3.Draw(spriteBatch, corner_3, corner_4, Color.Red);
            s4.Draw(spriteBatch, corner_4, corner_1, Color.Red);
        }


    }
}
