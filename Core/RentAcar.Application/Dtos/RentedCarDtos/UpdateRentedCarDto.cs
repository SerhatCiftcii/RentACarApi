﻿using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Application.RentedCarDtos
{
    public class UpdateRentedCarDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        //araç hasarlı mı aldıysa ona göre  işlem yapılacak
        public decimal DamagePrice { get; set; }
        public bool IsCompleted { get; set; }
    }
}
