﻿using System;
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
using BIZ;

namespace GUI.Usercontrols
{
    /// <summary>
    /// Interaction logic for UserControlOrderMeat.xaml
    /// </summary>
    public partial class UserControlOrderMeat : UserControl
    {
        Grid leftGrid;
        Grid rightGrid;
        ClassBiz BIZ;

        public UserControlOrderMeat(ClassBiz inBiz, Grid inLeftGrid, Grid inRightGrid)
        {
            InitializeComponent();

            BIZ = inBiz;

            MainGrid.DataContext = BIZ;
            leftGrid = inLeftGrid;
            rightGrid = inRightGrid;
        }
    }
}
