using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface ICommentRepository
    {
        Task<ICollection<Comment>> GetAllComment();

        Task<Comment> GetCommentById(Guid commentId);

        Task<Comment> CreateComment(Comment toCreate);

        Task<Comment> UpdateComment(Comment toUpdate);

        Task DeleteComment(Guid commentId);
    }
}
