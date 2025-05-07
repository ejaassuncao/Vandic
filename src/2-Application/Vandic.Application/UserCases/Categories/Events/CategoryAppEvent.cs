using Vandic.Application.Interfaces;

namespace Vandic.Application.UserCases.Categories.Events
{
    public class CategoryAppEvent
    {

        public class NotifyUpdatedAppEvent : IApplicationEvent
        {
            public NotifyUpdatedAppEvent(Guid id, string v)
            {
                Id = id;
                V = v;
            }

            public Guid Id { get; }
            public string V { get; }
        }

        public class SendUpdatedEmailEvent : IApplicationEvent
        {
            private Guid id;
            private string name;

            public SendUpdatedEmailEvent(Guid id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }
    }
}
