﻿
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Models.QuizAggregate;

namespace Web;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
            List<QuizItem> quizItems = new List<QuizItem>();

            var item1 = quizItemRepo?.Add(new QuizItem()
            {
                Id = 1,
                CorrectAnswer = "5",
                Question = "3 + 2",
                IncorrectAnswers = new List<string>() { "2", "3", "4" }
            });

            var item2 = quizItemRepo?.Add(new QuizItem()
            {
                Id = 2,
                CorrectAnswer = "8",
                Question = "4 * 2",
                IncorrectAnswers = new List<string>() { "10", "6", "4" }
            });


            var item3 = quizItemRepo?.Add(new QuizItem()
            {
                Id = 3,
                CorrectAnswer = "Toruń",
                Question = "Dostępu do morza nie ma?",
                IncorrectAnswers = new List<string>() { "Gdynia", "Gdańsk", "Kołobrzeg" }
            });

            var item4 = quizItemRepo?.Add(new QuizItem()
            {
                Id = 4,
                CorrectAnswer = "Morze Bałtyckie",
                Question = "Do jakiego morza dostęp ma Polska?",
                IncorrectAnswers = new List<string>() { "Morze Czarne", "Morze Egejskie", "Morze Martwe" }
            });

            quizRepo?.Add(new Quiz()
            {
                Id = 1,
                Items = new List<QuizItem>()
                {
                    item1,
                    item2
                }
            });

            quizRepo?.Add(new Quiz()
            {
                Id = 2,
                Items = new List<QuizItem>()
                {
                    item3,
                    item4
                }
            });
        }
    }
}