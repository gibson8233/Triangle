using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1210 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        int floor = 12;
        int[,] number2DArray;

        private void Form1_Load(object sender, EventArgs e) {
            number2DArray = new int[floor, floor * 2];
            setupArray();
            triangleNumberPart();
            showTriangleInListBox();
        }
        void setupArray() {
            for (int y = 0; y < floor; y++) {
                for (int x = 0; x < floor * 2; x++) {
                    number2DArray[y, x] = 0;
                }
            }

            number2DArray[0, floor * 2 / 2] = 1;
        }
        void triangleNumberPart() {
            for (int y = 1; y < floor; y++) {
                for (int x = 0; x < floor * 2 - 1; x++) {
                    number2DArray[y, x] = number2DArray[y - 1, x + 1] + number2DArray[y - 1, x];
                }
            }
        }
        void showTriangleInListBox() {
            string CurrLineString = "";
            for (int y = 0; y < floor; y++) {
                if (y % 2 == 1) {
                    CurrLineString += " ";
                }
                for (int x = 0; x < floor * 2; x++) {

                    if (number2DArray[y, x] == 0) {
                        CurrLineString += "  ";
                    }
                    else {
                        if (y % 2 != 1) {
                            CurrLineString += number2DArray[y, x] + "  ";
                        }
                        else {
                            CurrLineString += number2DArray[y, x] + " ";
                        }
                    }

                }
                listBox1.Items.Add(CurrLineString);
                CurrLineString = "";
            }
        }
    }
}
