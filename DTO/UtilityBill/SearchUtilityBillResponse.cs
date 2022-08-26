using System;

namespace DTO.UtilityBill
{
    public class SearchUtilityBillResponse
    {
        public string UtilityBillNo { get; set; }
        public int BillNameId { get; set; }  // Fatura tipi 
        public int FlatId { get; set; }
        public long Price { get; set; } // Fatura ücreti 
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
