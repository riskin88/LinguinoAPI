using AutoMapper;
using BLL.DTO;
using BLL.DTO.Exercises;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Exceptions;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExerciseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateLearningStep(CreateLearningStepDTO createLearningStepDTO, long lessonItemId)
        {
            var lessonItem = await _unitOfWork.LessonItemRepository.GetById(lessonItemId);
            if (lessonItem != null)
            {
                var learningStep = _mapper.Map<LearningStep>(createLearningStepDTO);
                _unitOfWork.LearningStepRepository.Add(learningStep);
                learningStep.LessonItem = lessonItem;
                _unitOfWork.SaveChanges();
                foreach (var exerciseDTO in createLearningStepDTO.Excercises)
                {
                    var exercise = await _unitOfWork.ExerciseRepository.GetById(exerciseDTO.Id);
                    if (exercise != null)
                        await _unitOfWork.LearningStepRepository.AddExercise(learningStep.Id, exercise);
                    else throw new InvalidIDException("Exercise " + exerciseDTO.Id + " does not exist.");
                }
            }
        }

        public async Task CreateFillInBlankExercise(CreateFillInBlankExerciseDTO fillInBlankExerciseDTO, long lessonItemId)
        {
            var lessonItem = await _unitOfWork.LessonItemRepository.GetById(lessonItemId);
            if (lessonItem != null)
            {
                var fillInBlankExercise = _mapper.Map<FillInBlankExercise>(fillInBlankExerciseDTO);
                _unitOfWork.ExerciseRepository.Add(fillInBlankExercise);
                fillInBlankExercise.LessonItem = lessonItem;
                _unitOfWork.SaveChanges();
            }
            else throw new InvalidIDException("Lesson item does not exist.");
        }

        public async Task CreateFillInBlankOptionsExercise(CreateFillInBlankOptionsExerciseDTO fillInBlankOptionsExerciseDTO, long lessonItemId)
        {
            var lessonItem = await _unitOfWork.LessonItemRepository.GetById(lessonItemId);
            if (lessonItem != null)
            {
                var fillInBlankOptionsExercise = _mapper.Map<FillInBlankOptionsExercise>(fillInBlankOptionsExerciseDTO);
                _unitOfWork.ExerciseRepository.Add(fillInBlankOptionsExercise);
                fillInBlankOptionsExercise.LessonItem = lessonItem;
                _unitOfWork.SaveChanges();
            }
            else throw new InvalidIDException("Lesson item does not exist.");
        }

        public async Task CreateFillInTableExercise(CreateFillInTableExerciseDTO fillInTableExerciseDTO, long lessonItemId)
        {
            var lessonItem = await _unitOfWork.LessonItemRepository.GetById(lessonItemId);
            if (lessonItem != null)
            {
                var fillInTableExercise = _mapper.Map<FillInTableExercise>(fillInTableExerciseDTO);
                _unitOfWork.ExerciseRepository.Add(fillInTableExercise);
                fillInTableExercise.LessonItem = lessonItem;
                _unitOfWork.SaveChanges();
            }
            else throw new InvalidIDException("Lesson item does not exist.");
        }


        public async Task CreateTextExercise(CreateTextExerciseDTO textExerciseDTO, long lessonItemId)
        {
            var lessonItem = await _unitOfWork.LessonItemRepository.GetById(lessonItemId);
            if (lessonItem != null)
            {
                var textExercise = _mapper.Map<TextExercise>(textExerciseDTO);
                _unitOfWork.ExerciseRepository.Add(textExercise);
                textExercise.LessonItem = lessonItem;
                _unitOfWork.SaveChanges();
            }
            else throw new InvalidIDException("Lesson item does not exist.");
        }
    }
    }
