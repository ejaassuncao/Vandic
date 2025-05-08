using Vandic.Application.Interfaces;
using Vandic.Domain.Enums;

namespace Vandic.Application.UserCases.Categories.Events
{
    public class CategoryAppEvent
    {       

        public class NotifyLogAppEvent : IApplicationEvent
        {            
            public Guid Id { get; }
            public string ModifiedBy { get; }

            public EnumStatus Status { get; }
                       
            public NotifyLogAppEvent(Guid id, string modifiedBy, EnumStatus status)
            {
                Id = id;
                ModifiedBy = modifiedBy;
                Status = status;
            }            
        }

        public class SendEmailEvent : IApplicationEvent
        {
            private Guid id;
            private string name;

            public SendEmailEvent(Guid id, string name)
            {
                this.id = id;
                this.name = name;
            }
            public SendEmailEvent()
            {
                
            }
        }
    }
}
