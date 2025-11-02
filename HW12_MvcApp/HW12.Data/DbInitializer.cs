using HW12.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;   
        }

        public void Seed()
        {
            _modelBuilder.Entity<Movie>(x =>
            {
                x.HasData(new Movie
                {
                    Id = 1,
                    Title = "Матрица",
                    Director = "Вачовски",
                    Genre = "Фантастика",
                    Description = "Хакер-компьютерщик узнает от загадочных повстанцев о настоящей сущности своей реальности и о своей роли в войне с ее контроллерами."
                });

                x.HasData(new Movie
                {
                    Id = 2,
                    Title = "Начало",
                    Director = "Кристофер Нолан",
                    Genre = "Фантастика",
                    Description = "Вор, который крадет корпоративные тайны с помощью технологии обмена снами, получает задание внедрить идею в сознание генерального директора."
                });
            });

            _modelBuilder.Entity<Session>(x =>
            {
                x.HasData(new Session
                {
                    Id = 1,
                    RoomName = "Room1",
                    StartDate = DateTime.Now.Date,
                    StartTime = new TimeSpan(14, 30, 0),
                    EndTime = new TimeSpan(16, 30, 0),
                    MovieId = 1
                });

                x.HasData(new Session
                {
                    Id = 2,
                    RoomName = "Room2",
                    StartDate = DateTime.Now.Date,
                    StartTime = new TimeSpan(18, 00, 0),
                    EndTime = new TimeSpan(20, 00, 0),
                    MovieId = 1 
                });

                x.HasData(new Session
                {
                    Id = 3,
                    RoomName = "Room3",
                    StartDate = DateTime.Now.Date,
                    StartTime = new TimeSpan(15, 00, 0),
                    EndTime = new TimeSpan(17, 00, 0),
                    MovieId = 2 
                });

                x.HasData(new Session
                {
                    Id = 4,
                    RoomName = "Room4",
                    StartDate = DateTime.Now.Date,
                    StartTime = new TimeSpan(19, 00, 0),
                    EndTime = new TimeSpan(21, 00, 0),
                    MovieId = 2 
                });
            });
        }

    }
}
