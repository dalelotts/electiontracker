using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ResponseDAO : HibernateDAO<Response> {
        public ResponseDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(Response entity)
        {
            IList<Fault> retVal = new List<Fault>();

            if (entity == null)
            {
                retVal.Add(new Fault(true, "Response is null."));
            }
            else
            {
                if (entity.ElectionContest == null)
                {
                    retVal.Add(new Fault(true, "ElectionContest in Response is null."));
                }

            }




            return retVal;
        }
    }
}