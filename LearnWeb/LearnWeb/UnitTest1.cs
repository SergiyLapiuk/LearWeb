using Microsoft.AspNetCore.Mvc;
using Xunit;
using LearnWeb.Controllers;
using LearnWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class UnitTest1
    {

        [Fact]
        public void GetSubjectsResultNotNull()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LearnAPIContext>();
            optionsBuilder.UseSqlServer("Server= DESKTOP-RTDQS5I; Database=LearnAPI; Trusted_Connection=True; MultipleActiveResultSets=true");
            var controller = new SubjectsController(new LearnAPIContext(optionsBuilder.Options));
            var result = controller.GetSubjects();
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetSubjectsContainsAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LearnAPIContext>();
            optionsBuilder.UseSqlServer("Server= DESKTOP-RTDQS5I; Database=LearnAPI; Trusted_Connection=True; MultipleActiveResultSets=true");
            var controller = new SubjectsController(new LearnAPIContext(optionsBuilder.Options));
            var result = await controller.GetSubjects();
            Assert.Contains(result.Value, c => c.Name.Equals("Математика"));
        }
    }
}