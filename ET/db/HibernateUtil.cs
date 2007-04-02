using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class HibernateUtil {
        public static ISessionFactory makeSessionFactory() {
            Configuration cfg = new Configuration();
            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
            cfg.AddAssembly(assemblyName.Name);
            ISessionFactory factory = cfg.BuildSessionFactory();
            return factory;
        }
    }
}