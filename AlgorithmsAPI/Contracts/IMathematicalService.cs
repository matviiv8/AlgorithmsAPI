namespace AlgorithmsAPI.Contracts
{
    public interface IMathematicalService
    {
        Task<int> Factorial(int number);
        Task<int> Fibonacci(int sequenceLength);
        Task<int> IterativeGCD(int firstNumber, int secondNumber);
        Task<int> RecursiveGCD(int firstNumber, int secondNumber);
        Task<bool> IsPrime(int number);
    }
}
