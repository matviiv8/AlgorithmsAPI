using AlgorithmsAPI.Contracts.Algorithms;

namespace AlgorithmsAPI.Services.Algorithms
{
    public class MathematicalService : IMathematicalService
    {
        public async Task<int> Factorial(int number)
        {
            if (number < 0)
            {
                throw new InvalidOperationException("Number must be a non-negative.");
            }

            return (number == 0 || number == 1) ? 1 : number * await Factorial(number-1);
        }

        public async Task<int> Fibonacci(int sequenceLength)
        {
            if (sequenceLength < 0)
            {
                throw new InvalidOperationException("Sequence length must be a non-negative.");
            }

            return (sequenceLength >= 0 && sequenceLength <= 1) ? sequenceLength : await Fibonacci(sequenceLength - 1) + await Fibonacci(sequenceLength - 2);
        }

        public async Task<int> IterativeGCD(int firstNumber, int secondNumber)
        {
            while (secondNumber != 0)
            {
                secondNumber = firstNumber % (firstNumber = secondNumber);
            }

            return Math.Abs(firstNumber);
        }

        public async Task<int> RecursiveGCD(int firstNumber, int secondNumber)
        {
            return secondNumber == 0 ? Math.Abs(firstNumber) : await RecursiveGCD(secondNumber, firstNumber % secondNumber);
        }

        public async Task<int[]> SieveOfEratosthenes(int threshold)
        {
            if(threshold < 0)
            {
                throw new InvalidOperationException("Threshold must be a non-negative.");
            }

            var primeNumbers = new List<int>();

            var sieve = new bool[threshold + 1];
            for (int i = 2; i <= threshold; i++)
            {
                if (!sieve[i])
                {
                    primeNumbers.Add(i);

                    for (int j = i * i; j <= threshold; j += i)
                    {
                        sieve[j] = true;
                    }
                }
            }

            return primeNumbers.ToArray();
        }

        public async Task<bool> IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
