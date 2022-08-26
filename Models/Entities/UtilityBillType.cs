using System.ComponentModel.DataAnnotations;
namespace Models.Entities
{
    public class UtilityBillType
    {
        public int Id { get; set; }

        public string Name { get; set; }
        //public int UtilityBillId { get; set; }
        
        //[ForeignKey("UtilityBillId")]  //Fatura Tipi
        //public UtilityBill UtilityBill { get; set; }
    }
}
