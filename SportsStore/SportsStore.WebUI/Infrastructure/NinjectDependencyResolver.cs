using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver :IDependencyResolver
    {
        private IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            mykernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }

        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }

        private void AddBindings()
        {
           /* Mock<IProductRepository> myMock = new Mock<IProductRepository>();
            myMock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {Name = "Football", Price = 25},
                new Product {Name = "Surfboard", Price = 179},
                new Product {Name = "Running shoes", Price = 95}
            });
           */
            mykernel.Bind<IProductRepository>().To<EFProductRepository>();
        }

        
    }
}