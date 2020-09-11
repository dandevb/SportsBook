using Microsoft.EntityFrameworkCore;
using Moq;
using SportsBook.Domain.Model;
using SportsBook.Infrastructure;
using SportsBook.Infrastructure.Repository;
using SportsBook.Tests.Test_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SportsBook.Tests
{
    public class GenericRepositoryTest
    {
        #region Get methods
        [Fact]
        public void Get_Entity_ReturnsIEnumerable()
        {
            //Setup DbContext and DbSet mock  
            var dbContextMock = new Mock<SportsBookDB>();
            var dbSetMock = new Mock<DbSet<TestEntity>>();

            var result = new List<TestEntity>()
            {
                new TestEntity() {Id = 3, Name = "Football" },
                new TestEntity() {Id = 10, Name = "Baseball" }
            }.AsQueryable();

            dbSetMock.As<IQueryable<TestEntity>>().Setup(m => m.Provider).Returns(result.Provider);
            dbSetMock.As<IQueryable<TestEntity>>().Setup(m => m.Expression).Returns(result.Expression);
            dbSetMock.As<IQueryable<TestEntity>>().Setup(m => m.ElementType).Returns(result.ElementType);
            dbSetMock.As<IQueryable<TestEntity>>().Setup(m => m.GetEnumerator()).Returns(result.GetEnumerator());
            dbContextMock.Setup(s => s.Set<TestEntity>()).Returns(dbSetMock.Object);

            // Create repository and use Get method
            var repository = new GenericRepository<TestEntity>(dbContextMock.Object);
            var listObjs = repository.Get(x => x.Name == "Baseball");

            //Assert  
            Assert.NotNull(listObjs);
            Assert.Collection(listObjs, item => Assert.Contains("Baseball", item.Name));
            Assert.Collection(listObjs, item => Assert.DoesNotContain("Football", item.Name));
            Assert.IsAssignableFrom<IEnumerable<TestEntity>>(listObjs);
        }

        [Fact]
        public void Get_Entity_ReturnsEmptyCollection()
        {
            //Setup DbContext and DbSet mock  
            var dbContextMock = new Mock<SportsBookDB>();
            var dbSetMock = new Mock<DbSet<TestEntity>>();

            var result = new List<TestEntity>()
            {
                new TestEntity() {Id = 3, Name = "Football" },
                new TestEntity() {Id = 10, Name = "Baseball" }
            }.AsQueryable();

            dbSetMock.As<IQueryable<TestEntity>>().Setup(m => m.Provider).Returns(result.Provider);
            dbSetMock.As<IQueryable<TestEntity>>().Setup(m => m.Expression).Returns(result.Expression);
            dbSetMock.As<IQueryable<TestEntity>>().Setup(m => m.ElementType).Returns(result.ElementType);
            dbSetMock.As<IQueryable<TestEntity>>().Setup(m => m.GetEnumerator()).Returns(result.GetEnumerator());
            dbContextMock.Setup(s => s.Set<TestEntity>()).Returns(dbSetMock.Object);

            // Create repository and use Get method
            var repository = new GenericRepository<TestEntity>(dbContextMock.Object);
            var listObjs = repository.Get(x => x.Name == "Basketball");

            //Assert  
            Assert.Empty(listObjs);
            Assert.IsAssignableFrom<IEnumerable<TestEntity>>(listObjs);
        }

        [Fact]
        public void Get_EntityById_ReturnsEntity()
        {
            //Setup DbContext and DbSet mock  
            var dbContextMock = new Mock<SportsBookDB>();
            var dbSetMock = new Mock<DbSet<TestEntity>>();
            dbSetMock.Setup(s => s.Find(It.IsAny<Guid>())).Returns(new TestEntity() { Id = 10, Name = "Football" });
            dbContextMock.Setup(s => s.Set<TestEntity>()).Returns(dbSetMock.Object);
 
            // Create repository and use Get method
            var repository = new GenericRepository<TestEntity>(dbContextMock.Object);
            var obj = repository.GetByID(Guid.NewGuid());

            //Assert  
            Assert.NotNull(obj);
            Assert.Equal(10, obj.Id);
            Assert.IsAssignableFrom<TestEntity>(obj);
        }
        #endregion
    }
}
