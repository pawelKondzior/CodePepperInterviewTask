using Autofac;
using CodePepperInterview.DAL.EF.Contexts;
using CodePepperInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using URF.Core.Abstractions;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF;
using URF.Core.EF.Trackable;

namespace CodePepperInterview.Services.Init
{
    public class EFAutofacModule : Module
    {
        private string connectionString;

        public EFAutofacModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)

        {
            // Register Entity Framework
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<UrfSampleContext>().UseSqlServer(connectionString);

            builder.RegisterType<UrfSampleContext>()
                .WithParameter("options", dbContextOptionsBuilder.Options)
                .InstancePerLifetimeScope()
                .As<DbContext>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<TrackableRepository<Character>>().As<ITrackableRepository<Character>>();
            builder.RegisterType<TrackableRepository<CharacterFriend>>().As<ITrackableRepository<CharacterFriend>>();
        }
    }
}