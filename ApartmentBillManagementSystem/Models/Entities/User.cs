using System;

namespace Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string No { get; set; }
        public string Email { get; set; }
        public string VehicleNo { get; set; }
        public string Phone { get; set; }
        public DateTime Created { get; set; }

    }
}
