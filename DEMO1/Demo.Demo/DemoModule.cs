using Autofac;
using Demo.Demo.Repository;
using Demo.Demo.Service;
using Demo.Demo.UnitOFWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Demo
{

    public class DemoModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public DemoModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;

        }
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<DemoContext>().As<DemoContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();


            builder.RegisterType<DemoUnitOfWOrk>().As<IDemoUnitOfWOrk>()
               .InstancePerLifetimeScope();

            builder.RegisterType<DemoService>().As<IDemoService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
