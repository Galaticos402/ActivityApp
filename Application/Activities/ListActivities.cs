using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class ListActivities
    {
        public class Query: IRequest<List<Activity>> { }
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext context;
            private readonly ILogger<ListActivities> logger;

            public Handler(DataContext context, ILogger<ListActivities> logger)
            {
                this.context = context;
                this.logger = logger;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    //for(int i=0; i<10; i++)
                    //{
                    //    cancellationToken.ThrowIfCancellationRequested();
                    //    await Task.Delay(1000,cancellationToken);
                    //    logger.LogInformation($"Task {i} has completed");
                    //}
                    var activities = await context.Activities.ToListAsync(cancellationToken);
                    return activities;
                }
                catch(Exception ex) when (ex is TaskCanceledException)
                {
                    logger.LogInformation("Request cancelled");
                }
                return null;
                
            }
        }
    }
}
