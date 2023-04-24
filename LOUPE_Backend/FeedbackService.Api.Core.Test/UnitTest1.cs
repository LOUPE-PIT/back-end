using AutoMapper;
using FeedbackService.Api.Core.Services;
using FeedbackService.API.Core.Viewmodels;
using FeedbackService.DAL.Models;
using FeedbackService.DAL.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace FeedbackService.Api.Core.Test
{
    [TestFixture]
    public class Tests
    {

        private Mock<IFeedbackRepository> mockRepository;
        private Mock<IMapper> mockMapper;
        private FeedbackServiceCore service;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IFeedbackRepository>();
            mockMapper = new Mock<IMapper>();
            service = new FeedbackServiceCore(mockRepository.Object, mockMapper.Object);
        }


        [Test]
        public async Task TestCreate()
        {
            // Arrange
            var feedbackViewModel = new FeedbackViewmodel();
            var feedback = new Feedback();

            mockMapper.Setup(m => m.Map<Feedback>(feedbackViewModel)).Returns(feedback);

            // Act
            await service.Create(feedbackViewModel);

            // Assert
            mockMapper.Verify(m => m.Map<Feedback>(feedbackViewModel), Times.Once);
            mockRepository.Verify(m => m.Create(feedback), Times.Once);


        }

        [Test]
        public async Task TestDeleteById()
        {
            // Arrange
            var feedbackViewModel = new FeedbackViewmodel();
            var feedback = new Feedback();

            mockMapper.Setup(m => m.Map<Feedback>(feedbackViewModel)).Returns(feedback);

            // Act
            await service.DeleteById(feedbackViewModel);

            // Assert
            mockMapper.Verify(m => m.Map<Feedback>(feedbackViewModel), Times.Once);
            mockRepository.Verify(m => m.DeleteById(feedback), Times.Once);
        }

        [Test]
        public async Task TestGetAll()
        {
            var expectedFeedback = new Collection<Feedback>
        {
            new Feedback {
                FeedbackId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                LogId = Guid.NewGuid(),
                Date = DateTime.Now,
                FeedbackText = "Test"
            },
        };

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(expectedFeedback);

            // Act
            var result = await service.GetAll();

            // Assert
            result.Should().BeEquivalentTo(expectedFeedback);
        }

        [Test]
        public async Task TestGetById()
        {
            // Arrange
            var id = Guid.NewGuid();
            var feedbacks = new List<Feedback>() { new Feedback() }.AsEnumerable();
            mockRepository.Setup(m => m.GetById(id)).ReturnsAsync(new Collection<Feedback>(feedbacks.ToList()));

            // Act
            var result = await service.GetById(id);

            // Assert
            mockRepository.Verify(m => m.GetById(id), Times.Once);
            result.Should().BeOfType<Collection<Feedback>>();
        }

        [Test]
        public async Task TestGetByLogId()
        {
            // Arrange
            var id = Guid.NewGuid();
            var feedbacks = new List<Feedback>() { new Feedback() }.AsEnumerable();
            mockRepository.Setup(m => m.GetByLogId(id)).ReturnsAsync(new Collection<Feedback>(feedbacks.ToList()));

            // Act
            var result = await service.GetByLogId(id);

            // Assert
            mockRepository.Verify(m => m.GetByLogId(id), Times.Once);
            result.Should().BeOfType<Collection<Feedback>>();
        }
    }
}