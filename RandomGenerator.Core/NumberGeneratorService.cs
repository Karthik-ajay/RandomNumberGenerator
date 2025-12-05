namespace RandomGenerator.Core
{
    public class NumberGeneratorService
    {
        private readonly Random _random;
        public NumberGeneratorService()
        {
            _random = new Random();
        }

        public int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
