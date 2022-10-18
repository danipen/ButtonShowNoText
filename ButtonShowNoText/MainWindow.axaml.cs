using Avalonia.Controls;
using Avalonia.Media;

namespace ButtonShowNoText
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            mShowView1Button.Click += ShowView1Button_Click;
            mShowView2Button.Click += ShowView2Button_Click;
            mShowContainer.Click += ShowContainer_Click;
            mHideContainer.Click += HideContainer_Click;
        }

        private void HideContainer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            GetView2().HideContainer();
        }

        void ShowContainer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            GetView2().ShowContainer();
        }

        void ShowView1Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            mTheContainerPanel.Children.Clear();
            mTheContainerPanel.Children.Add(GetView1());
        }

        void ShowView2Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            mTheContainerPanel.Children.Clear();
            mTheContainerPanel.Children.Add(GetView2());
        }

        View1 GetView1()
        {
            if (mView1 == null)
                mView1 = new View1();

            return mView1;
        }

        View2 GetView2()
        {
            if (mView2 == null)
                mView2 = new View2();

            return mView2;
        }

        View1 mView1;
        View2 mView2;
    }

    class View1: StackPanel
    {
        internal View1()
        {
            Background = Brushes.Pink;
            Children.Add(new TextBlock()
            {
                Text = "This is the view 1"
            });
        }
    }

    class View2 : StackPanel
    {
        internal View2()
        {
            Background = Brushes.Lime;
            mContainer = new StackPanel();

            mContainer.IsVisible = false;

            mButton1 = new Button()
            {
                Content = "Button1",
            };

            mButton2 = new Button()
            {
                Content = "Button2",
            };

            mContainer.Children.Add(mButton1);
            mContainer.Children.Add(mButton2);

            Children.Add(mContainer);
        }

        internal void HideContainer()
        {
            mContainer.IsVisible = false;
        }

        internal void ShowContainer()
        {
            mContainer.IsVisible = true;
        }

        Panel mContainer;

        Button mButton1;
        Button mButton2;
    }
}
