﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMW.EF.Models;
using SMW.DAL.Concrete;
using SMW.DAL.Interface;
using SMW.EF.UnitOfWork;
using SMW.DTO;
using log4net;

namespace SMW.DAL.Concrete
{
  public  class CommentDataService : DataServiceBase,ICommentDataService
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(CommentDataService));

       public CommentDataService(IUnitOfWork<SMWEntities> unitOfWork)
            : base(unitOfWork)
        {

        }

      
        public IEnumerable<Comment> GetAllComments()
        {
            return this.UnitOfWork.Get<Comment>().AsQueryable().Where(e => e.Deleted == false); 
        }

        public Comment GetComment(long commentId)
        {
            return this.UnitOfWork.Get<Comment>().AsQueryable()
                 .FirstOrDefault(c =>
                    c.CommentId == commentId &&
                    c.Deleted == false
                );
        }

        /// <summary>
        /// Saves a new Comment or updates an already existing Comment.
        /// </summary>
        /// <param name="Comment">Comment to be saved or updated.</param>
        /// <param name="CommentId">CommentId of the Comment creating or updating</param>
        /// <returns>CommentId</returns>
        public long SaveComment(CommentDTO commentDTO, string userId)
        {
            long commentId = 0;
            
            if (commentDTO.CommentId == 0)
            {
           
                var comment = new Comment()
                {
                   
                    Body = commentDTO.Body, 
                    MediaId = commentDTO.MediaId,
                    CreatedOn = DateTime.Now,
                    Timestamp = DateTime.Now,
                    CreatedBy = userId,
                    Deleted = false,
 

                };

                this.UnitOfWork.Get<Comment>().AddNew(comment);
                this.UnitOfWork.SaveChanges();
                commentId = comment.CommentId;
                return commentId;
            }

            else
            {
                var result = this.UnitOfWork.Get<Comment>().AsQueryable()
                    .FirstOrDefault(e => e.CommentId == commentDTO.CommentId);
                if (result != null)
                {
                    result.Body= commentDTO.Body;
                    result.MediaId = commentDTO.MediaId;
                    result.Timestamp = DateTime.Now;
                    result.Deleted = commentDTO.Deleted;
                    result.DeletedBy = commentDTO.DeletedBy;
                    result.DeletedOn = commentDTO.DeletedOn;
 
                    this.UnitOfWork.Get<Comment>().Update(result);
                    this.UnitOfWork.SaveChanges();
                }
                return commentDTO.CommentId;
            }
            return commentId;
        }

        public void MarkAsDeleted(long commentId,string userId)
        {
            var result = this.UnitOfWork.Get<Comment>().AsQueryable().Where(e => e.Deleted == false && e.CommentId == commentId);
            if (result != null)
            {
                
            }
            //using (var dbContext = new SMWEntities())
            //{
            //    dbContext.Mark_Comment_And_RelatedData_AsDeleted(CommentId, userId);
            //}      

        }
    }
}
