using Microsoft.UI.Input;
using Microsoft.UI.Xaml.Controls;

namespace Interfaz
{
    public class Button2 : Button
    {
        public void CambiarCursor(InputCursor cursor)
        {
            this.ProtectedCursor = cursor;
        }
    }

    public class ComboBox2 : ComboBox
    {
        public void CambiarCursor(InputCursor cursor)
        {
            this.ProtectedCursor = cursor;
        }
    }

    public class StackPanel2 : StackPanel
    {
        public void CambiarCursor(InputCursor cursor)
        {
            this.ProtectedCursor = cursor;
        }
    }

    public class NavigationViewItem2 : NavigationViewItem
    {
        public void CambiarCursor(InputCursor cursor)
        {
            this.ProtectedCursor = cursor;
        }
    }

    public class MenuFlyoutItem2 : MenuFlyoutItem
    {
        public void CambiarCursor(InputCursor cursor)
        {
            this.ProtectedCursor = cursor;
        }
    }
}
