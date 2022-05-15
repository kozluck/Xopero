using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie.algorithms
{
    public interface AlgorithmWithRecursionStrategy
    {
        public void ExecuteAlgorithm(List<String> dataToSort, int left, int right);
        public void ExecuteAlgorithm(List<int> dataToSort, int left, int right);
    }
}
