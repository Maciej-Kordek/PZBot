using PZBot.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TwitchLib.Api;
using TwitchLib.Api.Services;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.PubSub;
using TwitchLib.Communication.Interfaces;
using TwitchLib.PubSub.Models.Responses.Messages.Redemption;

namespace PZBot
{
	internal class BotConnection
	{
		public static void Initialize()
		{
			ConnectClient();
		}
		static void ConnectClient()
		{
			using (var context = new Database())
			{
				if (context.Channels.FirstOrDefault(x => x.Channel == BotInfo.BotName.ToLower()) == null)
				{
					var Channel = new Channels(BotInfo.BotName.ToLower(), BotInfo.BotId);
					context.Add(Channel);
					context.SaveChanges();
				}
			}

			var clientOptions = new ClientOptions
			{
				MessagesAllowedInPeriod = 100,
				ThrottlingPeriod = TimeSpan.FromSeconds(10)
			};
			WebSocketClient customClient = new WebSocketClient(clientOptions);
			Bot.client = new TwitchClient(customClient);

			ConnectionCredentials credentials = new ConnectionCredentials(BotInfo.BotName, BotInfo.BotToken);
			Bot.client.Initialize(credentials);
			Bot.client.Connect();

			Bot.client.OnConnected += Bot.OnConnected;
		}
		public static void ConnectChannels()
		{
			List<string> Channels;

			using (var context = new Database())
				Channels = context.Channels.Select(x => x.Channel).ToList();

			foreach (string Channel in Channels)
			{
				ConnectChannel(Channel);
			}
		}
		static void ConnectChannel(string Channel)
		{
			using (var context = new Database())
			{
				Bot.client.JoinChannel(Channel);
			}
		}
	}
}
