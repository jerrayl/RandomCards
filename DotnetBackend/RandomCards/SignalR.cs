﻿using RandomCards.Models;
using RandomCards.Business;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RandomCards.SignalR
{
    public class SignalRHub : Hub
    {
        private readonly IPlayer _player;
        private readonly IGame _game;
        public SignalRHub(IPlayer player, IGame game)
        {
            _player = player;
            _game = game;
        }

        public async Task<string> AcceptRequest(RequestModel model)
        {
            var gameRoom = _player.AcceptRequest(model.RequestIdentifier, out string errorMessage);
            if (errorMessage != null)
                return errorMessage;

            await Groups.AddToGroupAsync(gameRoom.SenderConnectionId, gameRoom.RoomIdentifier);
            await Groups.AddToGroupAsync(gameRoom.ReceiverConnectionId, gameRoom.RoomIdentifier);

            await Clients.Group(gameRoom.RoomIdentifier).SendAsync("GameStarted");

            return Constants.SUCCESS;
        }

        public async Task<string> SendRequest(EmailModel model)
        {
            var request = _player.SendRequest(Context.ConnectionId, model.Email, out string errorMessage);
            if (request != null)
                await Clients.Client(request.ReceiverConnectionId).SendAsync("Request", request);
            return errorMessage ?? Constants.SUCCESS;
        }

        public async Task<string> Login(EmailModel model)
        {
            var gameRoomIdentifier = _player.Login(model.Email, Context.ConnectionId);

            if (gameRoomIdentifier != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, gameRoomIdentifier);
                await Clients.Group(gameRoomIdentifier).SendAsync("GameStarted");
            }

            return Constants.SUCCESS;
        }
    }
}
