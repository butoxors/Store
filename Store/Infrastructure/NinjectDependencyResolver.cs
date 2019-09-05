using Domain.Abstract;
using Domain.Entities;
using Moq;
using Ninject;
using Store.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Store.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            /*Mock<ICategoryRepository> mock1 = new Mock<ICategoryRepository>();
            List<Category> cat = new List<Category>()
            {
                new Category{Description = "Instruments"},
                new Category{Description = "Food" }
            };


            mock1.Setup(m => m.Categories).Returns(
                cat
            );

            Mock<IProductRepository> mock2 = new Mock<IProductRepository>();

            mock2.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product{Name = "Hammer", Description = "Hammer-2000", Category = cat[0], Price = 100 },
                new Product{Name = "Cucumber", Description = "Green cucumber", Category = cat[1], Price = 50 },
                new Product{Name = "Tomato", Description = "Red tomato", Category = cat[1], Price = 13 },
                new Product { Name = "Potato", Description = "Brown potato", Category = cat[1], Price = 16}
            });

            kernel.Bind<ICategoryRepository>().ToConstant(mock1.Object);
            kernel.Bind<IProductRepository>().ToConstant(mock2.Object);*/

            kernel.Bind<ICategoryRepository>().To<EFCategoryRepository>();
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}