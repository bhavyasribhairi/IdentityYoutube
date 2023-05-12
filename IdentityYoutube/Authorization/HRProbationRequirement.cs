using Microsoft.AspNetCore.Authorization;

namespace IdentityYoutube.Authorization
{
    public class HRProbationRequirement : IAuthorizationRequirement
    {
        public int probationMonths { get; }

        public HRProbationRequirement(int probationMonths)
        {
            this.probationMonths = probationMonths;
        }
    }

    public class HRProbationRequirementHandler : AuthorizationHandler<HRProbationRequirement>
    {


        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRProbationRequirement requirement)
        {
            if(!context.User.HasClaim(x=> x.Type== "EmploymentDate"))
            {
                return Task.CompletedTask;
            }
            var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmploymentDate").Value);
            var period = DateTime.Now - empDate;
            if(period.Days > 30 * requirement.probationMonths)
                context.Succeed(requirement);
            return Task.CompletedTask;
            
                    
        }
    }
}
