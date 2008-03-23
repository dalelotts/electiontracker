/**
 *  Copyright (C) 2007 Knight Rider Consulting, Inc.
 *  support@knightrider.com
 *  http://www.knightrider.com
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see http://www.gnu.org/licenses/
 **/
using System;
using System.Collections.Generic;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db.task;
using NHibernate;
using NHibernate.Expression;
using Spring.Data.NHibernate.Generic;
using Spring.Transaction.Interceptor;

namespace KnightRider.ElectionTracker.db {
    public class CountyDAO : ICountyDAO {
        private static readonly IList<Order> ORDER_BY_NAME = new List<Order>();
        private static readonly Type objectType = typeof (County);

        static CountyDAO() {
            ORDER_BY_NAME.Add(new Order("Name", true));
        }

        private readonly DelegateDAO<County> delegateDAO;
        private readonly DelegateDAO<CountyPhoneNumber> countyPhoneNumberDAO;
        private readonly DelegateDAO<CountyAttribute> countyAttributeDAO;
        private readonly DelegateDAO<CountyWebsite> countyWebsiteDAO;
        private readonly DelegateDAO<PhoneNumberType> phoneNumberTypeDAO;
        private readonly DelegateDAO<AttributeType> attributeTypeDAO;

        public CountyDAO(HibernateTemplate factory) {
            delegateDAO = new DelegateDAO<County>(factory);
            countyPhoneNumberDAO = new DelegateDAO<CountyPhoneNumber>(factory);
            countyAttributeDAO = new DelegateDAO<CountyAttribute>(factory);
            countyWebsiteDAO = new DelegateDAO<CountyWebsite>(factory);
            attributeTypeDAO = new DelegateDAO<AttributeType>(factory);
            phoneNumberTypeDAO = new DelegateDAO<PhoneNumberType>(factory);
        }

        [Transaction(ReadOnly = true)]
        public IList<County> findAll(params IDAOTask<County>[] tasks) {
            return delegateDAO.findByCriteria(DelegateDAO<County>.EMPTY_CRITERION, ORDER_BY_NAME, tasks);
        }

        public IList<AttributeType> findAllAttributeTypes(params IDAOTask<AttributeType>[] tasks)
        {
            return attributeTypeDAO.findByCriteria(DelegateDAO<AttributeType>.EMPTY_CRITERION, tasks);
        }

        public IList<PhoneNumberType> findAllPhoneNumberTypes(params IDAOTask<PhoneNumberType>[] tasks) {
            return phoneNumberTypeDAO.findByCriteria(DelegateDAO<PhoneNumberType>.EMPTY_CRITERION, tasks);
        }

        [Transaction(ReadOnly = true)]
        public IList<Fault> canMakePersistent(County entity) {
            FindHibernateDelegate<County> findDelegate = delegate(ISession session)
                                                             {
                                                                 IQuery query = session.CreateSQLQuery("select * from county where CountyName = '" + entity.Name + "' and CountyID != " + entity.ID + ";").AddEntity(objectType);
                                                                 return query.List<County>();
                                                             };

            IList<County> duplicates = delegateDAO.ExecuteFind(findDelegate);

            IList<Fault> result = delegateDAO.canMakePersistent(entity);

            if (duplicates.Count > 0) {
                result.Add(new Fault(true, "Duplicate County Name: a county named '" + entity.Name + "' already exists."));
            }

            return result;
        }

        [Transaction(ReadOnly = true)]
        public IList<Fault> canMakePersistent(CountyAttribute entity) {
            return countyAttributeDAO.canMakePersistent(entity);
        }

        [Transaction(ReadOnly = true)]
        public IList<Fault> canMakePersistent(CountyPhoneNumber entity) {
            return countyPhoneNumberDAO.canMakePersistent(entity);
        }

        [Transaction(ReadOnly = true)]
        public IList<Fault> canMakePersistent(CountyWebsite entity) {
            return countyWebsiteDAO.canMakePersistent(entity);
        }

        [Transaction(ReadOnly = true)]
        public IList<Fault> canMakeTransient(County entity) {
            return delegateDAO.canMakeTransient(entity);
        }

        [Transaction(ReadOnly = true)]
        public IList<Fault> canMakePersistent(AttributeType entity)
        {
            FindHibernateDelegate<AttributeType> findDelegate = delegate(ISession session)
                                                                    {
                                                                        IQuery query = session.CreateSQLQuery("select * from attributetype where AttributeTypeName = '" + entity.Name + "';").AddEntity(typeof(AttributeType));
                                                                        return query.List<AttributeType>();
                                                                    };

            IList<AttributeType> duplicates = attributeTypeDAO.ExecuteFind(findDelegate);

            IList<Fault> result = attributeTypeDAO.canMakePersistent(entity);

            if (duplicates.Count > 0) {
                result.Add(new Fault(true, "Duplicate Attribute Type: an attribute type named '" + entity.Name + "' already exists."));
            }
            return result;
        }

        [Transaction(ReadOnly = true)]
        public IList<Fault> canMakePersistent(PhoneNumberType entity)
        {
            FindHibernateDelegate<PhoneNumberType> findDelegate = delegate(ISession session)
                                                                      {
                                                                          IQuery query = session.CreateSQLQuery("select * from phonenumbertype where PhoneNumberTypeName = '" + entity.Name + "';").AddEntity(typeof (PhoneNumberType));
                                                                          return query.List<PhoneNumberType>();
                                                                      };

            IList<PhoneNumberType> duplicates = phoneNumberTypeDAO.ExecuteFind(findDelegate);

            IList<Fault> result = phoneNumberTypeDAO.canMakePersistent(entity);

            if (duplicates.Count > 0) {
                result.Add(new Fault(true, "Duplicate Phone Number Type: a phone number type named '" + entity.Name + "' already exists."));
            }
            return result;
        }

        [Transaction(ReadOnly = true)]
        public County findById(object id, bool lockRecord, params IDAOTask<County>[] tasks) {
            return delegateDAO.findById(id, lockRecord, tasks);
        }

        [Transaction(ReadOnly = false)]
        public County makePersistent(County entity) {
            return delegateDAO.makePersistent(entity);
        }

        public AttributeType makePersistent(AttributeType entity) {
            return attributeTypeDAO.makePersistent(entity);
        }

        public PhoneNumberType makePersistent(PhoneNumberType entity) {
            return phoneNumberTypeDAO.makePersistent(entity);
        }

        [Transaction(ReadOnly = false)]
        public void makeTransient(County entity) {
            delegateDAO.makeTransient(entity);
        }
    }
}