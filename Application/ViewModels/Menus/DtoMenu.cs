namespace Application.ViewModels
{
    public class DtoMenu
    {
        public int MenuID { get; set; }

        public int ParentID { get; set; }

        public string MenuType { get; set; }

        public string Title { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Remarks { get; set; }
    }
}
