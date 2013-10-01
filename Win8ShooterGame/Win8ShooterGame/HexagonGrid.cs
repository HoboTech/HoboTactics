using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Win8ShooterGame
{
    class HexagonGrid
    {
        Hexagon hex;
        int gridLength = 9;
        int gridHeight = 6;

        public void Initialize(Texture2D texture)
        {
            hex = new Hexagon();
            hex.Initialize(texture);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 center, float size = 75)
        {
            //TODO 
            //Add a line of hexagons
            float height = size * 2;
            float width = (float)(Math.Sqrt(3) / 2) * height;

            for (int i = 0; i < gridHeight; i++)
            {
                center.Y = center.Y + ((3 * height) / 4);
                center.X = center.X + (width / 2);
                hex.Draw(spriteBatch, center, size);

                for (int j = 0; j < gridLength; j++)
                {
                    center.X = center.X + width;
                    hex.Draw(spriteBatch, center, size);
                }

                if (i % 2 == 0) { center.X = center.X - (gridLength * width); }
                else { center.X = center.X - (gridLength * width) - (width); }
                
            }
        }

    }
}
