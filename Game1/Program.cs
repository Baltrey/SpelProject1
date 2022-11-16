using Raylib_cs;

Raylib.InitWindow(800, 600, "Game");
Raylib.SetTargetFPS(60);

Texture2D background = Raylib.LoadTexture("Grass_Type.png");
Texture2D avatar = Raylib.LoadTexture("avatar.png");
Texture2D bullet = Raylib.LoadTexture("bullet.png");
Color hotpink = new Color(255, 105, 180, 255);
Rectangle playerRect = new Rectangle(0, 0, 64, 64);
float speed = 5.5f;
string currentscene = "start";
while (Raylib.WindowShouldClose() == false)
{

    if (currentscene == "game")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            playerRect.x += speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            playerRect.x -= speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            playerRect.y += speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            playerRect.y -= speed;
        }
    }
    else if (currentscene == "start")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentscene = "game";
        }
    }

    //grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    //Raylib.DrawRectangle(350, 250, 100, 100, hotpink);
    if (currentscene == "game")
    {
        Raylib.DrawTexture(background, 0, 0, Color.WHITE);
        Raylib.DrawTexture(avatar,
            (int)playerRect.x,
            (int)playerRect.y,
            Color.WHITE);
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            Raylib.DrawTexture(bullet,
                (int)playerRect.x + 55,
                (int)playerRect.y + 25,
                Color.WHITE
            );
        }
    }
    else if (currentscene == "start")
    {
        Raylib.DrawText("Press ENTER to start", 50, 560, 50, Color.BLACK);
    }
    else if (currentscene == "End")
    {
        Raylib.DrawText("Game Over", 50, 560, 50, Color.RED);
    }
    Raylib.EndDrawing();

}