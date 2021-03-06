using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            

            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);
                if(activity == null)
                {
                    throw new Exception("Cannot find Activity");
                }
                context.Remove(activity);
                var success = await context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                else
                {
                    throw new Exception("Error Delete an Activity");
                }
            }
        }
    }
}
