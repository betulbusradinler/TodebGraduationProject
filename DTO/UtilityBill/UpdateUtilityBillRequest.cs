using System;

namespace DTO.UtilityBill
{
    public class UpdateUtilityBillRequest
    {

        public string UtilityBillNo { get; set; }
        public int FlatId { get; set; }
        public int BillNameId { get; set; }  // Fatura tipi 
        public long Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
