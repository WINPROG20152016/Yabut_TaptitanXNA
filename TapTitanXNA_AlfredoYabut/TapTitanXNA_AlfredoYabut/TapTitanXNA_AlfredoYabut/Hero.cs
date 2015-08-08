using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_AlfredoYabut
{
    public class Hero
    {
        Vector2 playerPosition;
        Texture2D player;
        Texture2D player2;
        ContentManager content;
        public static int windowWidth = 600;
        public static int windowHeight = 500;
        Level level;

        Animation backAnimation;
        Animation frontAnimation;
        AnimationPlayer spritePlayer;
        int characterChooser;

        public Hero(ContentManager content, Level level, int characterChooser)
        {
            this.content = content;
            this.level = level;
            this.characterChooser = characterChooser;
        }

        public void LoadContent()
        {
            if (characterChooser == 0)
            {
                player = content.Load<Texture2D>("Hero sprite/linkidle");
                player2 = content.Load<Texture2D>("Hero sprite/linkslash");


                backAnimation = new Animation(player, 0.1f, true, 3);
                frontAnimation = new Animation(player2, 0.1f, true, 3);
            }
            else if (characterChooser == 1)
            {
                player = content.Load<Texture2D>("Hero sprite/ganonidle");
                player2 = content.Load<Texture2D>("Hero sprite/ganonatk");


                backAnimation = new Animation(player, 0.1f, true, 4);
                frontAnimation = new Animation(player2, 0.1f, true, 4);
            }

            int positionX = (windowWidth / 3 ) - (player.Width /-1);
            int positionY = (windowHeight / 2) - (player.Height / -1);
            playerPosition = new Vector2((float)positionX, (float)positionY);

            spritePlayer.PlayAnimation(backAnimation);
}
        public void Update(GameTime gameTime)
        {
            if (level.keyState.IsKeyDown(Keys.S))
            {
                playerPosition.X += 5;
                spritePlayer.PlayAnimation(frontAnimation);
            }
            if (level.keyState.IsKeyDown(Keys.Down))
            {
                playerPosition.X -= 5;
                spritePlayer.PlayAnimation(frontAnimation);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            /*spriteBatch.Draw(player,
            playerPosition,
            null,
            Color.White,
            0.0f,
            Vector2.Zero,
            0.5f,
            SpriteEffects.None,
            0.0f);*/
            spritePlayer.Draw(gameTime, spriteBatch,
                playerPosition, SpriteEffects.None);
        }
    }
  }



