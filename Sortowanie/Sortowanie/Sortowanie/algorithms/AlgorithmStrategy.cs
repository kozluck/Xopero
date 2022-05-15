using System;
using System.Collections.Generic;


namespace Sortowanie.algorithms
{
    public interface AlgorithmStrategy
    {
        public void ExecuteAlgorithm(List<String> dataToSort);
        public void ExecuteAlgorithm(List<int> dataToSort);
    }
}
