namespace MVC.Models
{
    public class RequestGetAllLiveProduct
    {
        public string? Query { get; set; }

        public int? MinQuantity { get; set; }

        public int? MaxQuantity { get; set; }
    }
}