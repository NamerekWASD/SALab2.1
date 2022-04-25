using DAL.Models.CommentEntity;
using DAL.Models.MediaEntity.MatchingToPlace;
using DAL.Models.PlaceEntity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DAL.Models.PersonEntity
{

    public sealed class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public AuthentificationData AuthentificationData { get; set; }
        private int status = 0;
        public bool IsManager
        {
            get
            {
                if (status is 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                status = value ? 1 : 0;
            }
        }
        public ICollection<FileContainer> FilesAttached { get; set; } = new List<FileContainer>();
        public ICollection<Comment>? LeftComments { get; set; } = new List<Comment>();
        public ICollection<Place>? VisitedPlaces { get; set; } = new List<Place>();
        [NotMapped]
        public Role PersonRole
        {
            set
            {
                if (value.GetRole == new Manager().GetRole)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
            }
        }


    }
    [NotMapped]
    public abstract class Role
    {
        private static string personRole = string.Empty;
        public string GetRole { get { return personRole; } protected set => personRole = value; }
    }
    [NotMapped, Authorize(Roles = "Manager")]
    public class Manager : Role
    {
        public Manager()
        {
            GetRole = "Manager";
        }
    }
    [NotMapped]
    public class UserWithoutPermission : Role
    {
        public UserWithoutPermission()
        {
            GetRole = "User";
        }
    }
}
