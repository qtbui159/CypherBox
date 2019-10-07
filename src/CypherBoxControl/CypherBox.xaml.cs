using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CypherBoxControl
{
    /// <summary>
    /// CypherBox.xaml 的交互逻辑
    /// </summary>
    public partial class CypherBox : UserControl
    {
        public string CypherText
        {
            get { return (string)GetValue(CypherTextProperty); }
            set { SetValue(CypherTextProperty, value); }
        }

        public static readonly DependencyProperty CypherTextProperty =
            DependencyProperty.Register("CypherText", typeof(string), typeof(CypherBox), new FrameworkPropertyMetadata(string.Empty, CypherTextPropertyChangedCallback)
            {
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            });

        public bool ShowPlainText
        {
            get { return (bool)GetValue(ShowPlainTextProperty); }
            set { SetValue(ShowPlainTextProperty, value); }
        }

        public static readonly DependencyProperty ShowPlainTextProperty =
            DependencyProperty.Register("ShowPlainText", typeof(bool), typeof(CypherBox), new PropertyMetadata(false));

        public char CypherChar
        {
            get { return (char)GetValue(CypherCharProperty); }
            set { SetValue(CypherCharProperty, value); }
        }

        public static readonly DependencyProperty CypherCharProperty =
            DependencyProperty.Register("CypherChar", typeof(char), typeof(CypherBox), new PropertyMetadata('●'));

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(CypherBox), new PropertyMetadata(string.Empty));


        private static void CypherTextPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CypherBox cypherBox = d as CypherBox;
            if (cypherBox == null)
            {
                return;
            }

            string value = e.NewValue as string;

            if (value == null)
            {
                cypherBox.txtOuter.Text = string.Empty;
            }
            else
            {
                cypherBox.txtOuter.Text = value;
            }
            cypherBox.txtOuter.CaretIndex = cypherBox.txtOuter.Text.Length;
        }

        public CypherBox()
        {
            InitializeComponent();

            CommandBinding pasteCommand = new CommandBinding(ApplicationCommands.Paste, null, CommandBinding_CanExecute);
            CommandBinding cutCommand = new CommandBinding(ApplicationCommands.Cut, null, CommandBinding_CanExecute);
            CommandBinding copyCommand = new CommandBinding(ApplicationCommands.Copy, null, CommandBinding_CanExecute);
            txtOuter.CommandBindings.Add(pasteCommand);
            txtOuter.CommandBindings.Add(cutCommand);
            txtOuter.CommandBindings.Add(copyCommand);
        }

        private void myUserControl_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Keyboard.Focus(txtOuter);
        }

        private void myUserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOuter.Focus();
        }
        private void txtOuter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CypherText = txtOuter.Text;
        }

        private void txtInner_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb == null)
            {
                return;
            }
            tb.ScrollToHorizontalOffset(tb.ExtentWidth);
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
            e.Handled = true;
        }
    }
}
