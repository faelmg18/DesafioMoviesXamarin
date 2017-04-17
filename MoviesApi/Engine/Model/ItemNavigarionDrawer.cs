namespace MoviesApi.Engine.Model
{
    public class ItemNavigarionDrawer
    {

        public ItemNavigarionDrawer(bool isHeaderMenu, string nameUser, string pathImageUser)
        {
            IsHeaderMenu = isHeaderMenu;
            NameUser = nameUser;
            PathImageUser = pathImageUser;
        }

        public ItemNavigarionDrawer(bool isHeaderMenu, string nameUser)
        {
            IsHeaderMenu = isHeaderMenu;
            NameUser = nameUser;
        }

        public ItemNavigarionDrawer(bool isHeaderMenu)
        {
            IsHeaderMenu = isHeaderMenu;
        }

        public ItemNavigarionDrawer(int id, int imageResource, string nameTitleMenu, bool isHeaderMenu = false)
        {
            Id = id;
            ImageResource = imageResource;
            NameTitleMenu = nameTitleMenu;
            IsHeaderMenu = isHeaderMenu;

        }

        public int Id { get; set; }
        public int ImageResource { get; set; }

        public string NameTitleMenu { get; set; }

        public bool IsHeaderMenu { get; set; }

        public string NameUser { get; set; }

        public string PathImageUser { get; set; }

    }
}