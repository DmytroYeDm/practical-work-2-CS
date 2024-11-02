using Matrix3x3Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MatrixTests
{
    [TestClass()]
    public class MatrixTest
    {
        [TestMethod()]
        public void MatrixSet_SetElementsOfMatrix_ReturnsMatrixWithRightElements()
        {
            //Arrange
            Matrix matrix = new Matrix();
            int[,] mas = { {0, 1, 2 }, {1, 2, 3 }, {2, 3, 4 } };
            Matrix expected = new Matrix(mas);

            //Act & Assert
            for (int i = 0; i < 3; i++)
            { 
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(expected[i, j], matrix[i, j]);
                }
            }
        }

        [TestMethod()]
        public void MatrixPlusOperator_AddingTwoMatrixes_ReturnsMatrixWithRightElements()
        {
            //Arrange
            Matrix m1 = new Matrix();
            int[,] mas = { { 15, 4, 22 }, { 11, 66, 3 }, { 31, 31, 41 } };
            Matrix m2 = new Matrix(mas);
            Matrix expected = new Matrix(new int[,] { {15, 5, 24 }, {12, 68, 6 }, {33, 34, 45 } });
            Matrix actual = new Matrix();

            //Act
            actual = m1 + m2;

            //Assert
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }

        [TestMethod()]
        public void MatrixMultiplicationOperator_MultiplyingTwoMatrixes_ReturnsMatrixWithRightElements()
        {
            //Arrange
            Matrix m1 = new Matrix();
            int[,] mas = { { 15, 4, 22 }, { 11, 66, 3 }, { 31, 31, 41 } };
            Matrix m2 = new Matrix(mas);
            Matrix expected = new Matrix(new int[,] { { 73, 128, 85 }, { 130, 229, 151 }, { 187, 330, 217 } });
            Matrix actual = new Matrix();

            //Act
            actual = m1 * m2;

            //Assert
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }

        [TestMethod()]
        public void MatrixMultiplicationOperator_MultiplyingIntegerAndMatrix_ReturnsMatrixWithRightElements()
        {
            //Arrange
            const int INTEGER = 5;
            int[,] mas = { { 15, 4, 22 }, { 11, 66, 3 }, { 31, 31, 41 } };
            Matrix m = new Matrix(mas);
            Matrix expected = new Matrix(new int[,] { { 75, 20, 110 }, { 55, 330, 15 }, { 155, 155, 205 } });
            Matrix actual = new Matrix();

            //Act
            actual = m * INTEGER;

            //Assert
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
            
        }

        [TestMethod()]
        public void MatrixMultiplicationOperator_MultiplyingIntegerAndMatrixButIntegerComesFirst_ReturnsMatrixWithRightElements()
        {
            //Arrange
            const int INTEGER = 5;
            int[,] mas = { { 15, 4, 22 }, { 11, 66, 3 }, { 31, 31, 41 } };
            Matrix m = new Matrix(mas);
            Matrix expected = new Matrix(new int[,] { { 75, 20, 110 }, { 55, 330, 15 }, { 155, 155, 205 } });
            Matrix actual = new Matrix();

            //Act
            actual = INTEGER * m;

            //Assert
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }

        }

        [TestMethod()]
        public void Determinant_CalculatingDeterminantOfTheMatrix_ReturnsInteger()
        {
            //Arrange
            Matrix m = new Matrix(new int[,] { { 17, 1, 5 }, { 1, 1, 1 }, { 9, 10, 7 } });
            int expected = -44;

            //Act
            int actual = ~m;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MatrixTranspanation_ObtainingTransparentMatrix_ReturnsMatrix()
        {
            //Arrange
            Matrix m = new Matrix(new int[,] { {14, 188, 1 }, {1, 7, 98 }, {33, 56, 4 } });
            Matrix expected = new Matrix(new int[,] { { 14, 1, 33 }, { 188, 7, 56 }, { 1, 98, 4 } });
            Matrix actual = new Matrix();

            //Act
            actual = !m;

            //Assert
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }

        [TestMethod()]
        public void MatrixEquality_ChecksTheEqualityOfTwoMatrixes_ReturnsBoolean()
        {
            //Arrange
            Matrix m1 = new Matrix(new int[,] { { 14, 188, 1 }, { 1, 7, 98 }, { 33, 56, 4 } });
            Matrix m2 = new Matrix(new int[,] { { 14, 188, 1 }, { 1, 7, 98 }, { 33, 56, 4 } });

            //Act & Assert
            Assert.IsTrue(m1 == m2);
        }

        [TestMethod()]
        public void MatrixUnequality_ChecksTheUnequalityOfTwoMatrixes_ReturnsBoolean()
        {
            //Arrange
            Matrix m1 = new Matrix(new int[,] { { 17, 1, 5 }, { 1, 1, 1 }, { 9, 10, 7 } });
            Matrix m2 = new Matrix(new int[,] { { 17, 1, 5 }, { 1, 1, 1 }, { 9, 10, 8 } });

            //Act & Assert
            Assert.IsTrue(m1 != m2);
        }

        [TestMethod()]
        public void MatrixTrue_ChecksIfMatrixIsTrue_ReturnsBoolean()
        {
            //Arrange
            Matrix m = new Matrix(new int[,] { { 17, 1, 5 }, { 1, 1, 1 }, { 9, 10, 7 } });
            
            //Act & Assert
            bool isTrue = m ? true : false;
            Assert.IsTrue(isTrue);
        }

        [TestMethod()]
        public void MatrixFalse_ChecksIfMatrixIsFalse_ReturnsBoolean()
        {
            //Arrange
            Matrix m = new Matrix(new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } });

            //Act & Assert
            bool isFalse = m ? true : false;
            Assert.IsFalse(isFalse);
        }

        [TestMethod()]
        public void ToStringTest_ConvertMatrixToString_ReturnsString()
        {
            //Arrange
            Matrix m = new Matrix(new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } });
            string expected = "Matrix with elements: \n";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    expected += m.Elements[i, j] + "\t";
                }
                expected += "\n";
            }

            //Act
            string actual = m.ToString();

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
    
}


