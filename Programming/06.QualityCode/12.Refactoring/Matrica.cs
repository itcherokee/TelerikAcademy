using System;

namespace Task3
{
    class WalkInMatrica
    {
        static void Change(ref int deltaX, ref int deltaY)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;
            for (int counter = 0; counter < 8; counter++)
            {
                if (dirX[counter] == deltaX && dirY[counter] == deltaY)
                {
                    cd = counter; 
                    break;
                }
            }
            if (cd == 7)
            {
                deltaX = dirX[0]; 
                deltaY = dirY[0]; 
                return; 
            }
            deltaX = dirX[cd + 1];
            deltaY = dirY[cd + 1];
        }

        static bool Check(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }
                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void FindCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0) 
                    {
                        x = i; 
                        y = j; 
                        return; 
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //Console.WriteLine( "Enter a positive number " );
            //string input = Console.ReadLine(  );
            //int n = 0;
            //while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            //{
            //    Console.WriteLine( "You haven't entered a correct positive number" );
            //    input = Console.ReadLine(  );
            //}

            int n = 7;
            int[,] matrix = new int[n, n];
            int  k = 1, currentX = 0, currentY = 0, dx = 1, dy = 1; // 'k' may e counter na broya minavaniya

            while (true)
            { //malko e kofti tova uslovie, no break-a raboti 100% : )
                matrix[currentX, currentY] = k;
 
                if (!Check(matrix, currentX, currentY))
                {
                    // prekusvame ako sme se zadunili
                    break; 
                }

                if (currentX + dx >= n || currentX + dx < 0 || currentY + dy >= n || currentY + dy < 0 || matrix[currentX + dx, currentY + dy] != 0)
                {
                    while ((currentX + dx >= n || currentX + dx < 0 || currentY + dy >= n || currentY + dy < 0 || matrix[currentX + dx, currentY + dy] != 0))
                    {
                        Change(ref dx, ref dy); 
                    }
                }

                currentX += dx; 
                currentY += dy; 
                k++;
            }

            for (int p = 0; p < n; p++)
            {
                for (int q = 0; q < n; q++)
                {
                    Console.Write("{0,3}", matrix[p, q]);
                }

                Console.WriteLine();
            }

            FindCell(matrix, out currentX, out currentY);
            if (currentX != 0 && currentY != 0)
            { // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                dx = 1;
                dy = 1;
                while (true)
                { //malko e kofti tova uslovie, no break-a raboti 100% : )
                    matrix[currentX, currentY] = k;
                    if (!Check(matrix, currentX, currentY))
                    {
                        // prekusvame ako sme se zadunili
                        break;
                    }

                    if (currentX + dx >= n || currentX + dx < 0 || currentY + dy >= n || currentY + dy < 0 || matrix[currentX + dx, currentY + dy] != 0)
                    {
                        while ((currentX + dx >= n || currentX + dx < 0 || currentY + dy >= n || currentY + dy < 0 || matrix[currentX + dx, currentY + dy] != 0)) 
                        {
                            Change(ref dx, ref dy); 
                        }
                    }
                    currentX += dx; 
                    currentY += dy; 
                    k++;
                }
            }

            for (int pp = 0; pp < n; pp++)
            {
                for (int qq = 0; qq < n; qq++)
                {
                    Console.Write("{0,3}", matrix[pp, qq]);
                }

                Console.WriteLine();
            }
        }
    }
}
