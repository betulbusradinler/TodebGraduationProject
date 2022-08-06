using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Flat
    {
        // Hangi blokda - Durumu (Dolu-boş) - Tipi (2+1 vb.) - Bulunduğu kat - Daire numarası - Daire sahibi veya kiracı

        public int Id { get; set; }
        public string No { get; set; }       
        public int OwnerShipFlatId { get; set; }
        public string Floor { get; set; }
        public char Block { get; set; }
        public string Type { get; set; }
        public bool State { get; set; }

        [ForeignKey("OwnerShipFlatId")]
        public User OwnershipFlatOrHirer { get; set; }


    }
}
