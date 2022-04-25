using DAL.Models.MediaEntity.Base;

namespace DAL.Models.MediaEntity
{
    public class Photo : FileBase
    {
        public Photo(string path) : base(path)
        {
        }
    }
}
