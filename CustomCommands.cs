using PZBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBot
{
	internal class CustomCommands
	{
		public static void CommandMenu(string channelId, string userId, List<string> arguments)
		{
			if (arguments.Count < 3)
			{
				//Not enough arguments
				//Add error
				return;
			}
			switch (arguments[1].ToLower())
			{
				case "add":
				case var value when value == Properties.strings.CustomCommands_add:
					{
						AddCommand();
						break;
					}
				case "edit":
				case var value when value == Properties.strings.CustomCommands_edit:
					{
						EditCommand();
						break;
					}
				case "delete":
				case var value when value == Properties.strings.CustomCommands_delete:
					{
						DeleteCommand();
						break;
					}
				default:
					//add error
					break;
			}
		}
		static void AddCommand()
		{

		}
		static void EditCommand()
		{

		}
		static void DeleteCommand()
		{

		}

		public static void ChannelCommands(string channelId, string userId, List<string> arguments)
		{
			ChannelCommands command = FindCommand(arguments[0]);
			if (command == null)
			{
				//command not found
				return;
			}
			string response = Eval.Evaluate(channelId, userId, command.Response, arguments);
			Bot.SendMessage(channelId, response);
		}
		static ChannelCommands FindCommand(string commandName)
		{
			using (var context = new Database())
			{
				return context.ChannelCommands.FirstOrDefault(x => x.CommandName == commandName);
			}
		}
	}
}
