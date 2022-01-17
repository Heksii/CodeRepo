using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfIntro.BIZ
{
    class ClassBIZ
    {
        Random rng = new Random();

        public ClassBIZ()
        {
        }

        private void ClearList(ListBox listBox)
        {
            listBox.ItemsSource = null;

            listBox.Items.Clear();
        }

        public void delOpg12(ListBox listBox)
        {
            ClearList(listBox);

            for (int number = 4711; number <= 4736; number++)
            {
                listBox.Items.Add(number.ToString());
            }
        }

        public void delOpg13(ListBox listBox)
        {
            ClearList(listBox);

            for (int i = 0; i < 25; i++)
            {
                double number = Math.Round(rng.NextDouble() * 900000 + 100000);
                listBox.Items.Add(number.ToString());
            }
        }

        public void delOpg14(ListBox listBox)
        {
            ClearList(listBox);

            List<double> nList = new List<double>();


            for (int i = 0; i < 25; i++)
            {
                double number = Math.Round(rng.NextDouble() * 900000 + 100000);
                nList.Add(number);
            }

            nList.Sort();

            foreach(double n in nList)
            {
                listBox.Items.Add(n);
            }
        }

        public void delOpg15(ListBox listBox)
        {
            ClearList(listBox);

            List<double> nList1 = new List<double>();
            List<double> nList2 = new List<double>();

            for (int i = 0; i < 25; i++)
            {
                double number = Math.Round(rng.NextDouble() * 900000 + 100000);
                nList1.Add(number);
                nList2.Add(number);
            }

            nList1.Sort();

            for (int i = 0; i < nList1.Count; i++)
            {
                listBox.Items.Add($"{nList1[i]} - {nList2[i]}");
            }
        }

        public void delOpg16(ListBox listBox)
        {
            ClearList(listBox);

            List<double> nList = new List<double>();
            double sum = 0;

            for (int i = 0; i < 25; i++)
            {
                double number = Math.Round(rng.NextDouble() * 900000 + 100000);
                nList.Add(number);
                listBox.Items.Add(number);
                sum += number;
            }

            for (int i = 0; i < nList.Count; i++)
            {
                listBox.Items.Add($"{nList[i]}");
            }

            listBox.Items.Add("---------------------");
            listBox.Items.Add($"Gennemsnit: {sum/25}");
        }

        public void delOpg17(ListBox listBox)
        {
            ClearList(listBox);

            List<double> nList = new List<double>();
            double sum = 0;

            for (int i = 0; i < 25; i++)
            {
                double number = Math.Round(rng.NextDouble() * 900000 + 100000);
                nList.Add(number);
                
                sum += number;
            }

            double avg = sum / 25;

            for (int i = 0; i < nList.Count; i++)
            {
                listBox.Items.Add($"{nList[i]} - {avg} = {nList[i] - avg}");
            }
        }

        public List<string> delOpg18()
        {
            List<double> nList = new List<double>();
            List<string> output = new List<string>();

            double avg = 0;
            double sum = 0;

            for (int i = 0; i <25; i++)
            {
                double rand = rng.Next() * 900000 + 100000;
                nList.Add(rand);

                sum += rand;
            }

            avg = sum / nList.Count;

            foreach (double num in nList)
            {
                output.Add($"{num} + {avg} = {num + avg}");
            }

            return output;
        }

        public void delOpg19(ListBox listBox)
        {
            ClearList(listBox);

            List<int> nList = new List<int>();
            int sum = 0;
            int avg;

            for (int i = 0; i < 25; i++)
            {
                int n = rng.Next(100000, 1000000);
                nList.Add(n);
                sum += n;
            }

            avg = sum / nList.Count;

            nList.Sort();

            foreach(int n in nList)
            {
                ListBoxItem item = new ListBoxItem();

                if (n % 2 == 0)
                {
                    item.Background = Brushes.AliceBlue;
                }
                else
                {
                    item.Background = Brushes.HotPink;
                }

                item.Content = $"{n} - {avg} = {n - avg}";
                listBox.Items.Add(item);
            }
        }

        public List<ListBoxItem> delOpg110()
        {
            List<ListBoxItem> output = new List<ListBoxItem>();
            List<int> nList = new List<int>();
            int sum = 0;
            int avg;

            for (int i = 0; i < 25; i++)
            {
                int n = rng.Next(100000, 1000000);
                nList.Add(n);
                sum += n;
            }

            avg = sum / nList.Count;

            nList.Sort();

            foreach (int n in nList)
            {
                ListBoxItem item = new ListBoxItem();

                if (n % 2 == 0)
                {
                    item.Background = Brushes.AliceBlue;
                }
                else
                {
                    item.Background = Brushes.HotPink;
                }

                item.Content = $"{n} - {avg} = {n - avg}";
                output.Add(item);
            }

            return output;
        }
    }
}
