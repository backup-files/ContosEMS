using ContosEMS.Data.GraphQL;
using GraphQL.Types;
using System;

namespace WebApplicationToo.Data.GraphQL
{

    public class EMSSchema : Schema
    {
        public EMSSchema(IServiceProvider resolver) : base(resolver)
        {
            Query = (IObjectGraphType)resolver.GetService(typeof(EMSQuery));
            Mutation = (IObjectGraphType)resolver.GetService(typeof(EMSMutation));
        }
    }
}