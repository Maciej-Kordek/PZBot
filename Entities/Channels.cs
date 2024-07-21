using System;
using System.Collections.Generic;

namespace PZBot.Entities
{
	public class Channels
	{
		public Channels() { }

		public Channels(string channel, string channelId)
		{
			Channel = channel;
			ChannelId = channelId;
		}

		public int id { get; set; }
		public string Channel { get; set; }
		public string ChannelId { get; set; }

		public List<ChannelCommands> ChannelCommands { get; set; }

		public static Channels GetChannel(string channelId)
		{
			using (var context = new Database())
			{
				return context.Channels.FirstOrDefault(x => x.ChannelId == channelId);
			}
		}
	}
}
