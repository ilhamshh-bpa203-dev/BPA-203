namespace task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            int[] arr2 = { 4, 5, 6 };
            CustomArrResize(ref arr, ref arr2);

        }

        public static void CustomArrResize(ref int[] frArr, ref int[] secArr)
        {
            int[] rsArr = new int[frArr.Length + secArr.Length];
            int j = 0;
            for (int i = 0; i < frArr.Length; i++)
            {
                rsArr[j] = frArr[i];
                j++;
            }
            for (int i = 0; i < secArr.Length; i++)
            {
                rsArr[j] = secArr[i];
                j++;
            }

            for (int i = 0; i < rsArr.Length; i++)
            {
                Console.WriteLine(rsArr[i]);
            }
        }
    }
}
