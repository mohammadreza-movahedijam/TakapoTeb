using Application.Commands.Chat;
using Application.Queries.Chat;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using NuGet.Protocol.Plugins;
using System.Reflection;

namespace EndPointUI.Hubs;

public class SupportHub:Hub
{
    readonly IHubContext<ChatHub> _context;
    readonly IMediator _mediator;
    public SupportHub(IMediator mediator, IHubContext<ChatHub> context)
    {
        _mediator = mediator;
        _context = context;
    }
    string GetUserIp()
    {
        var httpContext = Context.GetHttpContext();
        var ipAddress = httpContext?.Connection?.RemoteIpAddress?.ToString();
        return ipAddress!;
    }


    public async Task SendMessageAsync
      (string message,string activeRoomId)
    {
        var connectionId = Context.ConnectionId;
      
        await _mediator.Send(new SendMessageCommand()
        {
            Message = new MessageDto()
            {
                ConnectionId = connectionId,
                Message = message,
                ChatGroupId = activeRoomId,
                IPAddress = GetUserIp(),
                UserType = Domain.Types.UserType.Support
            }
        });


        await _context.Clients.Groups(activeRoomId).SendAsync("ReceiveMessage", "support-message", message);
    }
    public async Task LoadMessagesAsync(string groupId)
    {
        IReadOnlyList<MessageViewModel> messages=
            await _mediator.Send(new GetMessagesQuery() { Id = Guid.Parse(groupId) });
        await Clients.Caller.SendAsync("SyncGoupMessages", messages);
    }
    public override async Task OnConnectedAsync()
    {
        IReadOnlyList<ChatGroupViewModel> groups =
            await _mediator.Send(new GetChatGroupQuery());

        await Clients.Caller.SendAsync("Rooms",groups);

        await base.OnConnectedAsync();
    }
}
