﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ElearningApi.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
    }
}
