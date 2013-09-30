using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Win8ShooterGame
{
    class Line
    {
        Texture2D pixelTexture;
        Vector2 begin = new Vector2(20, 20);
        Vector2 end = new Vector2(110, 110);
        Color color = Color.Red;

        public void Initialize(Texture2D texture)
        {
            pixelTexture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 begin, Vector2 end, Color color, int width = 1)
        {
            Rectangle r = new Rectangle((int)begin.X, (int)begin.Y, (int)(end - begin).Length() + width, width);
            Vector2 v = Vector2.Normalize(begin - end);
            float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
            if (begin.Y > end.Y) angle = MathHelper.TwoPi - angle;
            spriteBatch.Draw(pixelTexture, r, null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 5;
            Rectangle r = new Rectangle((int)begin.X, (int)begin.Y, (int)(end - begin).Length() + width, width);
            Vector2 v = Vector2.Normalize(begin - end);
            float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
            if (begin.Y > end.Y) angle = MathHelper.TwoPi - angle;
            spriteBatch.Draw(pixelTexture, r, null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
        }

    }
}
