﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_Winform_Programming_4
{
    public partial class Child : Form
    {
        public Child()
        {
            InitializeComponent();
        }
        public TextBox getTextBox() { return this.textBox; }
    }
}
