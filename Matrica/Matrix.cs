using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Matrica
{
    class Matrix
    {
        public enum Filltype
        {
            Zerro,
            Random
        }

        private double[,] matrix;
        private Random rnd;

        #region Constructors

        public Matrix(int rows, int cols, Filltype filltype)
        {
            matrix = new double[rows, cols];
            switch (filltype)
            {
                case Filltype.Zerro:
                    ClearMatrix();
                    break;
                case Filltype.Random:
                    FillRandomValue(-10, 10);
                    break;
            }

        }



        public Matrix(double[,] matrix)
        {
            this.matrix = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = matrix[i, j];
                }
            }
        }
        public Matrix(Matrix m)
        {
            this.matrix = new double[m.Rows, m.Cols];

            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    this.matrix[i, j] = m.matrix[i, j];
                }
            }
        }
        #endregion

        #region SupportMetods
        public void FillRandomValue(int min, int max)
        {
            rnd = new Random();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    this.matrix[i, j] = rnd.Next(min, max);
                }
            }
        }

        private void ClearMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        public double GetValue(int i, int j)
        {
            if (i < 0 || i > Rows - 1 || j < 0 || j > Cols - 1)
            {
                throw new ArgumentOutOfRangeException("Out of range exeption");
            }

            return matrix[i, j];
        }

        public void SetValue(int i, int j, double value)
        {
            if (i < 0 || i > Rows - 1 || j < 0 || j > Cols - 1)
            {
                throw new ArgumentOutOfRangeException("Out of range exeption");
            }

            matrix[i, j] = value;
        }
        #endregion

        #region OverridMethods

        public override string ToString()
        {
            string outout = "";

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    outout += matrix[i, j].ToString().PadLeft(10);
                }
                outout += "\n";
            }

            return outout;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix mRes = new Matrix(m1);

            mRes.Add(m2);

            return mRes;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix mRes = new Matrix(m1);

            mRes.Subtraction(m2);

            return mRes;
        }

        public double this[int i, int j] 
        {
            set { this.SetValue(i, j, value); }
            get  { return this.GetValue(i, j); }
        }

        public static bool operator ==(Matrix m1, Matrix m2) => m1.CompareTo(m2) == 0;
        public static bool operator !=(Matrix m1, Matrix m2) => m1.CompareTo(m2) != 0;

        public static bool operator >(Matrix m1, Matrix m2) => m1.CompareTo(m2) == 1;

        public static bool operator <(Matrix m1, Matrix m2) => m1.CompareTo(m2) == -1;

        public static bool operator >=(Matrix m1, Matrix m2) => m1.CompareTo(m2) >= 0;

        public static bool operator <=(Matrix m1, Matrix m2) => m1.CompareTo(m2) <= 0;

        public static Matrix operator ++(Matrix m) 
        {
            for (int i = 0; i < m.Rows; i++) 
            {
                for (int j = 0; j < m.Cols; j++) 
                {
                    m.matrix[i, j]++;
                }
            }

            return m;
        }

        #endregion

        #region Props
        public double[,] GetMAtrix() => matrix;

        public int Rows => matrix.GetLength(0);

        public int Cols => matrix.GetLength(1);

        #endregion

        #region DefoltMEthods

        public Matrix Add(Matrix m)
        {
            if (this.Cols == m.Cols && this.Rows == m.Rows)
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        this.matrix[i, j] += m.matrix[i, j];
                    }
                }

                return this;
            }

            throw new Exception("Sizes are not equal");
        }
        public Matrix Subtraction(Matrix m)
        {
            if (this.Cols == m.Cols && this.Rows == m.Rows)
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        this.matrix[i, j] -= m.matrix[i, j];
                    }
                }

                return this;
            }

            throw new Exception("Sizes are not equal");
        }

        public int CompareTo(Matrix m)
        {
            if (this.Cols != m.Cols || this.Rows != m.Rows)
            {
                throw new Exception("Sizes are not equal");
            }
            else
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        if (this.matrix[i, j] < m.matrix[i, j])
                        {
                            return -1;
                        }
                        else if (this.matrix[i, j] > m.matrix[i, j])
                        {
                            return 1;
                        }
                    }
                }
                return 0;
            }
        }

        #endregion
    }
}
