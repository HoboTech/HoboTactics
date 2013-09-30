using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Win8ShooterGame
{
    class Hexagon
    {
        float sideLenght, centerX = 200, centerY = 600, size = 75;
        Line s1, s2, s3, s4, s5, s6;

        public void Initialize(Texture2D texture)
        {
            s1 = new Line();
            s2 = new Line();
            s3 = new Line();
            s4 = new Line();
            s5 = new Line();
            s6 = new Line();

            s1.Initialize(texture);
            s2.Initialize(texture);
            s3.Initialize(texture);
            s4.Initialize(texture);
            s5.Initialize(texture);
            s6.Initialize(texture);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            double theta, theta2;
            float x_i, y_i, x_i2, y_i2;
            double pi = Math.PI;
            Vector2 point_1, point_2; 
      
            for (int i =0; i <6; i++)
            {
                theta = 2 * (pi / 6) * ( i + 0.5);
                theta2 = 2 * (pi / 6) * ( (i + 1) + 0.5);
                x_i = (float)(centerX + (size * Math.Cos(theta)));
                y_i = (float)(centerY + (size * Math.Sin(theta)));
                x_i2 = (float)(centerX + (size * Math.Cos(theta2)));
                y_i2 = (float)(centerY + (size * Math.Sin(theta2)));
                point_1 = new Vector2(x_i, y_i);
                point_2 = new Vector2(x_i2, y_i2);

                if (i == 0) s1.Draw(spriteBatch, point_1, point_2, Color.White);
                else if (i == 1) s2.Draw(spriteBatch, point_1, point_2, Color.White);
                else if (i == 2) s2.Draw(spriteBatch, point_1, point_2, Color.White);
                else if (i == 3) s2.Draw(spriteBatch, point_1, point_2, Color.White);
                else if (i == 4) s2.Draw(spriteBatch, point_1, point_2, Color.White);
                else if (i == 5) s2.Draw(spriteBatch, point_1, point_2, Color.White);
            }
                
        }
    }
}
