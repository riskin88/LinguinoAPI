using AutoMapper;
using BLL.DTO;
using BLL.DTO.Exercises.Inbound;
using BLL.DTO.Exercises.Outbound;
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

        public async Task<LearningStep> CreateLearningStep(CreateLearningStepDTO createLearningStepDTO, long lessonItemId)
        {
            var lessonItem = await _unitOfWork.LessonItemRepository.GetById(lessonItemId);
            if (lessonItem != null)
            {
                var learningStep = _mapper.Map<LearningStep>(createLearningStepDTO);
                _unitOfWork.LearningStepRepository.Add(learningStep);
                learningStep.LessonItem = lessonItem;
                _unitOfWork.SaveChanges();
                foreach (var exerciseDTO in createLearningStepDTO.ExercisesId)
                {
                    var exercise = await _unitOfWork.ExerciseRepository.GetById(exerciseDTO.Id);
                    if (exercise != null)
                    {
                        if (exercise.LessonItemId == lessonItemId)
                        {
                            await _unitOfWork.LearningStepRepository.AddExercise(learningStep.Id, exercise);
                        }
                        else throw new LessonItemMismatchException(null);
                    }
                    else throw new InvalidIDException("Exercise " + exerciseDTO.Id + " does not exist.");
                }
                _unitOfWork.SaveChanges();
                return learningStep;
            }
            else throw new InvalidIDException("Lesson item does not exist.");
        }

        public async Task<Exercise> CreateExercise(CreateExerciseDTO exerciseDTO, long lessonItemId)
        {
            var lessonItem = await _unitOfWork.LessonItemRepository.GetById(lessonItemId);
            if (lessonItem != null)
            {
                var exercise = _mapper.Map<CreateExerciseDTO, Exercise>(exerciseDTO);
                _unitOfWork.ExerciseRepository.AddExercise(exercise);
                exercise.LessonItem = lessonItem;
                _unitOfWork.SaveChanges();
                return exercise;
            }
            else throw new InvalidIDException("Lesson item does not exist.");
        }

    }
}
