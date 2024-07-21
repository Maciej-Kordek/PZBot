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
using System.Globalization;

namespace PZBot
{
	internal class Bot
	{
		public static TwitchClient client;

		internal void Start()
		{
			BotConnection.Initialize();
		}
		public static void OnConnected(object sender, OnConnectedArgs e)
		{
			client.OnMessageReceived += OnMessageReceived;

			BotConnection.ConnectChannels();
		}

		static void OnMessageReceived(object sender, OnMessageReceivedArgs e)
		{
			string userId = e.ChatMessage.UserId;
			string userName = e.ChatMessage.DisplayName;
			string message = e.ChatMessage.Message;
			string channelId = e.ChatMessage.RoomId;
			string channel = e.ChatMessage.Channel;
			bool isBroadcaster = e.ChatMessage.IsBroadcaster;
			bool isMod = e.ChatMessage.IsModerator;
			bool isVip = e.ChatMessage.IsVip;

			//Clean Message
			message = Regex.Replace(message, "[^ a-zą-żóA-ZĄ-ŻÓ0-9!-~]", "?", RegexOptions.Compiled);
			message = Regex.Replace(message, @"\s+", " ");

			Program.LogChatMessage(channel, userName, message);
			CheckMessage(channelId, channel, userId, userName, message);
		}

		static void CheckMessage(string channelId, string channel, string userId, string userName, string message)
		{
			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pl-PL");

			//Split by spacebars
			List<string> arguments = Regex.Split(message, @"\s+").ToList();

			if (arguments[0].StartsWith('!'))
			{
				if (Commands.BotCommands(channelId, userId, arguments))
					return;
			}

			CustomCommands.ChannelCommands(channelId, userId, arguments);
		}
		public static void SendMessage(string channelId, string message)
		{
			string channel = string.Empty;
			using (var context = new Database())
			{
				channel = context.Channels.FirstOrDefault(x => x.ChannelId == channelId).Channel;
				if (channel == null)
				{
					return;
				}
			}
			client.SendMessage(channel, message);
		}
	}
}
