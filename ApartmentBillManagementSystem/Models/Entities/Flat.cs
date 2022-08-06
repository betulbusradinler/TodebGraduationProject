using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Flat
    {
        [Key]
        public int Id { get; set; }
        public string No { get; set; }  // Daire No oluşturuldu 
        public int HirerId { get; set; }  // Dairede kalan kiracının id si
        public byte FloorNo { get; set; }  // Kaçıncı kat olduğu 
        public char Block { get; set; }    // Hangi blokta olduğu
        public string Type { get; set; }    // Dairenin tipi 2+1 vs
        public bool State { get; set; }  // Daire Boş mu Dolu mu

        [ForeignKey("HirerId")]   // Her dairede bir kiracı kalır
        public User Hirer { get; set; }

        public ICollection<UtilityBill> UtilityBills { get; set; }  // her dairenin birden fazla faturası olur



    }
}
