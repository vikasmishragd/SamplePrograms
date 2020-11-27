using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
	class Program
	{
		public static AutoResetEvent even;
		public static AutoResetEvent odd;
		static void Main(string[] args)
		{
			even = new AutoResetEvent(true);
			odd = new AutoResetEvent(false);

			Thread T1 = new Thread(PrintEven);
			Thread T2 = new Thread(PrintOdd);
			T1.Start();
			T2.Start();
			T1.Join();
			T2.Join();
			Console.Read();

		}

		private static void PrintOdd()
		{
			for(int i=1;i<20;i=i+2)
			{
				odd.WaitOne();
				Console.WriteLine(" "+i);
				even.Set();
			}
		}

		private static void PrintEven()
		{
			for (int i = 0; i < 20; i = i + 2)
			{
				even.WaitOne();
				Console.WriteLine(i);
				Thread.Sleep(3000);
				odd.Set();
			}
		}
	}
}
