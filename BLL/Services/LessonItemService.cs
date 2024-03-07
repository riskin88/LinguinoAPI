using AutoMapper;
using BLL.DTO.LessonItems;
using BLL.DTO.Lessons;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LessonItemService : ILessonItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessonItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CreateItemRespDTO CreateLessonItem(CreateItemDTO createItemDTO)
        {
            var item = _mapper.Map<LessonItem>(createItemDTO);
            _unitOfWork.LessonItemRepository.AddItem(item);
            _unitOfWork.SaveChanges();
            return _mapper.Map<CreateItemRespDTO>(item);
        }

        public async Task AddLessonItem(AddItemDTO itemDTO, long lessonId, long lessonItemId)
        {
            var lesson = await _unitOfWork.LessonRepository.GetById(lessonId);
            if (lesson != null)
            {
                var item = await _unitOfWork.LessonItemRepository.GetById(lessonItemId);
                if (item != null)
                {
                    if (item.Type == lesson.Type)
                        await _unitOfWork.LessonRepository.AddLessonItemWithOrder(lesson.Id, item, itemDTO.OrderInLesson);
                    else throw new LessonTypeMismatchException();
                }
                var users = await _unitOfWork.LessonRepository.GetUsers(lessonId);
                foreach (var user in users)
                {
                    await _unitOfWork.LessonItemRepository.AddToUser(lessonItemId, user);
                }

                lesson.ItemsTotal++;
                _unitOfWork.SaveChanges();
            }
        }

        public CreateWordRespDTO CreateWord(CreateWordDTO createWordDTO)
        {
            var word = _mapper.Map<Word>(createWordDTO);
            _unitOfWork.LessonItemRepository.AddWord(word);
            _unitOfWork.SaveChanges();
            return _mapper.Map<CreateWordRespDTO>(word);

        }

        public async Task<IEnumerable<GetWordBriefDTO>> GetVocabularyInCourse(long courseId, VocabularyFilter filter)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                var vocab = await _unitOfWork.LessonItemRepository.GetLessonItemsFromCourse(courseId, filter);
                return _mapper.Map<List<GetWordBriefDTO>>(vocab);
            }
            throw new UserNotInCourseException();
        }
    }
}
