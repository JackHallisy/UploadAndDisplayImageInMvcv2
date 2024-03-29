﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UploadAndDisplayImageInMvcApi;
using UploadAndDisplayImageInMvcApi.Controllers;

namespace UploadAndDisplayImageInMvcApi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeAPIController controller = new HomeAPIController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
