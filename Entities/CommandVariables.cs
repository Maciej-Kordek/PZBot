using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PZBot.Entities
{
	public class CommandVariables
	{
		public CommandVariables() { }
		public CommandVariables(string channelId, string group, string type, string value, int commandId = -1, int parent = -1)
		{
			ChannelId = channelId;
			CommandId = commandId;
			Group = group;
			Parent = parent;
			Type = type;
			Value = value;
		}
		public int id { get; set; }
		public string ChannelId { get; set; }
		public int CommandId { get; set; }
		public string Group { get; set; }
		public int Parent { get; set; }
		public string Type { get; set; }
		public string Value { get; set; }

		public ChannelCommands ChannelCommands { get; set; }
	}
}
