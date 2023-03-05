// See https://aka.ms/new-console-template for more information

using OpenGLParticleSim;
using OpenTK.Windowing.Desktop;

using (MainGameWindow game = new MainGameWindow(GameWindowSettings.Default, NativeWindowSettings.Default))
{
    //run the game at 60 fps
    game.Run();
}
