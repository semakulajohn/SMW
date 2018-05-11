using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMW.DTO;
using SMW.BAL.Interface;
using SMW.DAL.Interface;
using SMW.Models;
using SMW.Helpers;
using log4net;

namespace SMW.BAL.Concrete
{
 public   class CommentService : ICommentService
    {
         ILog logger = log4net.LogManager.GetLogger(typeof(CommentService));
        private ICommentDataService _dataService;
        private IUserService _userService;
       
        

        public CommentService(ICommentDataService dataService,IUserService userService)
        {
            this._dataService = dataService;
            this._userService = userService;
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CommentId"></param>
        /// <returns></returns>
        public Comment GetComment(long commentId)
        {
            var result = this._dataService.GetComment(commentId);
            return MapEFToModel(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Comment> GetAllComments()
        {
            var results = this._dataService.GetAllComments();
            return MapEFToModel(results);
        } 

       
        public long SaveComment(Comment comment, string userId)
        {
            var commentDTO = new DTO.CommentDTO()
            {
                CommentId = comment.CommentId,
                Body = comment.Body,
                MediaId = comment.MediaId,               

            };

           var commentId = this._dataService.SaveComment(commentDTO, userId);

           return commentId;
                      
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CommentId"></param>
        /// <param name="userId"></param>
        public void MarkAsDeleted(long commentId, string userId)
        {
            _dataService.MarkAsDeleted(commentId, userId);
        }

      
        #region Mapping Methods

        private IEnumerable<Comment> MapEFToModel(IEnumerable<EF.Models.Comment> data)
        {
            var list = new List<Comment>();
            foreach (var result in data)
            {
                list.Add(MapEFToModel(result));
            }
            return list;
        }

        /// <summary>
        /// Maps Comment EF object to Comment Model Object and
        /// returns the Comment model object.
        /// </summary>
        /// <param name="result">EF Comment object to be mapped.</param>
        /// <returns>Comment Model Object.</returns>
        public Comment MapEFToModel(EF.Models.Comment data)
        {
          
            var Comment = new Comment()
            {
                CommentId = data.CommentId,
                Body = data.Body,
                MediaId = data.MediaId,
                CreatedOn = data.CreatedOn,
                Timestamp = data.Timestamp,
                CreatedBy = _userService.GetUserFullName(data.AspNetUser),
                UpdatedBy = _userService.GetUserFullName(data.AspNetUser1),
               

            };
            return Comment;
        }



       #endregion
    }
}
