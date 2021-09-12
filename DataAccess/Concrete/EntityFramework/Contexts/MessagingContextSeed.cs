using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class MessagingContextSeed
    {
        public static async Task SeedAsync(MessagingContext messagingContext)
        {
            messagingContext.Database.Migrate();
        }
    }
}
