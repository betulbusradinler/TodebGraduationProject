using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public  class Bill  // Bu bir fatura kaydı ya elektrik ya su ya doğalgaz
    {
        [Key]
        public int Id { get; set; }
        public long Price { get; set; }
        public int UtilityBillType { get; set; }    
       
        public int FlatId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey("FlatId")]
        public Flat Flat { get; set; }




    }
}
