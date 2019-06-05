using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minor_determinant

{
    class Matrix
    {
        protected int[,] M ;
        protected int n;
        public Matrix()
        {
            M = new int[1, 1];
            n = 1;
        }
        public Matrix(int[,] data, int data_size)
        {
            M = data;
            n = data_size;
        }
        public int [,] getM()
        {
            return M;
        }
        public int size()
        {
            return n;
        }
        public virtual int getByInd(int i,int j)
        {
                return M[i,j];
        }

        public int Determinant(int h)
        {
            h = h + 1;
            int det = 0;
            if (n == 2) det = getByInd(0,0)* getByInd(1, 1) - getByInd(0, 1)* getByInd(1, 0);
            else
                for (int k = 0; k < n; k ++)
                {
                    Minor baby = new Minor(this, 0, k);
                   // Console.Write(k +") " + getByInd(0, k) + "\n" );
                    baby.consolePrint();
                    int lildet = baby.Determinant(h);
                    Console.Write(h + "." + k +")\n");
                    Console.Write(lildet + " det \n");
                    Console.Write(getByInd(0, k) + " koef \n");
                    Console.Write(Math.Pow(-1, k) + " pow-1 \n");
                    det = det + (int)Math.Pow(-1, k)* lildet * getByInd(0, k);
      
                }
            return det;
        }

        public virtual void consolePrint()
        {
            for (int i = 0; i< n; i ++ )
            {
                for (int j =0; j < n; j++)
                {
                    Console.Write(getByInd(i,j) + " ");
                }
                Console.WriteLine();
            }
        }

    }

    class Minor : Matrix
    {
        private int line;
        private int column;
        public Minor (Matrix Mother, int i, int j)
        {
            this.M = Mother.getM();
            this.n = Mother.size() - 1;
            line = i;
            column = j;
        }
        public override int getByInd(int i, int j)
        {
            int a, b;
            if (i < line)
                a = i;
            else a = i + 1;
            if (j < column)
                b = j;
            else b = j + 1;
            return M[a, b];
        }
    } 

    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[,] a = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = i*2+1*j;
                }
            }

            Matrix MyMatrix = new Matrix(a, n);
            MyMatrix.consolePrint();
            int h = 0;
            Console.Write(MyMatrix.Determinant(h));
            Console.ReadKey();
        }
    }
}
