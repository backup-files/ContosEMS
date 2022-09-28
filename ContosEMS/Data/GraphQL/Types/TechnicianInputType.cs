using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Data.GraphQL.Types
{
    public class TechnicianInputType: InputObjectGraphType
    {
        public TechnicianInputType()
        {
            Name = "TechnicianInput";
            base.Field<NonNullGraphType<StringGraphType>>("Email");
            base.Field<NonNullGraphType<StringGraphType>>("HashedPassword");
        }
    }
}
