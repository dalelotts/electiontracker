using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Expression;
using edu.uwec.cs.cs355.group4.et.core;

namespace edu.uwec.cs.cs355.group4.et.db
{
    internal class ResponseValueDAO : HibernateDAO<ResponseValue>{

        public ResponseValueDAO(ISessionFactory factory) : base(factory) {}

        public override IList<Fault> validate(ResponseValue entity)
        {
            return makeEmptyFaultList();
        }

        public void SaveVotes(Response r, ContestCounty c, int votes)
        {
            ResponseValue rv = new ResponseValue();
            rv.Response = r;
            rv.ContestCounty = c;
            rv.VoteCount = votes;
            System.Windows.Forms.MessageBox.Show("Persisting...");
            this.makePersistent(rv);
        }
    }
}
