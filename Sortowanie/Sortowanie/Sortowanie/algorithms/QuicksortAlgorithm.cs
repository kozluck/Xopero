using System;
using System.Collections.Generic;


namespace Sortowanie.algorithms
{
    public class QuicksortAlgorithm : AlgorithmWithRecursionStrategy
    {
        public void ExecuteAlgorithm(List<string> dataToSort, int left, int right)
        {
            string pivot = dataToSort[(left + right) / 2];
            var i = left;
            var j = right;

            while (i <= j)
            {
                while (dataToSort[i].CompareTo(pivot) < 0) i++;
                while (dataToSort[j].CompareTo(pivot) > 0) j--;
                if (i <= j)
                {
                    var tmp = dataToSort[i];
                    dataToSort[i++] = dataToSort[j];
                    dataToSort[j--] = tmp;
                }
            }
            if (left < j) ExecuteAlgorithm(dataToSort, left, j);
            if (i < right) ExecuteAlgorithm(dataToSort, i, right);
        }

        public void ExecuteAlgorithm(List<int> dataToSort, int left, int right)
        {
            int pivot = dataToSort[(left + right) / 2];
            var i = left;
            var j = right;

            while (i <= j)
            {
                while (dataToSort[i] < pivot) i++;
                while (dataToSort[j] > pivot) j--;
                if (i <= j)
                {
                    var tmp = dataToSort[i];
                    dataToSort[i++] = dataToSort[j];
                    dataToSort[j--] = tmp;
                }
            }
            if (left < j) ExecuteAlgorithm(dataToSort, left, j);
            if (i < right) ExecuteAlgorithm(dataToSort, i, right);
        }
    }
}
