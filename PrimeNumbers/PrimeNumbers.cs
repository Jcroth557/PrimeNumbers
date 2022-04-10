namespace Primes
{
    interface IPrimeNumberGenerator
    {
        List<int> generate(int startingValue, int endingValue);
        bool isPrime(int value);
    }

    public class PrimeFinder : IPrimeNumberGenerator
    {
        public static void Main()
        {
            PrimeFinder primeFinder = new PrimeFinder();
            List<int> rangeList = new List<int>();
            List<int> outputList = new List<int>();

            rangeList = primeFinder.getInputs();
            
            if (rangeList.Count == 0)
            {
                Console.WriteLine("Must enter two positive integers.");
            }
            else
            {
                outputList = primeFinder.generate(rangeList[0], rangeList[1]);

                primeFinder.printResults(outputList);
            }
        }



        public List<int> generate(int startingValue, int endingValue)
        {
            List<int> primeNumbersList = new List<int>();
            for (int i = startingValue; i <= endingValue; i++)
            {
                if (isPrime(i))
                {
                    primeNumbersList.Add(i);
                }
            }
            return primeNumbersList;
        }

        public bool isPrime(int value)
        {
            if (value == 2)
            {
                return true;
            }
            if (value % 2 == 0 || value == 1)
            {
                return false;
            }

            //Only checking odd numbers since even numbers were checked above
            for (int i = 3; i < value / 2; i += 2)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //Returns empty list if given bad input
        public List<int> getInputs()
        {
            List<int> inputsList = new List<int> ();

            Console.WriteLine("Enter the first number of your range: ");
            if (Int32.TryParse(Console.ReadLine(), out int a))
            {
                inputsList.Add(a);

                Console.WriteLine("Enter the second number of your range: ");
                if (Int32.TryParse(Console.ReadLine(), out int b))
                {
                    inputsList.Add(b);

                    if(inputsList[0] < 1 || inputsList[1] < 1)
                    {
                        inputsList.Clear();
                        return inputsList;
                    }

                    inputsList.Sort();
                    return inputsList;
                }
            }
            inputsList.Clear ();
            return inputsList;
        }

        public void printResults(List<int> numbersList)
        {
            if (numbersList.Count > 0)
            {
                Console.WriteLine("Here are the prime numbers in that range: ");
                for (int i = 0; i < numbersList.Count; i++)
                {
                    Console.WriteLine(numbersList[i]);
                }
            }
            else
            {
                Console.WriteLine("There are no prime numbers in that range.");
            }
        }
    }
}
