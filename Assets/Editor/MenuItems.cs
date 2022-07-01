using UnityEditor;

public class MenuItems
{
    [MenuItem("Geekbrains/Пункт меню %p")]
    private static void MenuOption()
    {
        EditorWindow.GetWindow(typeof(MyWindow), false, "GeekBrains");
    }
}
