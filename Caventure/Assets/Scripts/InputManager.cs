using UnityEngine;

public static class InputManager
{
    public static bool Up => Input.GetKeyDown(KeyCode.Space);

    public static bool Down => Input.GetKeyDown(KeyCode.LeftControl);

    public static bool Forward => Input.GetKeyDown(KeyCode.W);

    public static bool Back => Input.GetKeyDown(KeyCode.S);

    public static bool Left => Input.GetKeyDown(KeyCode.A);

    public static bool Right => Input.GetKeyDown(KeyCode.D);
}
