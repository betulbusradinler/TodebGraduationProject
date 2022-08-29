using System;

namespace DTO.UtilityBill
{
    public class CreateUtilityBillRequest
    {
        public string UtilityBillNo { get; set; }
        public int BillNameId { get; set; }  // Fatura tipi 
        public int FlatId { get; set; }
        public long Price { get; set; } 
    }
}
