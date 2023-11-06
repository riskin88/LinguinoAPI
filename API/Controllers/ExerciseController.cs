using BLL.DTO;
using BLL.DTO.Exercises;
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
        public async Task<ActionResult> CreateLearningStep(CreateLearningStepDTO createLearningStepDTO, long lessonItemId)
        {
            await _exerciseService.CreateLearningStep(createLearningStepDTO, lessonItemId);
            return Ok();
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/text-exercises")]
        public async Task<ActionResult> CreateTextExercise(CreateTextExerciseDTO textExerciseDTO, long lessonItemId)
        {
            await _exerciseService.CreateTextExercise(textExerciseDTO, lessonItemId);
            return Ok();
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/fill-blank-exercises")]
        public async Task<ActionResult> CreateFillInBlankExercise(CreateFillInBlankExerciseDTO fillInBlankExerciseDTO, long lessonItemId)
        {
            await _exerciseService.CreateFillInBlankExercise(fillInBlankExerciseDTO, lessonItemId);
            return Ok();
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/fill-blank-options-exercises")]
        public async Task<ActionResult> CreateFillInBlankOptionsExercise(CreateFillInBlankOptionsExerciseDTO fillInBlankOptionsExerciseDTO, long lessonItemId)
        {
            await _exerciseService.CreateFillInBlankOptionsExercise(fillInBlankOptionsExerciseDTO, lessonItemId);
            return Ok();
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/{lessonItemId}/fill-table-exercises")]
        public async Task<ActionResult> CreateFillInTableExercise(CreateFillInTableExerciseDTO fillInTableExerciseDTO, long lessonItemId)
        {
            await _exerciseService.CreateFillInTableExercise(fillInTableExerciseDTO, lessonItemId);
            return Ok();
        }
    }
}
