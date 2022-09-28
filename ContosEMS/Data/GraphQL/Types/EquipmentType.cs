using ContosEMS.Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Data.GraphQL.Types
{
    public class EquipmentType: ObjectGraphType<Equipment>
    {
        public EquipmentType()
        {
            base.Field(t => t.Id);
            base.Field(t => t.Name);
            base.Field(t => t.Description);
            base.Field(t => t.InstalledDate);
            base.Field(t => t.ServiceDueDate);
            base.Field(t => t.Manufacturer);
            base.Field(t => t.Model);
            base.Field(t => t.Temperature);
            base.Field(t => t.AngularVelocity);
            base.Field(t => t.Pressure);
            base.Field(t => t.Type);
            base.Field(t => t.ImageLink);
        }
    }
}
