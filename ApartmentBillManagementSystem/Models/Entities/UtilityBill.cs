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
        public int BillNameId { get; set; }  // Fatura tipi 
       // public string No { get; set; }  // Fatura No gerek var mı bilmiyorum ? 
        public long Price { get; set; } // Fatura ücreti 
        public DateTime CreatedDate { get; set; } // Oluşturulma Tarihi
        public DateTime ExpiryDate { get; set; }  // Son ödeme Tarihi
        
        [ForeignKey("FlatId")]
        public Flat Flat { get; set; }  // Faturanın ait olduğu daire. Her fatura yeni bir fatura kaydı demek aynı fatura tutarı 2 daireye birden gelemez.

        [ForeignKey("BillNameId")]  //Fatura
        public UtilityBillType BillType { get; set; }

    }
}
