using Application.Commands.Chat;
using Application.Queries.Chat;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace EndPointUI.Hubs;

public class ChatHub : Hub
{
    readonly IMediator _mediator;
    public ChatHub(IMediator mediator)
    {
        _mediator = mediator;
    }
     string GetUserIp()
    {
        var httpContext = Context.GetHttpContext();
        var ipAddress = httpContext?.Connection?.RemoteIpAddress?.ToString();
        return ipAddress!;
    }


    //[Authorize]
    public async Task JoinGroupAsync(string Id)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId,Id);
    }
    //[Authorize]
    public async Task LeftGroupAsync(string Id)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId,Id);
    }
    public async Task Test()
    {
        var connectionId = Context.ConnectionId;
        ChatGroupViewModel group = await _mediator.Send
           (new GetGroupQuery() { ConnectionId = connectionId });

    }


    public async Task SendMessageAsync
        (string sender, string message)
    {

        var connectionId = Context.ConnectionId;
        ChatGroupViewModel group =await _mediator.Send
            (new GetGroupQuery() { ConnectionId = connectionId });


        await _mediator.Send(new SendMessageCommand()
        {
            Message = new MessageDto()
            {
                ConnectionId = connectionId,
                Message = message,
                ChatGroupId = group.Id.ToString().ToLower(),
                IPAddress = GetUserIp(),
                UserType = Domain.Types.UserType.User
            }
        });
        await Clients.Groups(group.Id.ToString().ToLower()).
            SendAsync("ReceiveMessage", "user-message", message);
        if (group.CountMessage == 0)
        {
            string ip = GetUserIp();
            await Clients.All.SendAsync("NewGroup", new
            {
                ip,group.Id,group.CreateAt,
                connectionId
            });
        }


    }


    public override async Task OnConnectedAsync()
    {
        if (Context.User!.Identity!.IsAuthenticated is false)
        {
          
       
            var connectionId = Context.ConnectionId;
            var groupName = await _mediator.Send(new JoinChatGroupCommand()
            {
                ChatGroup = new ChatGroupDto()
                {
                    ConnectionId = connectionId,
                    IPAddress = GetUserIp()
                }
            });

            await Groups.AddToGroupAsync(connectionId, groupName);
        }
        await base.OnConnectedAsync();

    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }
}
