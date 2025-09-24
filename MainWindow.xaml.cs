using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _3sem1laba
{
    public partial class MainWindow : Window
    {
        private Triangle tr;
        private Rectangle rect;
        private Random rnd = new Random();
        private double lastX = 0;
        private double lastY = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawLine(Point2D p1, Point2D p2)
        {
            Line line = new Line
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                X1 = p1.getX(),
                Y1 = p1.getY(),
                X2 = p2.getX(),
                Y2 = p2.getY()
            };
            Scene.Children.Add(line);
        }
        public void DrawRectangle()
        {
            DrawLine(rect.getP1(), rect.getP2());
            DrawLine(rect.getP2(), rect.getP3());
            DrawLine(rect.getP3(), rect.getP4());
            DrawLine(rect.getP4(), rect.getP1());
        }

        public void genTriangle()
        {
            Point2D p1 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p2 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p3 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            tr = new Triangle(p1, p2, p3);
            SliderX.Value = 0;
            SliderY.Value = 0;
            lastX = 0;
            lastY = 0;
            Redraw();
        }
        public void genSquare()
        {
            int x1 = rnd.Next(0, (int)Scene.Width / 2);
            int y1 = rnd.Next(0, (int)Scene.Height / 2);
            int side = rnd.Next(20, 100);

            Point2D p1 = new Point2D(x1, y1);
            Point2D p2 = new Point2D(x1 + side, y1);
            Point2D p3 = new Point2D(x1 + side, y1 + side);
            Point2D p4 = new Point2D(x1, y1 + side);

            rect = new Rectangle(p1, p2, p3, p4);
            tr = null;
            SliderX.Value = 0;
            SliderY.Value = 0;
            lastX = 0;
            lastY = 0;
            Redraw();
        }
        public void genRectangle()
        {
            // создадим 2 точки, определяющие прямоугольник по диагоналям
            int x1 = rnd.Next(0, (int)Scene.Width / 2);
            int y1 = rnd.Next(0, (int)Scene.Height / 2);
            int width = rnd.Next(20, 100);
            int height = rnd.Next(20, 100);

            Point2D p1 = new Point2D(x1, y1);
            Point2D p2 = new Point2D(x1 + width, y1);
            Point2D p3 = new Point2D(x1 + width, y1 + height);
            Point2D p4 = new Point2D(x1, y1 + height);

            rect = new Rectangle(p1, p2, p3, p4);
            tr = null; // снимаем треугольник
            SliderX.Value = 0;
            SliderY.Value = 0;
            lastX = 0;
            lastY = 0;
            Redraw();
        }
        public void DrawTriangle()
        {
            DrawLine(tr.getP1(), tr.getP2());
            DrawLine(tr.getP2(), tr.getP3());
            DrawLine(tr.getP3(), tr.getP1());
        }

        public void ClearScene()
        {
            Scene.Children.Clear();
        }

        private void ButtonTriangle_Click(object sender, RoutedEventArgs e)
        {
            genTriangle();
            rect = null;
        }
        private void ButtonSquare_Click(object sender, RoutedEventArgs e)
        {
            genSquare();
            tr = null;
        }
        private void ButtonRectangle_Click(object sender, RoutedEventArgs e)
        {
            genRectangle();
            tr = null;
        }

        
        private void Redraw()
        {
            ClearScene();

            if (tr != null)
            {
                DrawTriangle();
            }
            else if (rect != null)
            {
                DrawRectangle();
            }

        }

        private void SliderX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tr == null && rect == null) return;
            int deltaX = (int)(e.NewValue - lastX);
            lastX = e.NewValue;
            if (tr != null)
            {
                tr.addX(deltaX);
            }
            else if (rect != null)
            {
                rect.addX(deltaX);
            }
            Redraw();
        }


        private void SliderY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tr == null && rect == null) return;
            int deltaY = (int)(e.NewValue - lastY);
            lastY = e.NewValue;
            if (tr != null)
            {
                tr.addY(deltaY);
            }
            else if (rect != null)
            {
                rect.addY(deltaY);
            }
            Redraw();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ClearScene();
            tr = null;
        }
    }
}
