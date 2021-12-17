using System;


namespace Backend.Controllers
{
    public class Sum
    {
        public int Add(string a, string b)
        {
            int result = Convert.ToInt32(a) + Convert.ToInt32(b);
            return result;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Sum obj = new Sum();
            int v = obj.Add("90", "65");
            Console.WriteLine(v);

        }
    }

}