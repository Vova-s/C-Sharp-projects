using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MultiTaskWPFApp
{
    public partial class Info : Window
    {
        // Declare UI elements
        Button ReturnToMain;
        Label label1;
        Label label2;

        // Constructor
        public Info()
        {
            // Initialize the window
            Initialization();
        }

        // Initialize UI elements and set window properties
        public void Initialization()
        {
            Height = 450;
            Width = 800;
            Grid grid = new Grid();
            Brush newColor1 = Brushes.White;
            FontWeight FW = FontWeights.Normal;
            FontWeight FW1 = FontWeights.Bold;

            // Create "Return to Main" button
            ReturnToMain = CreateElements.CreateButton(grid, "ReturnToMain", "MainWindow", HorizontalAlignment.Left, VerticalAlignment.Top, 600, 330, 115, 40, newColor1, ReturnToMain_Click);

            // Create labels
            label1 = CreateElements.CreateLabel(grid, "Symchych Volodymyr Antonovych", HorizontalAlignment.Left, VerticalAlignment.Top, 360, 55, newColor1, "Tw Cen MT Condensed", FW1, 24);
            label2 = CreateElements.CreateLabel(grid, "Thanks for your attention", HorizontalAlignment.Left, VerticalAlignment.Top, 395, 205, newColor1, "Tw Cen MT Condensed", FW1, 20);

            // Create and configure an ellipse with an image brush
            Ellipse el = new Ellipse();
            el.Width = 200;
            el.Height = 200;
            el.Margin = new Thickness(30, 70, 562, 149);
            ImageBrush imageBrush = new ImageBrush();
            // Provide the path to the image file
            imageBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\VOVAN\source\repos\MultiTaskWPFApp\78002.JPG", UriKind.Absolute));
            el.Fill = imageBrush;
            grid.Children.Add(el);

            // Set the content of the window to the grid
            Content = grid;
        }

        // Event handler for the "Return to Main" button click
        private void ReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            // Hide the current window and show the main window
            Hide();
            new MainWindow().Show();
        }
    }
}
