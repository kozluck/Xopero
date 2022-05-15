using System;
using System.Collections.Generic;


namespace Sortowanie.algorithms
{
    public class BubblesortAlgorithm : AlgorithmStrategy
    {
        public void ExecuteAlgorithm(List<string> dataToSort)
        {
            int size = dataToSort.Count;
            if (size >= 2)
            {
                for (int i = 1; i < size; i++)
                {
                    for (int j = 0; j < (size - i); j++)
                    {
                        if (dataToSort[j].CompareTo(dataToSort[j + 1]) >= 0)
                        {
                            string temp = dataToSort[j];
                            dataToSort[j] = dataToSort[j + 1];
                            dataToSort[j + 1] = temp;
                        }
                    }
                }
            }
        }

        public void ExecuteAlgorithm(List<int> dataToSort)
        {
            int size = dataToSort.Count;
            if (size >= 2)
            {
                for (int i = 0; i < (size - 2); i++)
                {
                    for (int j = 0; j < (size - 2); j++)
                    {
                        if (dataToSort[j] > dataToSort[j + 1])
                        {
                            int temp = dataToSort[j + 1];
                            dataToSort[j + 1] = dataToSort[j];
                            dataToSort[j] = temp;
                        }
                    }
                }
            }
        }
    }
}
