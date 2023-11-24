using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Domain.Entities;
using StrayHome.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly StrayHomeContext _context;

        public CommentRepository(StrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateComment(Comment toCreate)
        {
            _context.Comments.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteComment(Guid commentId)
        {
            var hopItem = _context.Comments
                .FirstOrDefault(p => p.ID == commentId);

            if (hopItem is null) return;

            _context.Comments.Remove(hopItem);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Comment>> GetAllComment()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetCommentById(Guid commentId)
        {
            return await _context.Comments.FirstAsync(p => p.ID == commentId);
        }

        public async Task<Comment> UpdateComment(Comment toCreate)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(p => p.ID == toCreate.ID);
            comment.Text = toCreate.Text;
            comment.CreationDate = toCreate.CreationDate;
            comment.UserID = toCreate.UserID;
            comment.ShelterID = toCreate.ShelterID;
            await _context.SaveChangesAsync();

            return comment;
        }
    }
}
