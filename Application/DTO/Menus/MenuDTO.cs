namespace Application.DTO
{
    public class MenuDTO
    {
        public int MenuID { get; set; }

        public int ParentId { get; set; }

        public string MenuType { get; set; }

        public string Title { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Remarks { get; set; }
    }
}
