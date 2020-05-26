namespace FortBot2.Config.Models
{
    /*public class FNItemDTO
    {
        public double cost { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string iconUrl { get; set; }
    }*/


    public class Rootobject
    {
        public int lastUpdate { get; set; }
        public string lanuage { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public string itemId { get; set; }
        public int lastUpdate { get; set; }
        public Store store { get; set; }
        public Item item { get; set; }
    }

    public class Store
    {
        public bool isFeatured { get; set; }
        public bool isRefundable { get; set; }
        public int cost { get; set; }
        public int occurrences { get; set; }
        public bool isNew { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public string costmeticId { get; set; }
        public Images images { get; set; }
        public Backpack backpack { get; set; }
        public string obtained_type { get; set; }
        public Ratings ratings { get; set; }
    }

    public class Images
    {
        public string icon { get; set; }
        public string featured { get; set; }
        public string background { get; set; }
        public string information { get; set; }
    }

    public class Backpack
    {
    }

    public class Ratings
    {
        public float avgStars { get; set; }
        public int totalPoints { get; set; }
        public int numberVotes { get; set; }
    }

}
