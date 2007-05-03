using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ResponseValueDAO : HibernateDAO<ResponseValue> {
        public ResponseValueDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(ResponseValue entity)
        {
            return makeEmptyFaultList();
        }


        public IList<ResponseValue> find(long responseID, long contestCountyID) {
            IQuery query =
                getCurrentSession().CreateSQLQuery("select * from responsevalue where ResponseID = " + responseID +
                                                   " and ContestCountyID = " + contestCountyID + ";").AddEntity(objectType);
            return query.List<ResponseValue>();
        }
    }
}