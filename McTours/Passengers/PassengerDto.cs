﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Passengers
{
    public class PassengerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public Gender Gender { get; set; }

        public string GenderName 
        { 
            get
            {
                return EnumHelper.GenderNames.ContainsKey(Gender)
                    ? EnumHelper.GenderNames[Gender]
                    : string.Empty;
            }
        }
        public DateTime DateOfBirth { get; set; }
    }
}

