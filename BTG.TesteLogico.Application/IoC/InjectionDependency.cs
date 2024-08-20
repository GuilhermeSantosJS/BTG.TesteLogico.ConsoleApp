using BTG.TesteLogico.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.TesteLogico.Application.IoC
{
    public class InjectionDependency
    {
        private readonly ICorteDeTijolos _corteDeTijolos;
        public InjectionDependency(ICorteDeTijolos corteDeTijolos) 
        {
            _corteDeTijolos = corteDeTijolos;
        }
    }
}
