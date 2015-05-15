using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys.RGA
{
    public class RMAComment
    {
         public RMAComment() {

       }

     
       public Guid? UserID { get; set; }
       public Guid? ReturnID { get; set; }
       public DateTime CommentDate { get; set; }
       public String Comment { get; set; }
       public Guid RMACommentID  { get; set; }
      
       public RMAComment(GetRGAService.RMACommentDTO _commentDTO)
       {
           if (_commentDTO.UserID != null) this.UserID = _commentDTO.UserID;
           if (_commentDTO.ReturnID != null) this.ReturnID = _commentDTO.ReturnID;
           if (_commentDTO.Comment != null) this.Comment = _commentDTO.Comment;
           if (_commentDTO.CommentDate != null) this.CommentDate = (DateTime)_commentDTO.CommentDate;
           if (_commentDTO.RMACommentID != null) this.RMACommentID = _commentDTO.RMACommentID;
          
       }

       public RMAComment(SetRGAService.RMACommentDTO _commentDTO)
       {
           if (_commentDTO.UserID != null) this.UserID = _commentDTO.UserID;
           if (_commentDTO.ReturnID != null) this.ReturnID = _commentDTO.ReturnID;
           if (_commentDTO.Comment != null) this.Comment = _commentDTO.Comment;
           if (_commentDTO.CommentDate != null) this.CommentDate = (DateTime)_commentDTO.CommentDate;
           if (_commentDTO.RMACommentID != null) this.RMACommentID = _commentDTO.RMACommentID;
          
       }

       public SetRGAService.RMACommentDTO ConvertTOSaveDTO(RMAComment _commentDTO)
       {
           SetRGAService.RMACommentDTO _DTO = new SetRGAService.RMACommentDTO();
           if (_commentDTO.UserID != null) _DTO.UserID = _commentDTO.UserID;
           if (_commentDTO.ReturnID != null) _DTO.ReturnID = _commentDTO.ReturnID;
           if (_commentDTO.Comment != null) _DTO.Comment = _commentDTO.Comment;
           if (_commentDTO.CommentDate != null) _DTO.CommentDate = (DateTime)_commentDTO.CommentDate;
           if (_commentDTO.RMACommentID != null) _DTO.RMACommentID = _commentDTO.RMACommentID;
           return _DTO;
       }

       public GetRGAService.RMACommentDTO ConvertTOGetDTO(RMAComment _commentDTO)
       {
           GetRGAService.RMACommentDTO _DTO = new GetRGAService.RMACommentDTO();
           if (_commentDTO.UserID != null) _DTO.UserID = _commentDTO.UserID;
           if (_commentDTO.ReturnID != null) _DTO.ReturnID = _commentDTO.ReturnID;
           if (_commentDTO.Comment != null) _DTO.Comment = _commentDTO.Comment;
           if (_commentDTO.CommentDate != null) _DTO.CommentDate = (DateTime)_commentDTO.CommentDate;
           if (_commentDTO.RMACommentID != null) _DTO.RMACommentID = _commentDTO.RMACommentID;
           return _DTO;

       }
    }
}
