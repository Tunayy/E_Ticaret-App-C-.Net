namespace E_Commerce.Entities
{
    public class Images
    {
        public int Id { get; set; }

        public bool Status { get; set; }
        public string Url { get; set; }

        public int ProductsId { get; set; }
        public String Products { get; set; }

    }

    public class ImagesRequestModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Products { get; set; }
       
    }

    public class ImagesUpdateRequestModel
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public string Products { get; set; }


    }
}
