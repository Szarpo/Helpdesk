using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.TicketQuery;
using Helpdesk.Core.Exceptions;
using Helpdesk.Core.Models;
using Helpdesk.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.TicketHandler;

internal sealed class GetTicketsAuthorizeUserQueryHandler : IRequestHandler<GetTicketsAuthorizeUserQuery, PagedResult<TicketsDto>>
{

    private readonly ITicketRepository _ticketRepository;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly HelpdeskDbContext _dbContext;

    public GetTicketsAuthorizeUserQueryHandler(ITicketRepository ticketRepository, IHttpContextAccessor contextAccessor, HelpdeskDbContext dbContext)
    {
        _ticketRepository = ticketRepository;
        _contextAccessor = contextAccessor;
        _dbContext = dbContext;
    }
    
    public async Task<PagedResult<TicketsDto>> Handle(GetTicketsAuthorizeUserQuery request, CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext!.User.Identity!.Name is null)
        {
            throw new InvalidCastException();
        }

        var authorizeUserId = Guid.Parse(_contextAccessor.HttpContext.User.Identity.Name);

        var isExist = await _ticketRepository.IsExistUserId(authorizeUserId);

        if (!isExist)
        {
            throw new IdNotExist($"User: {authorizeUserId}");
        }
        
        var (pageSize, pageNumber) = request;

        var ticketDto = await _dbContext.Tickets
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .Where(x => x.CreatorId == authorizeUserId)
            .Select(x => new TicketsDto(
                x.Id, x.CreatorId, x.Title, x.Content, x.Category, x.TicketStatus, x.State, x.CreatedAt, x.ClosedAt
            ))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var totalCount = await _dbContext.Tickets.CountAsync(cancellationToken: cancellationToken);

        return new PagedResult<TicketsDto>(ticketDto, totalCount, pageSize, pageNumber);

    }
}