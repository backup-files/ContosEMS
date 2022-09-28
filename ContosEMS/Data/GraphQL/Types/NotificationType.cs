using ContosEMS.Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Data.GraphQL.Types
{
    public class NotificationType: ObjectGraphType<Notification>
    {
        public NotificationType()
        {
            base.Field(t => t.Id);
            base.Field(t => t.TechnicianEmail);
            base.Field(t => t.EquipmentId);
            base.Field(t => t.Title);
            base.Field(t => t.Severity);
            base.Field(t => t.Comments);
            base.Field(t => t.Timestamp);
            base.Field(t => t.Status);
        }
    }
}
