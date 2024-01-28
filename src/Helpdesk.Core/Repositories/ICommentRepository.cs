using Helpdesk.Core.Entities;

namespace Helpdesk.Core.Repositories;

public interface ICommentRepository
{
    Task Add(Comment comment);
   
}