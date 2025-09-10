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

namespace _3sem1laba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Triangle tr;
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        public void DrawLine(Point2D p1, Point2D p2)
        {
            Line line = new Line();
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;
            line.X1= p1.getX();
            line.Y1= p1.getY();
            line.X2= p2.getX();
            line.Y2= p2.getY();
            Scene.Children.Add(line);
        }

        public void genTriangle()
        {
            Point2D p1 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0,
(int)Scene.Height));
            Point2D p2 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0,
           (int)Scene.Height));
            Point2D p3 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0,
           (int)Scene.Height));
            tr = new Triangle(p1, p2, p3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            genTriangle();
            DrawTriangle();

        }
        public void DrawTriangle()
        {
            //Отрисовка треугольника с помощью функции отрисовки линии
            DrawLine(tr.getP1(), tr.getP2());
            DrawLine(tr.getP2(), tr.getP3());
            DrawLine(tr.getP3(), tr.getP1());
        }
        public void ClearScene()
        {
            //Очистка Canvas от всех объектов
            Scene.Children.Clear();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearScene();
        }
        public void addX(int X)
        {
            
            p1.addX(X);
            p2.addX(X);
            p3.addX(X);
        }
        public void addY(int Y)
        {
            p1.addY(Y);
            p2.addY(Y);
            p3.addY(Y);
        }


        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}