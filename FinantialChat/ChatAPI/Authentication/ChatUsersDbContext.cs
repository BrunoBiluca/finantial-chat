using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Authentication {
    public class ChatUsersDbContext : IdentityDbContext<ChatUser> {
        public ChatUsersDbContext(DbContextOptions<ChatUsersDbContext> options)
        : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
        }
    }
}
