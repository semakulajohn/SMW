using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.BAL.Interface
{
   public interface ICommentService
    {
        IEnumerable<Comment> GetAllComments();
        Comment GetComment(long commentId);
        long SaveComment(Comment comment, string userId);
        void MarkAsDeleted(long commentId, string userId);
    }
}
