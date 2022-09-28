using ContosEMS.Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Data.GraphQL.Types
{
    public class TechnicianType: ObjectGraphType<Technician>
    {
        public TechnicianType()
        {
            base.Field(t => t.Email);
            base.Field(t => t.HashedPassword);
            base.Field(t => t.Name);
        }
    }
}
