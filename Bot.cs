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
using static System.Runtime.InteropServices.JavaScript.JSType;

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

		private static void OnMessageReceived(object sender, OnMessageReceivedArgs e)
		{
			int TwitchId = int.Parse(e.ChatMessage.UserId);
			string User = e.ChatMessage.DisplayName;
			string Message = e.ChatMessage.Message;
			string Channel = e.ChatMessage.Channel;
			bool IsBroadcaster = e.ChatMessage.IsBroadcaster;
			bool IsMod = e.ChatMessage.IsModerator;
			bool IsVip = e.ChatMessage.IsVip;

			//Clean Message
			Message = Regex.Replace(Message, "[^ a-zą-żóA-ZĄ-ŻÓ0-9!-~]", "?", RegexOptions.Compiled);
			Message = Regex.Replace(Message, @"\s+", " ");

			Program.LogChatMessage(Channel, User, Message);
		}
	}
}
