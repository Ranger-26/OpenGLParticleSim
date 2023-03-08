// See https://aka.ms/new-console-template for more information

using OpenGLParticleSim;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

var windowSettings = new NativeWindowSettings();
windowSettings.Size = new Vector2i(500,500);
using (MainGameWindow game = new MainGameWindow(GameWindowSettings.Default, windowSettings))
{
    //run the game at 60 fps
    game.Run();
}
