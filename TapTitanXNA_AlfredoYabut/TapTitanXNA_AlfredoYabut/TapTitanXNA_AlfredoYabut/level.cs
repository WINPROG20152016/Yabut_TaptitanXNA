using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TapTitanXNA_AlfredoYabut
{
    public class Level
    {
        public KeyboardState oldKeyState;
        public KeyboardState keyState;
        bool kpressed, prev_kpressed = false;

        //public KeyboardState keyState;
        public static int windowWidth = 950;
        public static int windowHeight = 500;
        #region properties
        ContentManager content;
        Texture2D background;
        public MouseState oldMouseState;
        public MouseState mouseState;

        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;
        Hero hero;
        Hero support1;
        Hero support2;

        SpriteFont damageStringFont;
        int damageNumber = 0;
        int damageNumber2 = 0;
        Button playButton;
        Button attackButton;
        #endregion
        

        public Level(ContentManager content)
        {
            this.content = content;

            hero        = new Hero(content, this, 0);
            support1    = new Hero(content, this, 1);
        }

        public void LoadContent()
        {
            background = content.Load<Texture2D>("Hero sprite/settle");
            damageStringFont = content.Load<SpriteFont>("Font");

            //playButton = new Button(content, "Hero sprite", new Vector2(300, 300));
            //attackButton = new Button(content, "Hero sprite", new Vector2(300,300));

            hero.LoadContent();
            support1.LoadContent();
        }
        
        public void Update(GameTime gameTime)
       {

             keyState = Keyboard.GetState();
             prev_kpressed = kpressed;
             kpressed = keyState.IsKeyDown(Keys.Right);
             oldKeyState = keyState;
 
             mouseState = Mouse.GetState();
             mouseX = mouseState.X;
             mouseY = mouseState.Y;
             prev_mpressed = mpressed;
             mpressed = mouseState.LeftButton == ButtonState.Pressed;

             hero.Update(gameTime);
             support1.Update(gameTime);

            oldMouseState = mouseState;

            //attackButton.Update(gameTime, mouseX, mouseY,
                //mpressed, prev_mpressed);

            if (keyState.IsKeyDown(Keys.S))
            {
                damageNumber++;
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                damageNumber2++;
            }
       }

       public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(background,
            Vector2.Zero,
            null,
            Color.White,
            0.0f,
            Vector2.Zero,
            0.5f,
            SpriteEffects.None,
            0.0f);

            hero.Draw(gameTime, spriteBatch);
            support1.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(damageStringFont, damageNumber+ "                      Press S for Link and Down for Ganondorf",new Vector2(0, 0), Color.Red);

            spriteBatch.DrawString(damageStringFont, damageNumber2 + "", new Vector2(910, 0), Color.Red);
            if (damageNumber >= 500)
            {
                spriteBatch.DrawString(damageStringFont, "Ayy Lmao Bugan Player 1 wins!!!!", new Vector2(300, 130), Color.Pink);
            }
            if (damageNumber2 >= 500)
            {
                spriteBatch.DrawString(damageStringFont, "Ayy Lmao Bugan Player 2 wins!!!!", new Vector2(300, 130), Color.Pink);
            }

            //playButton.Draw(gameTime, spriteBatch);
        }
    }
}

