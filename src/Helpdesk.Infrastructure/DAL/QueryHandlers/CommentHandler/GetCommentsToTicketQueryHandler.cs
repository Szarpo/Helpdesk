using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.CommentQuery;
using Helpdesk.Infrastructure.DAL.QueryHandlers.AsDto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.CommentHandler;

internal class GetCommentsToTicketQueryHandler : IRequestHandler<GetCommentsToTicketQuery, IEnumerable<CommentsDto>>
{
    private readonly HelpdeskDbContext _dbContext;

    public GetCommentsToTicketQueryHandler(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<CommentsDto>> Handle(GetCommentsToTicketQuery request, CancellationToken cancellationToken)
    {

        var comments =  _dbContext.Comments.AsNoTracking().Where(x=> x.TicketId == request.TicketId).Select(x => x.CommentsByTicketId());

        return await comments.ToListAsync(cancellationToken: cancellationToken);
    }
}