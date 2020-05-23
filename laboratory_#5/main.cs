using System;
using System.Linq;
using System.Text;

namespace backpack
{
    class MainClass
    {
        public static int[] Encrypte (string texttt)
        {
            int[] backpack = Backpack();
            string[] byted = InBytes(texttt);
            string[] full = Full(byted);
            int[] encrypted = new int[5];
            int sum;
            for (int i = 0; i < full.Length; i++)
            {
                Console.WriteLine(full[i]);
                sum = 0;
                int[] ia = full[i].Select(n => Convert.ToInt32(n)).ToArray();
                for (int j = 0; j < ia.Length; j++)
                    if (ia[j] == 49)
                    {
                        for (int n = 0; n < backpack.Length; n++)
                        {
                            if (j == n)
                            {
                                sum += backpack[n];
                                sum %= 65540;
                            }
                            encrypted[i] = sum;
                        }
                    }
                    
                }
            return encrypted;
        }
        
        public static byte[,] Decrypte (int[] back)
        {
            int[] backpack = new int[16];
            backpack[0] = 1;
            int sum = backpack[0];
            for (int i = 1; i < backpack.Length; i++)
            {
                backpack[i] = sum + 1;
                sum += backpack[i];
            }
            Console.WriteLine("");
            for(int i = 0; i < backpack.Length; i++)
            {
                Console.Write(backpack[i] + "   ");
            }
            byte[,] reverse = new byte[5,16];
            int check = 0;
            for (int i = 0; i < back.Length; i++)
            {
                check = back[i];
                for (int j = backpack.Length - 1; j >= 0; j--)
                {
                    if (check > backpack[j])
                    {
                        reverse[i, j] = 1;
                        check -= backpack[j];
                    } else if (check == backpack[j]) { reverse[i, j] = 1; break; }  
                   
                }
            }
            return reverse;
            
        }
        unsafe static void extended_euclid(int a, int b, int* x, int* y, int* d)
        {
            int q, r, x1, x2, y1, y2;

            if (b == 0)
            {

                *d = a; *x = 1; *y = 0;

                return;
            }

            x2 = 1; x1 = 0; y2 = 0; y1 = 1;

            while (b > 0)
            {

                q = a / b; r = a - q * b;

                *x = x2 - q * x1; *y = y2 - q * y1;

                a = b; b = r;

                x2 = x1; x1 = *x; y2 = y1; y1 = *y;

            }

            *d = a; *x = x2; *y = y2;

        }
        unsafe static int inverse(int a, int n)

        {

            int d, x, y;

            extended_euclid(a, n, &x, &y, &d);

            if (d == 1) return x;

            return 0;

        }
        public static string[] Full(string[] byted)
        {
            string[] full = new string[5];
            for (int i = 0; i < byted.Length; i++)
            {
                for (int j = 0; j < full.Length; j++)
                {
                    full[0] = byted[0] + byted[1];
                    full[1] = byted[2] + byted[3];
                    full[2] = byted[4] + byted[5];
                    full[3] = byted[6] + byted[7];
                    full[4] = byted[8] + byted[9];
                }

            }
            return full;
        }
        public static string[] InBytes(string text)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
            string[] BinaryCode = new string[10];
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                BinaryCode[i] = "0" + Convert.ToString(asciiBytes[i], 2);
            }
            return BinaryCode;
        }
        public static int[] Backpack()
        {
            int[] backpack = new int[16];
            backpack[0] = 1;

            int sum = backpack[0];
            for (int i = 1; i < backpack.Length; i++)
            {
                backpack[i] = sum + 1;
                sum += backpack[i];
            }
            for (int i = 0; i < backpack.Length; i++)
            {
               // Console.WriteLine(backpack[i]);
            }
            int modul = sum + 5;
            Console.WriteLine("Модуль = " + modul);
            int numb = 17;
            int[] new_backpack = new int[backpack.Length];
            for (int i = 0; i < new_backpack.Length; i++)
            {
                new_backpack[i] = (backpack[i] * numb) % modul;
                //Console.WriteLine(new_backpack[i]);
            }
            return new_backpack;
        }
        public static void Main(string[] args)
        {
            int[] backpack = Backpack();
            for (int i = 0; i < backpack.Length; i++)
            {
                Console.WriteLine(backpack[i]);
            }
            int inversed = inverse(17, 65540);
            if (inversed < 0) { inversed += 65540; }
            Console.WriteLine("Оберенене число за модулем = " + inversed);
            int[] result = new int[8];
            string texttt = "HELLOWORLD";
            int[] encrypted = Encrypte(texttt);
            int[] back = new int[5];
            for (int i = 0; i < encrypted.Length; i++)
            {
                Console.Write(encrypted[i] + "   ");
                back[i] = encrypted[i] * inversed;
                back[i] %= 65540;
                if (back[i] < 0) back[i] += 65540;
            }
            Console.WriteLine("");
            for(int i = 0; i < back.Length; i++)
            {
                Console.Write(back[i] + "   ");
            }
            byte[,] decrypted = new byte[5,16];
            decrypted = Decrypte(back);
            decrypted[3, 4] = 1;
            Console.WriteLine("");
            for (int i = 0; i < decrypted.GetLength(0); i++)
            {
                
                for(int j = 0; j <decrypted.GetLength(1);j++)
                {
                    Console.Write(decrypted[i,j] + "   ");
                    
                }
                Console.WriteLine("");
                
            }
            byte[] last = new byte[10]; 
            for(int n = 0; n < 5; n++)
            {
                string main = "";
                for (int j = 0; j < 8; j++)
                {
                    main += decrypted[n, j];
                    
                }
                Console.WriteLine(main);
                last[n * 2] = Convert.ToByte(Convert.ToInt32(main, 2));
            }
            int plus = 1;
            for (int n = 0; n < 5; n++)
            {
                string main = "";
                for (int j = 8; j < 16; j++)
                {
                    main += decrypted[n, j];

                }
                Console.WriteLine(main);
                
                last[n + plus] = Convert.ToByte(Convert.ToInt32(main, 2));
                plus++;
            }
            for (int i = 0; i < last.Length; i++)
            {
                Console.Write("**" + last[i]);
            }
            Console.WriteLine("");
            String decodedString = Encoding.ASCII.GetString(last);
            Console.WriteLine(decodedString);
        }
    }
}
