using Models.Entities;
using System.Collections.Generic;

namespace DTO.Flat
{
    public class CreateFlatRegisterRequest
    {
        public int No { get; set; }  // Daire No oluşturuldu 
        public byte FloorNo { get; set; }  // Kaçıncı kat olduğu 
        public char Block { get; set; }    // Hangi blokta olduğu
        public string Type { get; set; }    // Dairenin tipi 2+1 vs
        public bool State { get; set; }  // Daire Boş mu Dolu mu

    }
}
