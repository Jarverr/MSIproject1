using System;
using System.Linq;

namespace MSI_AEX
{
    class Program
    {
        static void Main(string[] args)
        {

            //wstep tworzacy potrzebne zmienne
            char[][] Populacja = new char[100][];
            double[][] PopulacjaForWeight = new double[100][];
            double[] fitness = new double[100];
            double massiveFit = 0;
            Random rnd = new Random();
            char[] sign = new char[30];
            double[] signsWeight = new double[30];
            string alphabet = "";
            char rndsign;
            int rndNumber;
            int[][] coupleOfParents = new int[100][];
            int nrOfParent1;
            int nrOfParent2;
            for (int i = 0; i < sign.Length; i++)

            {
                if (i <= 25)
                {
                    sign[i] = (char)('a' + i);
                }
                else
                {
                    sign[i] = (char)(i + 18);
                }
                //przypisanie wag

                if (i == 0)
                {
                    signsWeight[i] = 8.12;
                }
                else if (i == 1)
                {
                    signsWeight[i] = 1.49;
                }
                else if (i == 2)
                {
                    signsWeight[i] = 2.71;
                }
                else if (i == 3)
                {
                    signsWeight[i] = 4.32;
                }
                else if (i == 4)
                {
                    signsWeight[i] = 12.02;
                }
                else if (i == 5)
                {
                    signsWeight[i] = 2.30;
                }
                else if (i == 6)
                {
                    signsWeight[i] = 2.03;
                }
                else if (i == 7)
                {
                    signsWeight[i] = 5.92;
                }
                else if (i == 8)
                {
                    signsWeight[i] = 7.31;
                }
                else if (i == 9)
                {
                    signsWeight[i] = 0.1;
                }
                else if (i == 10)
                {
                    signsWeight[i] = 0.69;
                }
                else if (i == 11)
                {
                    signsWeight[i] = 3.98;
                }
                else if (i == 12)
                {
                    signsWeight[i] = 2.61;
                }
                else if (i == 13)
                {
                    signsWeight[i] = 6.95;
                }
                else if (i == 14)
                {
                    signsWeight[i] = 7.68;
                }
                else if (i == 15)
                {
                    signsWeight[i] = 1.82;
                }
                else if (i == 16)
                {
                    signsWeight[i] = 0.11;
                }
                else if (i == 17)
                {
                    signsWeight[i] = 6.02;
                }
                else if (i == 18)
                {
                    signsWeight[i] = 6.28;
                }
                else if (i == 19)
                {
                    signsWeight[i] = 9.1;
                }
                else if (i == 20)
                {
                    signsWeight[i] = 2.88;
                }
                else if (i == 21)
                {
                    signsWeight[i] = 1.11;
                }
                else if (i == 22)
                {
                    signsWeight[i] = 2.09;
                }
                else if (i == 23)
                {
                    signsWeight[i] = 0.17;
                }
                else if (i == 24)
                {
                    signsWeight[i] = 2.11;
                }
                else if (i == 25)
                {
                    signsWeight[i] = 0.07;
                }
                else if (i == 26)
                {
                    signsWeight[i] = 1.3;
                }
                else if (i == 27)
                {
                    signsWeight[i] = 0.05;
                }
                else if (i == 28)
                {
                    signsWeight[i] = 1.1;
                }
                else if (i == 29)
                {
                    signsWeight[i] = 0.02;
                }
            }
            //foreach (var item in signsWeight)
            //{
            //    Console.WriteLine(item);
            //}
            //http://pi.math.cornell.edu/~mec/2003-2004/cryptography/subs/frequencies.html
            char[][] childrenPopulation = new char[100][];
            double[][] childrePopulationWeight = new double[100][];
            int number;
            string p1 = "";
            string p2 = "";
            string c = "";
            double[] fitnessMasterPosition = new double[100];
            char[][] newPopulation = new char[100][];
            double[][] newPopulationWeight = new double[100][];
            double[] fitnessChildren = new double[100];
            double massiveFitChild = 0;
            double[] HistroyOfFit = new double[1000];
            HistroyOfFit[0] = 100000;
            int t = 1;

            //utworzenie 100 losowych rodziców - czyli 100 losowych rozkładów na klawiaturze
            for (int i = 0, j = 0; i < Populacja.Length; i++, j = 0, alphabet = "")
            {
                Populacja[i] = new char[30];
                PopulacjaForWeight[i] = new double[30];
                do
                {
                    rndNumber = rnd.Next(0, 30);
                    rndsign = sign[rndNumber];
                    if (!alphabet.Contains(rndsign))
                    {
                        alphabet += rndsign;
                        Populacja[i][j] = rndsign;
                        PopulacjaForWeight[i][j] = signsWeight[rndNumber];
                        j++;

                    }
                } while (alphabet.Length <= 29);
                //Console.WriteLine(alphabet) ;
                //Console.WriteLine(PopulacjaForWeight[i][29]);
            }
            do
            {
                massiveFit = 0;
                //fitness rodziców
                for (int i = 0; i < Populacja.Length; i++)
                {

                    fitness[i] = 5 * PopulacjaForWeight[i][5] + 5 * PopulacjaForWeight[i][24] +
                    4 * PopulacjaForWeight[i][0] + 4 * PopulacjaForWeight[i][4] + 4 * PopulacjaForWeight[i][9] + 4 * PopulacjaForWeight[i][20] + 4 * PopulacjaForWeight[i][21] + 4 * PopulacjaForWeight[i][28] + 4 * PopulacjaForWeight[i][29]
                    + 3 * PopulacjaForWeight[i][3] + 3 * PopulacjaForWeight[i][6] + 3 * PopulacjaForWeight[i][14] + 3 * PopulacjaForWeight[i][15] + 3 * PopulacjaForWeight[i][22] + 3 * PopulacjaForWeight[i][25] + 3 * PopulacjaForWeight[i][27]
                    + 2 * PopulacjaForWeight[i][1] + 2 * PopulacjaForWeight[i][2] + 2 * PopulacjaForWeight[i][7] + 2 * PopulacjaForWeight[i][8] + 2 * PopulacjaForWeight[i][23] + 2 * PopulacjaForWeight[i][26]
                    + 1.5 * PopulacjaForWeight[i][10] + 1.5 * PopulacjaForWeight[i][19]
                    + PopulacjaForWeight[i][11] + PopulacjaForWeight[i][12] + PopulacjaForWeight[i][13] + PopulacjaForWeight[i][16] + PopulacjaForWeight[i][17] + PopulacjaForWeight[i][18];
                    massiveFit += fitness[i];

                }
                HistroyOfFit[t] = massiveFit;

                //selekcja

                for (int i = 0; i < coupleOfParents.Length; i++)
                {
                    coupleOfParents[i] = new int[2];
                    for (int j = 0; j < 2; j++)
                    {
                        nrOfParent1 = rnd.Next(0, 100);
                        nrOfParent2 = rnd.Next(0, 100);
                        if (fitness[nrOfParent1] > fitness[nrOfParent2])
                            coupleOfParents[i][j] = nrOfParent2;
                        else
                            coupleOfParents[i][j] = nrOfParent1;
                    }
                }

                //krzyzowanie AEX

                for (int i = 0; i < childrenPopulation.Length; i++)
                {
                    c = "";
                    p1 = "";
                    p2 = "";
                    childrenPopulation[i] = new char[30];
                    childrePopulationWeight[i] = new double[30];
                    childrenPopulation[i][0] = Populacja[coupleOfParents[i][0]][0];
                    childrePopulationWeight[i][0] = PopulacjaForWeight[coupleOfParents[i][0]][0];
                    c += Populacja[coupleOfParents[i][0]][0];
                    for (int j = 0; j < 30; j++)
                    {
                        p1 += Populacja[coupleOfParents[i][0]][j];
                        p2 += Populacja[coupleOfParents[i][1]][j];
                    }
                    for (int j = 1; j < childrenPopulation[i].Length; j++)
                    {
                        if (j % 2 == 0)
                        {
                            number = Array.IndexOf(p2.ToArray(), childrenPopulation[i][j - 1]);
                            if (number == 29 && !c.Contains(Populacja[coupleOfParents[i][1]][0]))
                            {
                                childrenPopulation[i][j] = Populacja[coupleOfParents[i][1]][0];
                                childrePopulationWeight[i][j] = PopulacjaForWeight[coupleOfParents[i][1]][0];
                                c += childrenPopulation[i][j];
                            }
                            else if (number == 29 || c.Contains(Populacja[coupleOfParents[i][1]][number + 1]))
                            {
                                do
                                {
                                    number = rnd.Next(0, 30);
                                } while (c.Contains(Populacja[coupleOfParents[i][1]][number]));
                                childrenPopulation[i][j] = Populacja[coupleOfParents[i][1]][number];
                                childrePopulationWeight[i][j] = PopulacjaForWeight[coupleOfParents[i][1]][number];
                                c += childrenPopulation[i][j];
                            }
                            else
                            {
                                childrenPopulation[i][j] = Populacja[coupleOfParents[i][1]][number + 1];
                                childrePopulationWeight[i][j] = PopulacjaForWeight[coupleOfParents[i][1]][number + 1];
                                c += childrenPopulation[i][j];
                            }
                        }
                        else if (j % 2 == 1)
                        {
                            number = Array.IndexOf(p1.ToArray(), childrenPopulation[i][j - 1]);
                            if (number == 29 && !c.Contains(Populacja[coupleOfParents[i][0]][0]))  //0 i 1 element dziecka sa z matki???
                            {
                                childrenPopulation[i][j] = Populacja[coupleOfParents[i][0]][0];
                                childrePopulationWeight[i][j] = PopulacjaForWeight[coupleOfParents[i][0]][0];
                                c += childrenPopulation[i][j];
                            }
                            else if (number == 29 || c.Contains(Populacja[coupleOfParents[i][0]][number + 1]))
                            {
                                do
                                {
                                    number = rnd.Next(0, 30);
                                } while (c.Contains(Populacja[coupleOfParents[i][0]][number]));
                                childrenPopulation[i][j] = Populacja[coupleOfParents[i][0]][number];
                                childrePopulationWeight[i][j] = PopulacjaForWeight[coupleOfParents[i][0]][number];
                                c += childrenPopulation[i][j];
                            }
                            else
                            {
                                childrenPopulation[i][j] = Populacja[coupleOfParents[i][0]][number + 1];
                                childrePopulationWeight[i][j] = PopulacjaForWeight[coupleOfParents[i][0]][number + 1];
                                c += childrenPopulation[i][j];
                            }
                        }
                    }
                }

                //for (int i = 0; i < childrenPopulation.Length; i++)
                //{
                //    Console.WriteLine("{0}",i);
                //    for (int j = 0; j < childrenPopulation[i].Length; j++)
                //    {
                //        Console.Write(childrenPopulation[i][j]);
                //    }
                //    Console.WriteLine();
                //}

                //fitnes dzieci
                //fitness rodziców

                for (int i = 0; i < Populacja.Length; i++)
                {

                    fitnessChildren[i] = 5 * childrePopulationWeight[i][5] + 5 * childrePopulationWeight[i][24] +
                    4 * childrePopulationWeight[i][0] + 4 * childrePopulationWeight[i][4] + 4 * childrePopulationWeight[i][9] + 4 * childrePopulationWeight[i][20] + 4 * childrePopulationWeight[i][21] + 4 * childrePopulationWeight[i][28] + 4 * childrePopulationWeight[i][29]
                    + 3 * childrePopulationWeight[i][3] + 3 * childrePopulationWeight[i][6] + 3 * childrePopulationWeight[i][14] + 3 * childrePopulationWeight[i][15] + 3 * childrePopulationWeight[i][22] + 3 * childrePopulationWeight[i][25] + 3 * childrePopulationWeight[i][27]
                    + 2 * childrePopulationWeight[i][1] + 2 * childrePopulationWeight[i][2] + 2 * childrePopulationWeight[i][7] + 2 * childrePopulationWeight[i][8] + 2 * childrePopulationWeight[i][23] + 2 * childrePopulationWeight[i][26]
                    + 1.5 * childrePopulationWeight[i][10] + 1.5 * childrePopulationWeight[i][19]
                    + childrePopulationWeight[i][11] + childrePopulationWeight[i][12] + childrePopulationWeight[i][13] + childrePopulationWeight[i][16] + childrePopulationWeight[i][17] + childrePopulationWeight[i][18];
                    massiveFitChild += fitnessChildren[i];
                }

                //Console.WriteLine(massiveFit);
                //Console.WriteLine(massiveFitChild);
                //Console.WriteLine();


                //generacja nowego pokolenia 20% najlepszyhc rodziców i 80% najlepszych dzieci
                for (int i = 0; i < fitnessMasterPosition.Length; i++)
                {
                    fitnessMasterPosition[i] = 2000;
                }

                number = 0;
                double tempFit;
                for (int j = 0; j < 20; j++)
                {
                    newPopulationWeight[j] = new double[30];
                    newPopulation[j] = new char[30];
                    for (int k = 0; k < fitness.Length; k++)
                    {
                        if (fitnessMasterPosition[j] > fitness[k])
                        {
                            tempFit = fitness[k];
                            fitness[number] = fitnessMasterPosition[j];
                            number = k;
                            fitnessMasterPosition[j] = tempFit;
                            for (int l = 0; l < Populacja[k].Length; l++)
                            {
                                newPopulation[j][l] = Populacja[k][l];
                                newPopulationWeight[j][l] = PopulacjaForWeight[k][l];                                
                            }
                            fitness[k] = 3000;
                        }
                    }
                }
                for (int j = 20; j < 100; j++)
                {
                    newPopulationWeight[j] = new double[30];
                    newPopulation[j] = new char[30];
                    for (int k = 0; k < fitnessChildren.Length; k++)
                    {
                        if (fitnessMasterPosition[j] > fitnessChildren[k])
                        {
                            tempFit = fitnessChildren[k];
                            fitnessChildren[number] = fitnessMasterPosition[j];
                            number = k;
                            fitnessMasterPosition[j] = tempFit;
                            for (int l = 0; l < childrenPopulation[k].Length; l++)
                            {
                                newPopulation[j][l] = childrenPopulation[k][l];
                                newPopulationWeight[j][l] = childrePopulationWeight[k][l];
                            }
                            fitness[k] = 3000;
                        }
                    }
                }

                for (int i = 0; i < Populacja.Length; i++)
                {
                    for (int j = 0; j < Populacja[i].Length; j++)
                    {
                        Populacja[i][j] = newPopulation[i][j];
                        PopulacjaForWeight[i][j] = newPopulationWeight[i][j];
                    }
                }
                t++;
            } while (HistroyOfFit[t-1]<HistroyOfFit[t-2]||HistroyOfFit[t-2]<HistroyOfFit[t-3]||HistroyOfFit[t-3]<HistroyOfFit[t-4]);



            //results
            for (int i = 1; i <= t; i++)
            {
                Console.WriteLine("{0}:\t{1}", i, HistroyOfFit[i - 1]);
            }
            for (int i = 0; i < Populacja.Length; i++)
            {

                fitness[i] = 5 * PopulacjaForWeight[i][5] + 5 * PopulacjaForWeight[i][24] +
                4 * PopulacjaForWeight[i][0] + 4 * PopulacjaForWeight[i][4] + 4 * PopulacjaForWeight[i][9] + 4 * PopulacjaForWeight[i][20] + 4 * PopulacjaForWeight[i][21] + 4 * PopulacjaForWeight[i][28] + 4 * PopulacjaForWeight[i][29]
                + 3 * PopulacjaForWeight[i][3] + 3 * PopulacjaForWeight[i][6] + 3 * PopulacjaForWeight[i][14] + 3 * PopulacjaForWeight[i][15] + 3 * PopulacjaForWeight[i][22] + 3 * PopulacjaForWeight[i][25] + 3 * PopulacjaForWeight[i][27]
                + 2 * PopulacjaForWeight[i][1] + 2 * PopulacjaForWeight[i][2] + 2 * PopulacjaForWeight[i][7] + 2 * PopulacjaForWeight[i][8] + 2 * PopulacjaForWeight[i][23] + 2 * PopulacjaForWeight[i][26]
                + 1.5 * PopulacjaForWeight[i][10] + 1.5 * PopulacjaForWeight[i][19]
                + PopulacjaForWeight[i][11] + PopulacjaForWeight[i][12] + PopulacjaForWeight[i][13] + PopulacjaForWeight[i][16] + PopulacjaForWeight[i][17] + PopulacjaForWeight[i][18];
                massiveFit += fitness[i];

            }
            for (int i = 0; i < Populacja.Length; i++)
            {
                Console.WriteLine("{0}:\t{1}", i, fitness[i]);
                for (int j = 0; j < Populacja[i].Length; j++)
                {
                    Console.Write(Populacja[i][j]);
                }
                Console.WriteLine();
            }

            

        }
    }       
}
