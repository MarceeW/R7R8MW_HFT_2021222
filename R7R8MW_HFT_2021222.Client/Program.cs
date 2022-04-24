using System;

namespace R7R8MW_HFT_2021222.Client
{
    internal class Program
    {
        static RestService restService;
        static void Main(string[] args)
        {
            restService = new RestService("RestService","pings");
        }
    }
}
