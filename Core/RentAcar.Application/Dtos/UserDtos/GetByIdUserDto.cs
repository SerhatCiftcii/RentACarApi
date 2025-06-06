﻿using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Application.Dtos.UserDtos
{
    public class GetByIdUserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        //rentedcarsmodelinden sonra object kısmı değişicek
        public List<RentedCar> RentedCars { get; set; }
    }
}
