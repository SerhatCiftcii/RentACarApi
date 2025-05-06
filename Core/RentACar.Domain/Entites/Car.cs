using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entites
{
    public class Car
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int KM { get; set; }
        //otomatik mi manuel mi
        public string Type { get; set; }
        //yakıt tipi benzin mazot hibrit elektrik gibi
        public string Fuel { get; set; }
        public decimal DailyPrice { get; set; }
        public bool IsAvailable { get; set; }


    }
}
