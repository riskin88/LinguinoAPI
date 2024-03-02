using BLL.DTO;
using BLL.DTO.Exercises.Inbound;
using BLL.Services.Contracts;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/learning-step")]
        public async Task<ActionResult<LearningStep>> CreateLearningStep(CreateLearningStepDTO createLearningStepDTO, long lessonItemId)
        {
            return Ok(await _exerciseService.CreateLearningStep(createLearningStepDTO, lessonItemId));
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/text-exercises")]
        public async Task<ActionResult<Exercise>> CreateTextExercise(CreateTextExerciseDTO exerciseDTO, long lessonItemId)
        {
            return Ok(await _exerciseService.CreateExercise(exerciseDTO, lessonItemId));
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/build-word-exercises")]
        public async Task<ActionResult<Exercise>> CreateBuildWordExercise(CreateBuildWordExerciseDTO exerciseDTO, long lessonItemId)
        {
            return Ok(await _exerciseService.CreateExercise(exerciseDTO, lessonItemId));
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/fill-sentence-exercises")]
        public async Task<ActionResult<Exercise>> CreateFillInSentenceExercise(CreateFillInSentenceExerciseDTO exerciseDTO, long lessonItemId)
        {
            return Ok(await _exerciseService.CreateExercise(exerciseDTO, lessonItemId));
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/fill-table-exercises")]
        public async Task<ActionResult<Exercise>> CreateFillInTableExercise(CreateFillInTableExerciseDTO exerciseDTO, long lessonItemId)
        {
            return Ok(await _exerciseService.CreateExercise(exerciseDTO, lessonItemId));
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/listening-exercises")]
        public async Task<ActionResult<Exercise>> CreateListeningExercise(CreateListeningExerciseDTO exerciseDTO, long lessonItemId)
        {
            return Ok(await _exerciseService.CreateExercise(exerciseDTO, lessonItemId));
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/read-aloud-exercises")]
        public async Task<ActionResult<Exercise>> CreateReadAloudExercise(CreateReadAloudExerciseDTO exerciseDTO, long lessonItemId)
        {
            return Ok(await _exerciseService.CreateExercise(exerciseDTO, lessonItemId));
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/reading-exercises")]
        public async Task<ActionResult<Exercise>> CreateReadingExercise(CreateReadingExerciseDTO exerciseDTO, long lessonItemId)
        {
            return Ok(await _exerciseService.CreateExercise(exerciseDTO, lessonItemId));
        }
        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/repeat-audio-exercises")]
        public async Task<ActionResult<Exercise>> CreateRepeatAudioExercise(CreateRepeatAudioExerciseDTO exerciseDTO, long lessonItemId)
        {
            return Ok(await _exerciseService.CreateExercise(exerciseDTO, lessonItemId));
        }
        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/short-listening-exercises")]
        public async Task<ActionResult<Exercise>> CreateShortListeningExercise(CreateShortListeningExerciseDTO exerciseDTO, long lessonItemId)
        {
            return Ok(await _exerciseService.CreateExercise(exerciseDTO, lessonItemId));
        }
        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/speech-exercises")]
        public async Task<ActionResult<Exercise>> CreateSpeechExercise(CreateSpeechExerciseDTO exerciseDTO, long lessonItemId) 
        {
            return Ok(await _exerciseService.CreateExercise(exerciseDTO, lessonItemId));
        }


    }
}
