using System;

namespace ConsoleApp3
{
    class Matrix
    {
        private int[,] data;
        private int rowNumber, columnNubmer;

        public Matrix(int rowNumber, int columnNumer)
        {
            data = new int[rowNumber, columnNumer];
            this.rowNumber = rowNumber;
            this.columnNubmer = columnNumer;
        }

        public void SetElement(int row, int column, int number)
        {
            if (row <= this.rowNumber && column <= this.columnNubmer)
            {
                this.data[row, column] = number;
            }
        }

        public int GetElement(int row, int column)
        {
            if (row <= this.rowNumber && column <= this.columnNubmer)
            {
                return this.data[row, column];
            }
            else
            {
                return 0;
            }
        }

        public void SetData()
        {
            Console.WriteLine("Enter " + (this.rowNumber + " line of " + this.columnNubmer) + " numbers, seperated by space, and press Enter after each line");
            for (int i = 0; i < this.rowNumber; i++)
            {
                String columnDataStr = Console.ReadLine();
                String[] columnDataArr = columnDataStr.Split(' ');
                for (int j = 0; j < this.columnNubmer; j++)
                {
                    try
                    {
                        this.data[i, j] = int.Parse(columnDataArr[j]);
                    }
                    catch (Exception)
                    {
                        this.data[i, j] = 0;
                    }
                }
            }
        }

        public static Matrix GetSubMatrix(Matrix m, int row1, int column1, int row2, int column2)
        {
            if (row1 > m.rowNumber || column1 > m.columnNubmer ||
                row2 > m.rowNumber || column2 > m.columnNubmer ||
                row1 > row2 || column1 > column2)
            {
                return null;
            }
            else
            {
                Matrix result = new Matrix(row2 - row1 + 1, column2 - column1 + 1);
                for (int i = row1; i <= row2; i++)
                {
                    for (int j = column1; j <= column2; j++)
                    {
                        result.data[i - row1, j - column1] = m.data[i, j];
                    }
                }
                return result;
            }
        }

        public Matrix GetSubMatrix(int row1, int column1, int row2, int column2)
        {
            return Matrix.GetSubMatrix(this, row1, column1, row2, column2);
        }

        public static int[] GetRow(Matrix m, int nth)
        {
            if (nth > m.rowNumber)
            {
                return null;
            }
            else
            {
                int[] result = new int[m.columnNubmer];
                for (int i = 0; i < m.columnNubmer; i++)
                {
                    result[i] = m.data[nth - 1, i];
                }
                return result;
            }
        }

        public int[] GetRow(int nth)
        {
            return Matrix.GetRow(this, nth);
        }

        public static int[] GetColumn(Matrix m, int nth)
        {
            if (nth > m.columnNubmer)
            {
                return null;
            }
            else
            {
                int[] result = new int[m.rowNumber];
                for (int i = 0; i < m.rowNumber; i++)
                {
                    result[i] = m.data[i, nth - 1];
                }
                return result;
            }
        }

        public int[] GetColumn(int nth)
        {
            return Matrix.GetColumn(this, nth);
        }

        public static int InnerProduct(int[] a, int[] b)
        {
            if (a.Length != b.Length)
            {
                return 0;
            }
            else
            {
                int result = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    result += a[i] * b[i];
                }
                return result;
            }
        }

        public static Matrix Transpose(Matrix m)
        {
            Matrix result = new Matrix(m.columnNubmer, m.rowNumber);
            for (int i = 0; i < result.rowNumber; i++)
            {
                for (int j = 0; j < result.columnNubmer; j++)
                {
                    result.data[i, j] = m.data[j, i];
                }
            }
            return result;
        }

        public Matrix Transpose()
        {
            return Matrix.Transpose(this);
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.columnNubmer != b.rowNumber)
                return null;
            else
            {
                Matrix c = new Matrix(a.rowNumber, b.columnNubmer);
                for (int i = 0; i < c.rowNumber; i++)
                {
                    for (int j = 0; j < c.columnNubmer; j++)
                    {
                        c.data[i, j] = Matrix.InnerProduct(Matrix.GetRow(a, i + 1), Matrix.GetColumn(b, j + 1));
                    }
                }
                return c;
            }
        }

        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i < this.rowNumber; i++)
            {
                for (int j = 0; j < this.columnNubmer; j++)
                {
                    temp += this.data[i, j] + " ";
                }
                temp += "\n";
            }
            return temp;
        }
    }
}