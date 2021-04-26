using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Hanoi
    {
        //Mueve el top de la primera pila dada a la segunda, si no se puede,
        //hace lo contrario: de la segunda a la primera.
        public void mover_disco(Pila a, Pila b)
        {
            if (a.Top > b.Top)
            {
                if (b.isEmpty())
                {
                    Disco d = a.pop();
                    b.push(d);
                }
                else
                {
                    Disco d = b.pop();
                    a.push(d);
                }

            }
            else if (a.Top < b.Top)
            {
                if (a.isEmpty())
                {
                    Disco d = b.pop();
                    a.push(d);
                }
                else
                {
                    Disco d = a.pop();
                    b.push(d);
                }
            }
        }

        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {
            int m = 0;

            if (n % 2 != 0)
            {
                while (fin.Size != n)
                {
                    mover_disco(ini, fin);
                    m++;
                    if (fin.Size == n) break;
                    redactar(n, ini, fin, aux, m);

                    mover_disco(ini, aux);
                    m++;
                    if (fin.Size == n) break;
                    redactar(n, ini, fin, aux, m);

                    mover_disco(aux, fin);
                    m++;
                    if (fin.Size == n) break;
                    redactar(n, ini, fin, aux, m);
                }
            }

            if (n % 2 == 0)
            {
                while (fin.Size != n)
                {
                    mover_disco(ini, aux);
                    m++;
                    redactar(n, ini, fin, aux, m);
                    if (fin.Size == n) break;

                    mover_disco(ini, fin);
                    m++;
                    redactar(n, ini, fin, aux, m);
                    if (fin.Size == n) break;

                    mover_disco(aux, fin);
                    m++;
                    redactar(n, ini, fin, aux, m);
                    if (fin.Size == n) break;
                }
            }

            redactar(n, ini, fin, aux, m);
            Console.WriteLine("El número total de discos es: " + fin.Size);
            Console.WriteLine("El número de total de movimientos es: " + m);
            return m;
        }

        public int recursivo(int n, Pila ini, Pila fin, Pila aux)
        {
            int m = 0;
            if (n == 1)
            {
                mover_disco(ini, fin);
                m++;
            }
            else
            {
                m += recursivo(n - 1, ini, aux, fin);
                mover_disco(ini, fin);
                m++;
                m += recursivo(n - 1, aux, fin, ini);
            }
            redactar(n, ini, fin, aux, m);
            return m;
        }

        public void redactar(int n, Pila ini, Pila fin, Pila aux, int m)
        {
            Console.WriteLine("Top Pila de Inicio: " + ini.Top);
            Console.WriteLine("Top Pila Auxiliar: " + aux.Top);
            Console.WriteLine("Top Pila Final: " + fin.Top);
            Console.WriteLine("Tamaño final: " + fin.Size);
            Console.WriteLine("Número de movimientos totales: " + m + "\n\n");
        }
    }
}
