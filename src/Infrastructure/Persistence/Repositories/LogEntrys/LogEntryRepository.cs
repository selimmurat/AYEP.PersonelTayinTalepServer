using Domain.Entities;
using Domain.Repositories.LogEntrys;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.LogEntrys
{
    public class LogEntryRepository(AppDbContext context) : BaseRepository<LogEntry>(context), ILogEntryRepository
    {
    }
}
