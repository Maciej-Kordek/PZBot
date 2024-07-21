namespace PZBot
{
	internal class Program
	{
		internal static Bot PZBot = new Bot();

		static void Main(string[] args)
		{
			PZBot.Start();
			while (true){ }
		}
		public static void LogChatMessage(string channel, string user, string message)
		{
			Console.Write(TimeNow());
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write($" <{channel}>");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine($" {user}: {message}");
		}
		public static void LogError()
		{

		}
		static string TimeNow()
		{
			DateTime TimeNow = DateTime.Now;
			string Time = "";

			if (TimeNow.Hour < 10)
				Time += 0;

			Time += $"{TimeNow.Hour}:";

			if (TimeNow.Minute < 10)
				Time += 0;

			Time += $"{TimeNow.Minute}:";

			if (TimeNow.Second < 10)
				Time += 0;

			Time += TimeNow.Second;

			return Time;
		}
	}
}
