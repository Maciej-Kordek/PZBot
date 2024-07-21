using PZBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace PZBot
{
	internal class Commands
	{
		public static bool BotCommands(string channelId, string userId, List<string> arguments)
		{
			switch (arguments[0].ToLower().Substring(1))
			{
				case "command":
				case var value when value == Properties.strings.BotCommands_command:
					CustomCommands.CommandMenu(channelId, userId, arguments);
					break;
				default:
					return false;
			}
			return true;
		}
	}
}
