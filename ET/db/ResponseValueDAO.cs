using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ResponseValueDAO : HibernateDAO<ResponseValue> {
        public ResponseValueDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(ResponseValue entity)
        {
            IList<Fault> retVal = new List<Fault>();

            if (entity == null)
            {
                retVal.Add(new Fault(true, "ResponseValue is null."));
            }
            else
            {
                if (entity.ContestCounty == null)
                {
                    retVal.Add(new Fault(true, "ContestCounty in ResponseValue is null."));
                }

                if (entity.Response == null)
                {
                    retVal.Add(new Fault(true, "Response in ResponseValue is null."));
                }

            }

            
            

            return retVal;
        }


        public IList<ResponseValue> find(long responseID, long contestCountyID) {
            IQuery query =
                getCurrentSession().CreateSQLQuery("select * from responsevalue where ResponseID = " + responseID +
                                                   " and ContestCountyID = " + contestCountyID + ";").AddEntity(objectType);
            return query.List<ResponseValue>();
        }
    }
}