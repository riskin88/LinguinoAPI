using AutoMapper;
using BLL.Config;
using BLL.DTO.LessonItems;
using BLL.DTO.Users;
using BLL.Services;
using DAL.Entities;
using DAL.Entities.Relations;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Repositories.Contracts;
using DAL.UnitOfWork;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework.Internal;
using Stripe;
using System.Security.Policy;

namespace Tests
{
    public class LessonItemServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetVocabularyInCourse_NotInCourse()
        {

            var mockCourseRepo = new Mock<ICourseRepository>();
            mockCourseRepo.Setup(m => m.IsEnrolled(It.IsAny<long>()).Result).Returns(false);


            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.CourseRepository).Returns(mockCourseRepo.Object);

            var mockMapper = new Mock<IMapper>();
            var mockOptions = Options.Create(new LearningSettings());

            var lis = new LessonItemService(mockUnitOfWork.Object, mockMapper.Object, mockOptions);

            Assert.ThrowsAsync<UserNotInCourseException>(async () => await lis.GetVocabularyInCourse(1, new VocabularyFilter()));
        }

        [Test]
        public void GetVocabularyInCourse()
        {
            List<Word> vocab = [new Word { Id = 1, NameL1 = "a", NameL2 = "b" }, new Word { Id = 2, NameL1 = "c", NameL2 = "d" }, new Word { Id = 3, NameL1 = "e", NameL2 = "f" }];
            List<GetWordBriefDTO> vocabDTOs = [new GetWordBriefDTO { Id = 1, NameL1 = "a", NameL2 = "b" }, new GetWordBriefDTO { Id = 2, NameL1 = "c", NameL2 = "d" }, new GetWordBriefDTO { Id = 3, NameL1 = "e", NameL2 = "f" }];

            var mockCourseRepo = new Mock<ICourseRepository>();
            mockCourseRepo.Setup(m => m.IsEnrolled(It.IsAny<long>()).Result).Returns(true);

            var mockLessonItemRepo = new Mock<ILessonItemRepository>();
            mockLessonItemRepo.Setup(m => m.GetVocabularyInCourse(It.IsAny<long>(), It.IsAny<VocabularyFilter>()).Result).Returns(vocab);


            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.CourseRepository).Returns(mockCourseRepo.Object);
            mockUnitOfWork.Setup(m => m.LessonItemRepository).Returns(mockLessonItemRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<List<GetWordBriefDTO>>(vocab)).Returns(vocabDTOs);

            var mockOptions = Options.Create(new LearningSettings());

            var lis = new LessonItemService(mockUnitOfWork.Object, mockMapper.Object, mockOptions);

            Assert.That(lis.GetVocabularyInCourse(1, new VocabularyFilter()).Result, Is.EquivalentTo(vocabDTOs));
        }

        [Test]
        public void GetWordDetails_Invalid()
        {

            var mockCourseRepo = new Mock<ICourseRepository>();
            mockCourseRepo.Setup(m => m.IsEnrolled(It.IsAny<long>()).Result).Returns(true);

            var mockLessonItemRepo = new Mock<ILessonItemRepository>();
            mockLessonItemRepo.Setup(m => m.GetWordById(It.IsAny<long>()).Result).Returns<ILessonItemRepository, Word?>(null);


            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.CourseRepository).Returns(mockCourseRepo.Object);
            mockUnitOfWork.Setup(m => m.LessonItemRepository).Returns(mockLessonItemRepo.Object);

            var mockMapper = new Mock<IMapper>();
            var mockOptions = Options.Create(new LearningSettings());

            var lis = new LessonItemService(mockUnitOfWork.Object, mockMapper.Object, mockOptions);

            Assert.ThrowsAsync<InvalidIDException>(async () => await lis.GetWordDetails(1, 1));
        }

        [Test]
        public void GetWordDetails_NotInCourse()
        {
            var word = new Word { Id = 1, NameL1 = "a", NameL2 = "b" };

            var mockCourseRepo = new Mock<ICourseRepository>();
            mockCourseRepo.Setup(m => m.IsEnrolled(It.IsAny<long>()).Result).Returns(true);

            var mockLessonItemRepo = new Mock<ILessonItemRepository>();
            mockLessonItemRepo.Setup(m => m.GetWordById(It.IsAny<long>()).Result).Returns(word);
            mockLessonItemRepo.Setup(m => m.WordInCourse(It.IsAny<long>(), It.IsAny<long>()).Result).Returns(false);


            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.CourseRepository).Returns(mockCourseRepo.Object);
            mockUnitOfWork.Setup(m => m.LessonItemRepository).Returns(mockLessonItemRepo.Object);

            var mockMapper = new Mock<IMapper>();
            var mockOptions = Options.Create(new LearningSettings());

            var lis = new LessonItemService(mockUnitOfWork.Object, mockMapper.Object, mockOptions);

            Assert.ThrowsAsync<InvalidIDException>(async () => await lis.GetWordDetails(1, 1));
        }

        [Test]
        public void GetWordDetails()
        {
            var word = new Word { Id = 1, NameL1 = "a", NameL2 = "b" };
            var userLessonItem = new UserLessonItem { Id = 1, UserId = "abc", LessonItemId = 1, ItemState = DAL.Entities.Enums.LessonItemState.REVIEW, DateToReview = new DateTime(2024, 1, 1)};

            var wordDTO = new GetWordDTO { Id = 1, NameL1 = "a", NameL2 = "b" };
            var resWordDTO = new GetWordDTO { Id = 1, NameL1 = "a", NameL2 = "b", Favorite = true, LearningState = DAL.Entities.Enums.LessonItemState.REVIEW, DateToReview = new DateTime(2024, 1, 1) };

            var mockCourseRepo = new Mock<ICourseRepository>();
            mockCourseRepo.Setup(m => m.IsEnrolled(It.IsAny<long>()).Result).Returns(true);

            var mockLessonItemRepo = new Mock<ILessonItemRepository>();
            mockLessonItemRepo.Setup(m => m.GetWordWithExamples(It.IsAny<long>()).Result).Returns(word);
            mockLessonItemRepo.Setup(m => m.WordInCourse(It.IsAny<long>(), It.IsAny<long>()).Result).Returns(true);
            mockLessonItemRepo.Setup(m => m.IsFavorite(It.IsAny<long>())).Returns(true);
            mockLessonItemRepo.Setup(m => m.GetUserLessonItem(It.IsAny<long>()).Result).Returns(userLessonItem);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.CourseRepository).Returns(mockCourseRepo.Object);
            mockUnitOfWork.Setup(m => m.LessonItemRepository).Returns(mockLessonItemRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<GetWordDTO>(word)).Returns(wordDTO);

            var mockOptions = Options.Create(new LearningSettings());

            var lis = new LessonItemService(mockUnitOfWork.Object, mockMapper.Object, mockOptions);

            var res = lis.GetWordDetails(1, 1).Result;
            //Assert.That(lis.GetWordDetails(1, 1).Result, Is.EqualTo(resWordDTO));
            Assert.That(res.Id, Is.EqualTo(resWordDTO.Id));
            Assert.That(res.NameL1, Is.EqualTo(resWordDTO.NameL1));
            Assert.That(res.NameL2, Is.EqualTo(resWordDTO.NameL2));
            Assert.That(res.Favorite, Is.EqualTo(resWordDTO.Favorite));
            Assert.That(res.LearningState, Is.EqualTo(resWordDTO.LearningState));
            Assert.That(res.DateToReview, Is.EqualTo(resWordDTO.DateToReview));
        }
    }
}