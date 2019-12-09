using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;


namespace WpfFramework.Behaviors
{

    [TypeConstraint(typeof(TextBox))]
    public class NumericTextBoxBehavior : Behavior<TextBox>
    {
        /// <summary>
        /// SpaceCommand無効
        /// </summary>
        private KeyBinding SpaceKeyBinding { get; set; }

        /// <summary>
        /// ShiftSpaceCommand無効
        /// </summary>
        private KeyBinding ShiftSpaceKeyBinding { get; set; }

        /// <summary>
        /// Paste 数字のみ有効
        /// </summary>
        private CommandBinding PasteCommandBinding { get; set; }


        protected override void OnAttached()
        {

            this.AssociatedObject.ContextMenu = null;
            InputMethod.SetIsInputMethodEnabled(this.AssociatedObject, false);

            this.AssociatedObject.PreviewTextInput += PreviewTextInput;

            this.SpaceKeyBinding = new KeyBinding(ApplicationCommands.NotACommand, Key.Space, ModifierKeys.None);
            this.ShiftSpaceKeyBinding = new KeyBinding(ApplicationCommands.NotACommand, Key.Space, ModifierKeys.Shift);
            this.PasteCommandBinding = new CommandBinding(ApplicationCommands.Paste, ExecutePaste);

            AssociatedObject.InputBindings.Add(SpaceKeyBinding);
            AssociatedObject.InputBindings.Add(ShiftSpaceKeyBinding);
            AssociatedObject.CommandBindings.Add(PasteCommandBinding);

            base.OnAttached();
        }

        protected override void OnDetaching()
        {

            base.OnDetaching();

            AssociatedObject.InputBindings.Remove(SpaceKeyBinding);
            AssociatedObject.InputBindings.Remove(ShiftSpaceKeyBinding);
            AssociatedObject.CommandBindings.Remove(PasteCommandBinding);

            this.SpaceKeyBinding = null;
            this.ShiftSpaceKeyBinding = null;
            this.PasteCommandBinding = null;

            this.AssociatedObject.PreviewTextInput -= PreviewTextInput;
        }

        private void ExecutePaste(object sender, ExecutedRoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string text = Clipboard.GetText();

            if (int.TryParse(text, out _))
            {
                textbox.Paste();
            }
            else
            {
            }
        }


        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out _))
            {

            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
