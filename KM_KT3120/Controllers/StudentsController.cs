﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KM_KT3120.Database;
using KM_KT3120.Models;
using KM_KT3120.Filters.StudentFilters;
using KM_KT3120.interfaces.StudentInterfaces;

namespace KM_KT3120.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;

        private readonly IStudentService _studentFilter;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentFilter)
        {
            _logger = logger;
            _studentFilter = studentFilter;
        }
        [HttpGet("Get students")]
        public async Task<IActionResult> GetStudentsAsync(CancellationToken cancellationToken = default)
        {
            var students = await _studentFilter.GetStudentsAsync(cancellationToken);
            return Ok(students);
        }
        [HttpPost(Name = "GetStudentByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentFilter.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpGet("Get students with id")]
        public async Task<ActionResult<Student>> GetStudentAsync(int id, CancellationToken cancellationToken = default)
        {
            var student = await _studentFilter.GetStudentAsync(id, cancellationToken);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("Add students")]
        [ActionName(nameof(AddStudentAsync))]
        public async Task<IActionResult> AddStudentAsync(Student student, CancellationToken cancellationToken = default)
        {
            await _studentFilter.AddStudentAsync(student, cancellationToken);
            return CreatedAtAction(nameof(AddStudentAsync), new { id = student.StudentId }, student);
        }

        [HttpPut("Update student with id")]
        public async Task<IActionResult> UpdateStudentAsync(int id, Student student, CancellationToken cancellationToken = default)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }
            await _studentFilter.UpdateStudentAsync(student, cancellationToken);
            return NoContent();
        }

        [HttpDelete("Delete students with id")]
        public async Task<IActionResult> DeleteStudentAsync(int id, CancellationToken cancellationToken = default)
        {
            var student = await _studentFilter.GetStudentAsync(id, cancellationToken);
            if (student == null)
            {
                return NotFound();
            }
            await _studentFilter.DeleteStudentAsync(student, cancellationToken);
            return Ok(student);
        }
    }

}


       
