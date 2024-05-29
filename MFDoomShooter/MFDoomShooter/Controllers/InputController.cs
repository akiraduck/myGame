using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace MFDoomShooter.Controllers;

public class InputController
{
    private static MouseState lastMouseState;
    private static KeyboardState lastKeyboardState;
    private static Vector2 direction;
    public static Vector2 Direction => direction;
    public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
    public static bool MouseClicked { get; private set; }
    public static bool MouseRightClicked { get; private set; }
    public static bool MouseLeftDown { get; private set; }
    public static bool SpacePressed { get; private set; }

    public static void Update()
    {
        var keyboardState = Keyboard.GetState();
        var mouseState = Mouse.GetState();

        direction = Vector2.Zero;
        if (keyboardState.IsKeyDown(Keys.W)) direction.Y--;
        if (keyboardState.IsKeyDown(Keys.S)) direction.Y++;
        if (keyboardState.IsKeyDown(Keys.A)) direction.X--;
        if (keyboardState.IsKeyDown(Keys.D)) direction.X++;

        MouseLeftDown = mouseState.LeftButton == ButtonState.Pressed;
        MouseClicked = MouseLeftDown && (lastMouseState.LeftButton == ButtonState.Released);
        MouseRightClicked = mouseState.RightButton == ButtonState.Pressed
                            && (lastMouseState.RightButton == ButtonState.Released);

        SpacePressed = lastKeyboardState.IsKeyUp(Keys.Space) && keyboardState.IsKeyDown(Keys.Space);

        lastMouseState = mouseState;
        lastKeyboardState = keyboardState;
    }
}