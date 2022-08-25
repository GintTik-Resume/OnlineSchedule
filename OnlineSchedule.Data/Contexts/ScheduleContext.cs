﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineSchedule.Data.Entities;

namespace OnlineSchedule.Data.Contexts
{
    public class ScheduleContext : IdentityDbContext<User>
    {
        public DbSet<Schedule> Schedules;
        public DbSet<Day> Days;
        public DbSet<Lesson> Lessons;
        public DbSet<Comment> Comments;
        public DbSet<HistoryUserItem> HistoryUser;
        public DbSet<HistoryScheduleItem> HistorySchedule;
        public DbSet<TypeOfAction> TypeOfActions;

        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options) { }
    }
}
