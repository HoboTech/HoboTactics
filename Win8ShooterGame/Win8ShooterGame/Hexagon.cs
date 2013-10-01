using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Win8ShooterGame
{
    class Hexagon
    {
        Line edge;

        public void Initialize(Texture2D texture)
        {
            edge = new Line();
            edge.Initialize(texture);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 center, float size = 75)
        {

            double theta_1, theta_2;
            float x_1, y_1, x_2, y_2;
            double pi = Math.PI;
            Vector2 point_1, point_2; 
      
            for (int i =0; i <6; i++)
            {
                theta_1 = 2 * (pi / 6) * ( i + 0.5);
                theta_2 = 2 * (pi / 6) * ( (i + 1) + 0.5);
                x_1 = (float)(center.X + (size * Math.Cos(theta_1)));
                y_1 = (float)(center.Y + (size * Math.Sin(theta_1)));
                x_2 = (float)(center.X + (size * Math.Cos(theta_2)));
                y_2 = (float)(center.Y + (size * Math.Sin(theta_2)));
                point_1 = new Vector2(x_1, y_1);
                point_2 = new Vector2(x_2, y_2);

                edge.Draw(spriteBatch, point_1, point_2, Color.White);
            }     

        }
    }
}
