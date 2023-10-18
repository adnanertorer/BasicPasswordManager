using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.Accounts.Queries.GetById
{
    public class AccountDto
    {
        public long UserId { get; set; }
        public string AccountTitle { get; set; }
        public long? CategoryId { get; set; }
        public string AccountUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
