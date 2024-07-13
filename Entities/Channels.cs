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
	}
}
