using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Joc : Form
    {
        public Joc()
        {
            InitializeComponent();
        }

        int[][] a;
        int x0, y0;//folosite pentru a memora pozitia campului liber
        void joc_nou()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    a[i][j] = i * 3 + j;
            x0 = 0;
            y0 = 0;
            Random r = new Random();
            int x1, y1, x2, y2, temp;
            for (int i = 0; i < 10; i++)
            {
                x1 = r.Next() % 3;
                y1 = r.Next() % 3;
                x2 = r.Next() % 3;
                y2 = r.Next() % 3;
                temp = a[x1][y1];
                a[x1][y1] = a[x2][y2];
                a[x2][y2] = temp;
                if (a[x1][y1] == 0)
                {
                    x0 = x1;
                    y0 = y1;
                }
                else if (a[x2][y2] == 0)
                {
                    x0 = x2;
                    y0 = y2;
                }
            }
            scrie();
        }
        

void scrie_buton(Button b, int nr)
        {
            if (nr > 0)
            {
                b.BackColor = Color.Blue;
                b.ForeColor = Color.Yellow;
                b.Text = nr.ToString();
            }
            else
            {
                b.BackColor = Color.Red;
                b.ForeColor = Color.Red;
                b.Text = "";
            }
        }
        void scrie()
        {
            scrie_buton(button1, a[0][0]);
            scrie_buton(button2, a[0][1]);
            scrie_buton(button3, a[0][2]);
            scrie_buton(button4, a[1][0]);
            scrie_buton(button5, a[1][1]);
            scrie_buton(button6, a[1][2]);
            scrie_buton(button7, a[2][0]);
            scrie_buton(button8, a[2][1]);
            scrie_buton(button9, a[2][2]);
        }
        void muta(int x, int y)
        {
            if (x < 0 || x > 2) return;
            if (y < 0 || y > 2) return;
            if ((y == y0 && Math.Abs(x - x0) == 1) || (x == x0 && Math.Abs(y - y0) == 1))
            {
                int temp = a[x][y];
                a[x][y] = 0;
                a[x0][y0] = temp;
                x0 = x;
                y0 = y;
                scrie();
                if (joc_terminat())
                {
                    MessageBox.Show("Felicitari!!!");
                }
            }
        }
        bool joc_terminat()
        {
            for (int i = 0; i < 8; i++)
                if (a[i / 3][i % 3] != i + 1) return false;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            muta(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            muta(0, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            muta(0, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            muta(1, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            muta(1, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            muta(1, 2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            muta(2, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            muta(2, 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            muta(2, 2);
        }

        private void Joc_Load(object sender, EventArgs e)
        {
            a = new int[3][];
            for
           (int i = 0; i < 3; i++)

            {
                a[i] = new int[3];

            }
            joc_nou();

        }
    }
}
