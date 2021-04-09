using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Core.Entities;

namespace Entities.DTOs
{
    public class PasswordForVerifyDto: IDto
    {
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
