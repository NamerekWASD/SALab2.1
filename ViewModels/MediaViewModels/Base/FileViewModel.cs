namespace ViewModels.MediaViewModels.Base
{
    public class FileViewModel
    {
        public int Id;
        private string _path = string.Empty;
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if (Directory.Exists(value))
                {
                    throw new FileNotFoundException();
                }
                _path = value;
            }
        }
        public string Name { get; set; }
        public string Format => new FileInfo(Path).Extension;
        public string Size => (double)(new FileInfo(Path).Length * 1024 * 1024 / 1048576) + "Mb";
        public string UserWhoAttached;
        public PlaceViewModel PlaceWhereAttached;
        public override string ToString()
        {
            return $"  Name: {Name}" +
                $"\n  Format: {Format}" +
                $"\n  Size: {Size}";

        }
    }
}
