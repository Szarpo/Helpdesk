using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.CommentQuery;
using Helpdesk.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.CommentHandler;

internal class GetCommentsToTicketQueryHandler : IRequestHandler<GetCommentsToTicketQuery, PagedResult<CommentsDto>>
{
    private readonly HelpdeskDbContext _dbContext;

    public GetCommentsToTicketQueryHandler(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<PagedResult<CommentsDto>> Handle(GetCommentsToTicketQuery request, CancellationToken cancellationToken)
    {

        var commentdtos =  await _dbContext.Comments
            .OrderByDescending(x => x.CreatedAt)
            .Skip(request.PageSize * (request.PageNumber -1))
            .Take(request.PageSize)
            .AsNoTracking()
            .Where(x=> x.TicketId == request.TicketId)
            .Select(x => new CommentsDto(
                x.Id,
                x.UserId,
                x.Content,
                x.CreatedAt
                ))
            .ToListAsync(cancellationToken: cancellationToken);

        var totalCount = await _dbContext.Comments.CountAsync(cancellationToken: cancellationToken);

        return new PagedResult<CommentsDto>(commentdtos, totalCount, request.PageSize, request.PageNumber);
    }
}