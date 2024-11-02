using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Matrix3x3Library
{
    public class Matrix : IMatrix
    {
        public int[,] Elements {
            get;
            set;
        }

        public Matrix() 
        {
            Elements = new int[3, 3];
            for (int i = 0; i < 3; i++)
            { 
                for(int j = 0; j < 3; j++)
                {
                    Elements[i, j] = i + j;
                }
            
            }
        }
        
        public Matrix(int[,] elements)
        {
            Elements = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Elements[i, j] = elements[i, j];
                }

            }
        }
        public int this[int row, int col]
        {
            get => Elements[row, col];
            set => Elements[row, col] = value;
        }
        public Matrix(Matrix m) 
        {
            Elements = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Elements[i, j] = m.Elements[i, j];
                }

            }
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix m = new Matrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m.Elements[i, j] = m1.Elements[i, j] + m2.Elements[i, j];
                }
            }
            return m;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix m = new Matrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m.Elements[i, j] = m1.Elements[i, 0] * m2.Elements[0, j] + m1.Elements[i, 1] * m2.Elements[1, j]
                        + m1.Elements[i, 2] * m2.Elements[2, j];
                }
            }
            return m;
        }
        public static Matrix operator *(Matrix m, int integer)
        {
            Matrix m1 = new Matrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m1.Elements[i, j] = m.Elements[i, j] * integer;
                }
            }
            return m1;
        }
        public static Matrix operator *(int integer, Matrix m)
        {
            Matrix m1 = new Matrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m1.Elements[i, j] = m.Elements[i, j] * integer;
                }
            }
            return m1;
        }
        public static int operator ~(Matrix m)
        {
            return m.Elements[0, 0] * m.Elements[1, 1] * m.Elements[2, 2]
                + m.Elements[0, 1] * m.Elements[1, 2] * m.Elements[2, 0]
                + m.Elements[1, 0] * m.Elements[2, 1] * m.Elements[0, 2]
                - m.Elements[2, 0] * m.Elements[1, 1] * m.Elements[0, 2]
                - m.Elements[1, 0] * m.Elements[0, 1] * m.Elements[2, 2]
                - m.Elements[0, 0] * m.Elements[2, 1] * m.Elements[1, 2];
        }
        public static Matrix operator !(Matrix m)
        {
            Matrix m1 = new Matrix(m);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i >= j)
                    {
                        int temp = m1.Elements[i, j];
                        m1.Elements[i, j] = m1.Elements[j, i];
                        m1.Elements[j, i] = temp;
                    }
                }
            }
            return m1;
        }
        public static bool operator ==(Matrix m1, Matrix m2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (m1.Elements[i, j] != m2.Elements[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (m1.Elements[i, j] != m2.Elements[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator true(Matrix m)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (m.Elements[i, j] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator false(Matrix m)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (m.Elements[i, j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public override string ToString()
        {
            string str = "Matrix with elements: \n";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    str += Elements[i, j] + "\t";
                }
                str += "\n";
            }
            return str;
        }
    }
}


