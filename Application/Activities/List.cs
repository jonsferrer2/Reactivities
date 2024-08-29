using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            private readonly ILogger _logger;
            public Handler(DataContext context, ILogger<List> logger)
            {
                _logger = logger;
                _context = context;

            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        _logger.LogInformation($"Task {i} completed");
                    }
                }
                catch (System.Exception)
                {
                    _logger.LogInformation("Task was cancelled");
                }
                return await _context.Activities.ToListAsync();
            }
        }
    }
}