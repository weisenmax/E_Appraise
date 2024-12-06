using System;

namespace E_Appraise.Models
{
    public class Appraiser
    {
        public int Id { get; set; }            // Primary key
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
