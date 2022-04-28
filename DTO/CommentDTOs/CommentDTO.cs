using DTO.PlaceDTOs;
using DTO.UserDTOs;

namespace DTO.CommentDTOs
{
    public class CommentDTO
    {
        public virtual List<CommentDTO>? Replies { get; set; }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int UserWhoLeftId { get; set; }
        public virtual UserProfileDTO UserWhoLeft { get; set; }
        public int PlaceWhereLeftId { get; set; }
        public virtual PlaceDTO PlaceWhereLeft { get; set; }
        public string Content { get; set; }
        public int CommentOnRepliedId { get; set; }
        public void Add(CommentDTO comment)
        {
            Replies.Add(comment);
        }

        public void Remove(CommentDTO comment)
        {
            Replies.Remove(comment);
        }
    }
    /*public class CommentDTO : CommentBaseDTO
    {
        public virtual List<CommentDTO>? Replies { get; set; }
        public override void Add(CommentBaseDTO comment)
        {
            this.Replies.Add((ReplyDTO)comment);
        }

        public override void Remove(CommentBaseDTO comment)
        {
            this.Replies.Remove((ReplyDTO)comment);
        }
    }
    public class ReplyDTO : CommentBaseDTO
    {
        public int CommentOnRepliedId { get; set; }
        public CommentBaseDTO CommentOnReplied { get; set; }
        public override bool IsComposite()
        {
            return false;
        }
    }
    public abstract class CommentBaseDTO
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int UserWhoLeftId { get; set; }
        public virtual UserProfileDTO UserWhoLeft { get; set; }
        public int PlaceWhereLeftId { get; set; }
        public virtual PlaceDTO PlaceWhereLeft { get; set; }
        public string Content { get; set; }
        public int CommentOnRepliedId { get; set; }
        public virtual void Add(CommentBaseDTO component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(CommentBaseDTO component)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsComposite()
        {
            return true;
        }
    }*/
}
