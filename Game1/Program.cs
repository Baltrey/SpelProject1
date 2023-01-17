global using System.Numerics;
//saker för att sätta igång raylib
global using Raylib_cs;
Raylib.InitWindow(800, 600, "Game");
Raylib.SetTargetFPS(60);

//variabler för att karaktären ska gå utan att hålla ner en tagent
bool KEYD = false;
bool KEYA = false;
bool KEYS = false;
bool KEYW = false;
int body = 0;
Random generator = new Random();

//laddar in texturerna
Texture2D background = Raylib.LoadTexture("Grass_Type.png");
Texture2D avatar = Raylib.LoadTexture("avatar.png");
Texture2D shell = Raylib.LoadTexture("shell.png");
//hitboxes
Rectangle playerRect = new Rectangle(0, 0, 64, 64);
Rectangle shellRect = new Rectangle(50, 50, 64, 64);
float speed = 4.5f;
string currentscene = "start";
while (Raylib.WindowShouldClose() == false)
{
    //logik så karaktären kan röra på sig
    if (currentscene == "game")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_D) || KEYD == true)
        {
            if (KEYA != true)
            {
                playerRect.x += speed;
                KEYD = true;
                KEYA = false;
                KEYS = false;
                KEYW = false;
            }
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_A) || KEYA == true)
        {
            if (KEYD != true)
            {
                playerRect.x -= speed;
                KEYD = false;
                KEYA = true;
                KEYS = false;
                KEYW = false;
            }
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_S) || KEYS == true)
        {
            if (KEYW != true)
            {
                playerRect.y += speed;
                KEYD = false;
                KEYA = false;
                KEYS = true;
                KEYW = false;
            }
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_W) || KEYW == true)
        {
            if (KEYS != true)
            {
                playerRect.y -= speed;
                KEYD = false;
                KEYA = false;
                KEYS = false;
                KEYW = true;
            }
        }
    }
    else if (currentscene == "start")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentscene = "game";
        }
    }

    //grafik för de scener jag har
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    if (currentscene == "game")
    {
        Raylib.DrawTexture(background, 0, 0, Color.WHITE);
        Raylib.DrawTexture(avatar,
            (int)playerRect.x,
            (int)playerRect.y,
            Color.WHITE);
        Raylib.DrawTexture(shell,
            (int)shellRect.x,
            (int)shellRect.y,
            Color.WHITE);
        if (Raylib.CheckCollisionRecs(playerRect, shellRect))
        {
            body++;
            shellRect.x = generator.Next(0, 800);
            shellRect.y = generator.Next(0, 600);

        }
        Raylib.DrawText(("Body:" + body.ToString()), 0, 500, 20, Color.BLACK);
    }
    else if (currentscene == "start")
    {
        Raylib.DrawText("Press ENTER to start", 100, 250, 50, Color.BLACK);
    }
    else if (currentscene == "End")
    {
        Raylib.DrawText("Game Over", 50, 560, 50, Color.RED);
    }
    Raylib.EndDrawing();

}