namespace LeetCodeTest
{
    public class leetCode50
    {
        public double Pow(double x, int n)
        {
            var tmp = x;

            if (n > 0)
            {
                for (int i = n; i > 1; i--)
                {
                    x = x * tmp;
                }
            }
            else if (n < 0)
            {
                for (int i = n; i < -1; i++)
                {
                    x = x / tmp;
                }
            }

            return x;
        }
    }
}