using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie.algorithms
{
    class Algorithm
    {
        private AlgorithmStrategy _strategy;
        private AlgorithmWithRecursionStrategy _strategyAlgorithmRecursion;

        public Algorithm() { }

        public Algorithm(AlgorithmStrategy strategy) 
        {
            _strategy = strategy; 
        }

        public void setStrategy(AlgorithmStrategy strategy)
        {
            this._strategy = strategy;
        }
        public void setStrategy(AlgorithmWithRecursionStrategy strategyAlgorithmRecursion)
        {
            _strategyAlgorithmRecursion = strategyAlgorithmRecursion;
        }

        public void doAlgorithm(List<String> dataToSort,int left = 0, int right = 0)
        {
            if (left != 0 || right != 0)
                _strategyAlgorithmRecursion.ExecuteAlgorithm(dataToSort, left, right);
            else
                _strategy.ExecuteAlgorithm(dataToSort);
        }
        public void doAlgorithm(List<int> dataToSort, int left = 0, int right = 0)
        {
            if(dataToSort!= null)
            {
                if (left != 0 || right != 0)
                    _strategyAlgorithmRecursion.ExecuteAlgorithm(dataToSort, left, right);
                else
                    _strategy.ExecuteAlgorithm(dataToSort);
            }
        }
    }
}
