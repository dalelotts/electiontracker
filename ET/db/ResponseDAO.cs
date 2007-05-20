using System.Collections;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ResponseDAO : HibernateDAO<Response> {
        public ResponseDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(Response entity)
        {
            IList<Fault> retVal = new List<Fault>();

            return retVal;
        }

        public void Delete(Response r)
        {
            //System.Windows.Forms.MessageBox.Show(r.ToString());
            // Hack - To get the query to be executed, I had to have it return something,
            //  even if completely arbitrary.  I'm sure there's a better way, but this
            //  is the only way I knew of and I was running out of time.
            IQuery iqQuery = getCurrentSession().CreateSQLQuery("delete from customresponse where responseid = " + r.ID + "; select * from county;").AddEntity(typeof(County));
            IList x = iqQuery.List();
            iqQuery = getCurrentSession().CreateSQLQuery("delete from candidateresponse where responseid = " + r.ID + "; select * from county;").AddEntity(typeof(County));
            iqQuery.List();

            iqQuery = getCurrentSession().CreateSQLQuery("delete from responsevalue where responseid = " + r.ID + "; select * from county;").AddEntity(typeof(County));
            iqQuery.List();
            // do this one last due to dependencies.
            iqQuery = getCurrentSession().CreateSQLQuery("delete from response where responseid = " + r.ID + "; select * from county;").AddEntity(typeof(County));
            iqQuery.List();

        }
    }
}