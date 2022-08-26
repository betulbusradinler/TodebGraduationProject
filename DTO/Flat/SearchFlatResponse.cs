using Models.Entities;
using System.Collections.Generic;

namespace DTO.User
{
    public class SearchFlatResponse
    {
        public int Id { get; set; }
        public byte No { get; set; }  
       // public int HirerOrHostId { get; set; }  
        public byte FloorNo { get; set; }
        public char Block { get; set; } 
        public string Type { get; set; }  
        public bool State { get; set; } 

        //public User HirerOrHost { get; set; }

       // public ICollection<UtilityBill> UtilityBills { get; set; }  // her dairenin birden fazla faturası olur

    }
}
