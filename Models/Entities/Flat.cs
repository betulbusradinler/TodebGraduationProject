using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Flat
    {
        [Key]
        public int Id { get; set; }
        public int No { get; set; }  // Daire No oluşturuldu        
        public byte FloorNo { get; set; }  // Kaçıncı kat olduğu 
        public char Block { get; set; }    // Hangi blokta olduğu
        public string Type { get; set; }    // Dairenin tipi 2+1 vs
        public bool State { get; set; }  // Daire Boş mu Dolu mu
        public User HirerOrHost { get; set; }
        public ICollection<UtilityBill> UtilityBills { get; set; }  // her dairenin birden fazla faturası olur

    }
}
