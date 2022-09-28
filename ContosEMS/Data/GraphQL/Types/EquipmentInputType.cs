using ContosEMS.Data.Entities;
using GraphQL.Types;

namespace ContosEMS.Data.GraphQL.Types
{
    public class EquipmentInputType: InputObjectGraphType<Equipment>
    {
        public EquipmentInputType()
        {
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
