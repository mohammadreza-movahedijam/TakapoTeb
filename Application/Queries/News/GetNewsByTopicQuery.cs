using Domain.Types;
using MediatR;


namespace Application.Queries.News;

public sealed record GetNewsByTopicQuery:
    IRequest<ValueTuple<IReadOnlyList<NewsViewModel>,int,int>>
{
    public TopicType TopicType { get; set; }
    public int part {  get; set; }
}
