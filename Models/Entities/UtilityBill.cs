using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class UtilityBill
    {
        [Key]
        public int Id { get; set; }
        public string UtilityBillNo { get; set; }
        public int BillNameId { get; set; }  // Fatura tipi 
        public int FlatId { get; set; }
        public long Price { get; set; } // Fatura ücreti 
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        
        [ForeignKey("FlatId")]
        public Flat Flat { get; set; }  // Faturanın ait olduğu daire.

        [ForeignKey("BillNameId")]  //Fatura Tipi
        public UtilityBillType BillType { get; set; }

    }
}
