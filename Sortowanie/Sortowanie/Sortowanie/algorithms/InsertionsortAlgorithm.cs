using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie.algorithms
{
    public class InsertionsortAlgorithm : AlgorithmStrategy
    {
        public void ExecuteAlgorithm(List<string> dataToSort)
        {
            int size = dataToSort.Count;
            if (size >= 2)
            {
                for (int i = 1; i < size; ++i)
                {
                    string key = dataToSort[i];
                    int j = i - 1;
                    while (j >= 0 && dataToSort[j].CompareTo(key) > 0)
                    {
                        dataToSort[j + 1] = dataToSort[j];
                        j = j - 1;
                    }
                    dataToSort[j + 1] = key;
                }
            }
        }

        public void ExecuteAlgorithm(List<int> dataToSort)
        {

            int size = dataToSort.Count;
            if (size >= 2)
            {
                for (int i = 1; i < size; ++i)
                {
                    int key = dataToSort[i];
                    int j = i - 1;
                    while (j >= 0 && dataToSort[j] > key)
                    {
                        dataToSort[j + 1] = dataToSort[j];
                        j = j - 1;
                    }
                    dataToSort[j + 1] = key;
                }
            }
        }
    }
}
