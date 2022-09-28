using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Data.GraphQL.Types
{
    public class PlantAdminInputType : InputObjectGraphType
    {
        public PlantAdminInputType()
        {
            base.Field<NonNullGraphType<StringGraphType>>("Name");
            base.Field<NonNullGraphType<StringGraphType>>("Email");
            base.Field<NonNullGraphType<StringGraphType>>("HashedPassword");
        }
    }
}
