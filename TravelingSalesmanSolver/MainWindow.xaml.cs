using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TravelingSalesmanSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DispatcherTimer dT;
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List<Ellipse>();
        static PointCollection pC = new PointCollection();

        int finish, second_elem, after_last_elem, start_for_GA;

        public MainWindow()
        {
            dT = new DispatcherTimer();

            InitializeComponent();
            InitPoints();
            InitPolygon();

            dT = new DispatcherTimer();
            dT.Tick += new EventHandler(OneStep);
            dT.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }

        private void InitPoints()
        {
            Random rnd = new Random();
            pC.Clear();
            EllipseArray.Clear();



            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();

                p.X = rnd.Next(Radius, (int)(0.75 * TravelingSalesmanSolver.Width) - 3 * Radius);
                p.Y = rnd.Next(Radius, (int)(0.90 * TravelingSalesmanSolver.Height - 3 * Radius));
                pC.Add(p);

            }

            for (int i = 0; i < PointCount; i++)
            {
                Ellipse el = new Ellipse();

                el.StrokeThickness = 2;
                el.Height = el.Width = Radius;
                el.Stroke = Brushes.Black;
                el.Fill = Brushes.LightBlue;

                EllipseArray.Add(el);
            }
        }

        private void InitPolygon()
        {
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.StrokeThickness = 2;
        }

        private void PlotPoints()
        {
            for (int i = 0; i < PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius / 2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius / 2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }
        }


        private void PlotWay(int[] BestWayIndex)
        {
            EllipseArray[start_for_GA].Fill = Brushes.LightBlue;

            PointCollection Points = new PointCollection();

            for (int i = 0; i < BestWayIndex.Length; i++)
            {
                if (i == 0)
                {
                    EllipseArray[BestWayIndex[0]].Fill = Brushes.Red;
                    start_for_GA = BestWayIndex[0];
                }
                Points.Add(pC[BestWayIndex[i]]);
            }

            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);
        }

        private void VelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            dT.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(item.Content));
        }

        private void StopStart_Click(object sender, RoutedEventArgs e)
        {

            if (dT.IsEnabled)
            {
                dT.Stop();
                NumElemCB.IsEnabled = true;
            }
            else
            {
                NumElemCB.IsEnabled = false;
                dT.Start();
            }
        }

        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            PointCount = Convert.ToInt32(item.Content);
            InitPoints();
            InitPolygon();

            Count_Population = (int)Math.Floor(Math.Sqrt(PointCount) * 2);

            Ways = new int[2 * Count_Population, PointCount];
            fill = false;
        }

        bool fill = false;
        private void OneStep(object sender, EventArgs e)
        {
            MyCanvas.Children.Clear();

            PlotPoints();



            if (!fill)
            {
                fill_ways();
                fill = true;
            }

            PlotWay(GetBestWay_GeneticAlgoritm());
        }

        #region Random Way
        private int[] GetBestWay()
        {
            Random rnd = new Random();
            int[] way = new int[PointCount];

            for (int i = 0; i < PointCount; i++)
                way[i] = i;

            for (int s = 0; s < 2 * PointCount; s++)
            {
                int i1, i2, tmp;

                i1 = rnd.Next(PointCount);
                i2 = rnd.Next(PointCount);
                tmp = way[i1];
                way[i1] = way[i2];
                way[i2] = tmp;
            }

            return way;
        }

        #endregion

        #region Greedy
        private int[] GetBestWay_GreedyAlgo()
        {

            EllipseArray[finish].Fill = Brushes.LightBlue;
            EllipseArray[second_elem].Fill = Brushes.LightBlue;
            EllipseArray[after_last_elem].Fill = Brushes.LightBlue;

            Random rnd = new Random();

            int[] way = new int[PointCount];



            for (int i = 0; i < PointCount; i++)
            {
                way[i] = -1;
            }

            int first_city;

            int X_FC;
            int Y_FC;

            int Index_City = 0;

            float min_Length;

            double summ = 0;

            for (int j = 0; j < PointCount; j++)
            {
                min_Length = int.MaxValue;

                if (j == 0)
                {
                    first_city = rnd.Next(PointCount);
                    finish = first_city;
                    EllipseArray[finish].Fill = Brushes.Red;
                }
                else
                {
                    first_city = Index_City;
                }
                if (j == PointCount - 1)
                {
                    way[j] = first_city;
                    EllipseArray[first_city].Fill = Brushes.Yellow;
                    after_last_elem = first_city;
                    break;
                }
                else
                {
                    way[j] = first_city;
                }



                X_FC = (int)pC[first_city].X;
                Y_FC = (int)pC[first_city].Y;

                List<double> length = new List<double>();

                for (int i = 0; i < PointCount; i++)
                {
                    if (!way.Contains(i))
                    {
                        float l = (float)Math.Sqrt(Math.Pow(pC[i].X - X_FC, 2) + Math.Pow(pC[i].Y - Y_FC, 2));
                        length.Add(l);
                        if (l < min_Length)
                            min_Length = l;
                    }
                    else
                    {
                        length.Add(0);
                    }
                }

                summ += min_Length;

                Index_City = length.IndexOf(min_Length);

                if (j == 0)
                {
                    EllipseArray[Index_City].Fill = Brushes.Green;
                    second_elem = Index_City;
                }
            }



            return way;
        }
        #endregion

        #region Genetic Algoritm

        static int Count_Population = (int)Math.Floor(Math.Sqrt(PointCount) * 2);
        int[,] Ways = new int[2 * Count_Population, PointCount];
        Random rnd = new Random();

        private void fill_ways()
        {
            for (int i = 0; i < Count_Population; i++)
            {


                int[] perm = Enumerable.Range(0, PointCount).ToArray();

                for (int k = PointCount - 1; k >= 1; k--)
                {
                    int j = rnd.Next(k + 1);

                    int temp = perm[j];
                    perm[j] = perm[k];
                    perm[k] = temp;
                }
                for (int j = 0; j < PointCount; j++)
                {
                    Ways[i, j] = perm[j];
                }
            }
        }

        private int[] GetBestWay_GeneticAlgoritm()
        {
            for (int j = 0; j < Count_Population; j++)
            {
                int Father = rnd.Next(Count_Population);
                int Mother = rnd.Next(Count_Population);

                while (Mother == Father)
                    Mother = rnd.Next(Count_Population);

                int[] Array_Father = new int[PointCount];
                int[] Array_Mother = new int[PointCount];

                for (int i = 0; i < PointCount; i++)
                {
                    Array_Father[i] = Ways[Father, i];
                    Array_Mother[i] = Ways[Mother, i];
                }

                int Cross_Point = rnd.Next(2, PointCount - 1);


                int[] Child_1 = new int[PointCount];
                int[] Child_2 = new int[PointCount];

                for (int i = 0; i < PointCount; i++)
                {
                    Child_1[i] = -1;
                    Child_2[i] = -1;
                }

                int count = 0;

                if (rnd.NextDouble() > 0.5)
                {
                    for (int i = 0; i < Cross_Point; i++)
                    {
                        Child_1[i] = Array_Father[i];
                    }
                    for (int k = Cross_Point; k < PointCount; k++)
                    {
                        if (!Child_1.Contains(Array_Mother[count]))
                        {
                            Child_1[k] = Array_Mother[count];
                            count++;
                        }
                        else
                        {
                            k--;
                            count++;
                        }
                    }

                    for (int i = 0; i < PointCount; i++)
                    {
                        Ways[j + Count_Population, i] = Child_1[i];
                    }
                }
                else
                {
                    for (int i = 0; i < Cross_Point; i++)
                    {
                        Child_2[i] = Array_Mother[i];
                    }
                    for (int k = Cross_Point; k < PointCount; k++)
                    {
                        if (!Child_2.Contains(Array_Father[count]))
                        {
                            Child_2[k] = Array_Father[count];
                            count++;
                        }
                        else
                        {
                            k--;
                            count++;
                        }
                    }

                    for (int i = 0; i < PointCount; i++)
                    {
                        Ways[j + Count_Population, i] = Child_2[i];
                    }
                }

                if (rnd.NextDouble() < 0.7)
                {
                    int index_1 = rnd.Next(PointCount);
                    int index_2 = rnd.Next(PointCount);

                    while (index_2 == index_1 || Math.Abs(index_1 - index_2) == 1)
                        index_2 = rnd.Next(PointCount);

                    int[] buffer_arr = new int[Math.Abs(index_1 - index_2)];

                    int count_for_ba = 0;

                    if (index_1 > index_2)
                    {
                        int temp = index_1;
                        index_1 = index_2;
                        index_2 = temp;
                    }

                    for (int i = index_1; i < index_2; i++)
                    {
                        buffer_arr[count_for_ba] = Ways[j + Count_Population, i];
                        count_for_ba++;
                    }

                    Array.Reverse(buffer_arr);

                    count_for_ba = 0;

                    for (int i = index_1; i < index_2; i++)
                    {
                        Ways[j + Count_Population, i] = buffer_arr[count_for_ba];
                        count_for_ba++;
                    }
                }

            }



            double[] Distants = new double[2 * Count_Population];

            for (int i = 0; i < 2 * Count_Population; i++)
            {
                Distants[i] = GetLength(i, Ways);
            }

            double[] copy_Distants = new double[2 * Count_Population];

            Array.Copy(Distants, copy_Distants, 2 * Count_Population);

            Array.Sort(copy_Distants);

            int TheBestWay = Array.IndexOf(Distants, copy_Distants[0]);

            int[] The_Best_Way = new int[PointCount];

            int[,] Ways_copy = new int[2 * Count_Population, PointCount];

            for (int i = 0; i < PointCount; i++)
            {
                The_Best_Way[i] = Ways[TheBestWay, i];
            }

            for (int i = 0; i < 2 * Count_Population; i++)
            {
                for (int j = 0; j < PointCount; j++)
                {
                    Ways_copy[i, j] = Ways[i, j];
                }
            }
            for (int i = 0; i < Count_Population; i++)
            {
                int BestWay = Array.IndexOf(Distants, copy_Distants[i]);

                Distants[BestWay] = 0;

                int[] temp = new int[PointCount];

                for (int j = 0; j < PointCount; j++)
                {
                    temp[j] = Ways[i, j];
                }

                for (int j = 0; j < PointCount; j++)
                {
                    Ways[i, j] = Ways_copy[BestWay, j];
                    if (BestWay > i)
                        Ways[BestWay, j] = temp[j];
                }
            }

            Label_Length.Content = copy_Distants[0].ToString();

            return The_Best_Way;
        }

        private double GetLength(int i, int[,] ways)
        {
            double summ = 0;

            for (int j = 1; j < PointCount; j++)
            {
                summ += Math.Sqrt(Math.Pow(pC[ways[i, j]].X - pC[ways[i, j - 1]].X, 2) + Math.Pow(pC[ways[i, j]].Y - pC[ways[i, j - 1]].Y, 2));
            }

            summ += Math.Sqrt(Math.Pow(pC[ways[i, PointCount - 1]].X - pC[ways[i, 0]].X, 2) + Math.Pow(pC[ways[i, PointCount - 1]].Y - pC[ways[i, 0]].Y, 2));

            return summ;
        }

        #endregion
    }
}
