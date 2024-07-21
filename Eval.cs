using Azure;
using PZBot.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TwitchLib.Api.Core.Models.Undocumented.Chatters;

namespace PZBot
{
	internal class Eval
	{
		public static string Evaluate(string channelId, string userId, string response, List<string> arguments)
		{
			response = SwapTwitchVariables(channelId, userId, response, arguments);

			return response;
		}

		static string SwapTwitchVariables(string channelId, string userId, string input, List<string> arguments)
		{
			if (input.ToLower().Contains("$(channel)"))
				input = input.Replace("$(channel)", Channels.GetChannel(channelId).Channel, StringComparison.OrdinalIgnoreCase);

			/*
			if (input.ToLower().Contains("$(user)"))
				input = input.Replace("$(user)", ChatUsers.GetUserById(userId).Name, StringComparison.OrdinalIgnoreCase);
			*/

			if (input.ToLower().Contains("$(atuser)"))
			{
				string user = arguments[0].Replace("@","");

				/*if (ChatUsers.GetUserByName(user) != null)
					user = ChatUsers.GetUserByName(user).Name;*/

				input = input.Replace("$(user)", user, StringComparison.OrdinalIgnoreCase);
			}

			if (input.ToLower().Contains("$(query)"))
			{
				List<string> args = new List<string>();
				args = arguments.ToList();
				args.RemoveAt(0);
				input = input.Replace("$(query)", string.Join(" ", args), StringComparison.OrdinalIgnoreCase);
			}

			for (int i = 1; i <= arguments.Count; i++)
			{
				if(input.ToLower().Contains($"$(arg {i})"))
					input = input.Replace($"$(arg {i})", arguments[i], StringComparison.OrdinalIgnoreCase);
			}

			return input;
		}
	}
}
