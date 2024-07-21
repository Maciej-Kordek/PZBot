using PZBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBot.Entities
{
	public class ChannelCommands
	{
		public ChannelCommands() { }

		public ChannelCommands(string commandname, string response, string channelId)
		{
			CommandName = commandname;
			Response = response;
			ChannelId = channelId;
		}

		public int id { get; set; }
		public string CommandName { get; set; }
		public string Response { get; set; }
		public string ChannelId { get; set; }

		public Channels Channels { get; set; }
		public List<CommandVariables> CommandVariables { get; set; }
	}
}
