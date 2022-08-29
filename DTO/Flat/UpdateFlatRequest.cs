namespace DTO.Flat
{
    public class UpdateFlatRequest
    {
        public int Id { get; set; }
        public string No { get; set; }  // Daire No oluşturuldu 
        //public int HirerOrHostId { get; set; }  // Dairede kalan kiracının id si
        public byte FloorNo { get; set; }  // Kaçıncı kat olduğu 
        public char Block { get; set; }    // Hangi blokta olduğu
        public string Type { get; set; }    // Dairenin tipi 2+1 vs
        public bool State { get; set; }  // Daire Boş mu Dolu mu

        //public User HirerOrHost { get; set; }

        //public ICollection<UtilityBill> UtilityBills { get; set; }  // her dairenin birden fazla faturası olur


    }
}
