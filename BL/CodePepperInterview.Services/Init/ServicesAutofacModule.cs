using Autofac;
using CodePepperInterview.Contracts.IServices;
using CodePepperInterview.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePepperInterview.Services.Init
{
    public class ServicesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CharacterService>().As<ICharactersService>();
        }
    }
}