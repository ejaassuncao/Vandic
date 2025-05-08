using Microsoft.EntityFrameworkCore;
using Vandic.CrossCutting.Meditor.Interfaces;
using Vandic.Domain.Abstracts;

namespace Vandic.Data.efcore.Context
{
    public partial class AppDbContext : DbContext
    {
        private readonly ICommandDispatcher _dispacher;

        public AppDbContext(DbContextOptions<AppDbContext> options, ICommandDispatcher dispacher) : base(options)
        {
            this._dispacher = dispacher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .SelectMany(x => x.Entity.GetDomainEvents())
                .ToList();

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _dispacher.PublishAsync((INotification)domainEvent, cancellationToken);
            }

            // Limpa os eventos depois de publicar
            ChangeTracker.Entries<AggregateRoot>()
                .ToList()
                .ForEach(e => e.Entity.ClearDomainEvents());

            return result;
        }

    }
}
