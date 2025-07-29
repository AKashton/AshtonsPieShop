using AshtonsPieShopTests.Mocks;
using AshtonsPieShop.Controllers;
using AshtonsPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AshtonsPieShop.Models;

namespace AshtonsPieShopTests.Controllers
{
    public class PieControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnsAllPies()
        {
            // arrange
            var mockPieRepository = RepositoryMocks.GetPieRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);

            // act
            var result = pieController.List("");

            // assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>
                (viewResult.ViewData.Model);
            Assert.Equal(10, pieListViewModel.Pies.Count());

        }

        [Fact]
        public void List_CategroryFruitPies_ReturnsFruitPies()
        {
            // arragnge
            var mockPieRepository = RepositoryMocks.GetPieRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);

            // act
            var result = pieController.List("Fruit pies");

            // assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>
                (viewResult.ViewData.Model);
            Assert.Equal(5, pieListViewModel.Pies.Count());

        }

        [Fact]
        public void Detail_EmptyPie_ReturnsNotFound()
        {
            // arrange
            var mockPieRepository = RepositoryMocks.GetPieRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);

            // act
            var result = pieController.Details(20); // there is only 10 pies

            // assert
            var notFound = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Detail_PeachPie_Returns_PeachPie()
        {
            // arrange
            var mockPieRepository = RepositoryMocks.GetPieRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);

            // act
            var result = pieController.Details(6); // returns peachpie?

            // assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pie = Assert.IsAssignableFrom<Pie>
                (viewResult.ViewData.Model);
            Assert.Contains("Peach Pie", pie.Name);
        }
        [Fact]
        public void Search_Pies_ReturnView()
        {
            // arrange
            var mockPieRepository = RepositoryMocks.GetPieRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);

            // act
            var result = pieController.Search();

            // assert

            Assert.IsType<ViewResult>(result);
        }

    }
}
