using Models.Entities;
using System;

namespace DTO.UtilityBill
{
    public class UpdateUtilityBillRequest
    {

        public int Id { get; set; }
        public int FlatId { get; set; }
        public long Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Models.Entities.Flat Flat { get; set; }
        public Models.Entities.UtilityBillType BillType { get; set; }
    }
}
