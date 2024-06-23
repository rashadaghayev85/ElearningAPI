﻿using ElearningApi.Models;

namespace ElearningApi.DTOs.Courses
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
        public int InstructorName { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CourseImage> CoursesImages { get; set; }

        public List<CourseStudent> CourseStudents { get; set; }
    }
}
