﻿using BLL.DTO;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinguinoAPI.Controllers
{
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("courses")]
        public ActionResult CreateCourse(Course course)
        {
            _courseService.CreateCourse(course);
            return Ok();
        }

        [HttpGet, Authorize]
        [Route("courses")]
        public async Task<ActionResult<IEnumerable<CourseRespDTO>>> GetCourses([FromQuery] CourseFilter filter)
        {                      
            return Ok(await _courseService.GetCourses(filter));
        }

        [HttpGet, Authorize]
        [Route("users/{userId}/courses")]
        public async Task<ActionResult<IEnumerable<CourseRespDTO>>> GetUserCourses(string userId)
        {
            return Ok(await _courseService.GetUserCourses(userId));
        }


        [HttpPost, Authorize]
        [Route("users/{userId}/courses")]
        public async Task<ActionResult<Course>> AddCourse(AddCourseDTO course, string userId)
        {
            return Ok(await _courseService.AddUser(course, userId));
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("courses/{courseId}/topics")]
        public async Task<ActionResult> CreateTopic(long courseId, Topic topic)
        {
            await _courseService.CreateTopic(courseId, topic);
            return Ok();
        }

        [HttpGet, Authorize]
        [Route("courses/{courseId}/topics")]
        public async Task<ActionResult<IEnumerable<TopicRespDTO>>> GetTopics(long courseId, [FromQuery] TopicFilter filter)
        {
            return Ok(await _courseService.GetTopics(courseId, filter));
        }
    }
}
