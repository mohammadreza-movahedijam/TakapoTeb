using MediatR;

namespace Application.Commands.Image;

public sealed record InsertImageCommand : IRequest
{
    public ImageDto? Image { get; set; }
    public InsertImageCommand(ImageDto image)
    {
        this.Image = image;
    }
}
