using Matrica;

Matrix m1 = new Matrix(2, 2, Matrix.Filltype.Random);
Matrix m2 = new Matrix(2, 2, Matrix.Filltype.Random);
Matrix m3 = new Matrix(2, 3, Matrix.Filltype.Random);

Console.WriteLine(m1);
Console.WriteLine(m2);
Console.WriteLine(m3);

m1[0, 0] = 10;

Console.WriteLine(m1.GetValue(0, 0));
Console.WriteLine(m2++);


//Console.WriteLine(m2!=m1);
//Console.WriteLine(m1 <= m2);

//try
//{
//    m1.Add(m3);
//    Console.WriteLine(m1);
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.Message);
//}