using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Client.Models;
namespace Client.Helpers {
    // Класс обработки ответа от сервера
    public class ResponseHandler {
        public delegate void Execute(object sender);
        // функция обработки ответа от сервера
        public void Handle(string stringRequest, Execute execute){
            // Конвертируем сообщение от сервера в объект
            Response response = JsonConvert.DeserializeObject<Response>(stringRequest);
            try {
                // И в зависимости от ответа, обрабатываем по-разному
                switch (response.response) {
                    case "connect" : {
                            execute(null);
                            break;
                        }
                    case "disconnect" : {
                            execute(null);
                            break;
                        }
                    case "getSubjects" : {
                            // Получаем из БД предметы
                            List<Subject> subjects = JsonConvert.DeserializeObject<List<Subject>>(response.body);
                            // Выполняем полученную функцию
                            execute(subjects);
                            break;
                        }
                    case "getThemes" : {
                            // Получаем из БД темы
                            List<Theme> themes = JsonConvert.DeserializeObject<List<Theme>>(response.body);
                            // Выполняем полученную функцию
                            execute(themes);
                            break;
                        }
                    case "getQuestions" : {
                            // получаем из БД вопросы
                            List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(response.body);
                            // Выполняем полученную функцию
                            execute(questions);
                            break;
                        }
                    case "getGroups" : {
                            // Получаем из БД группы
                            List<Group> groups = JsonConvert.DeserializeObject<List<Group>>(response.body);
                            // Выполняем полученную функцию
                            execute(groups);
                            break;
                        }
                    case "answer" : {
                            execute(null);
                            break;
                        }
                    case "done" : {
                            execute(null);
                            break;
                        }
                    case "problem" : {
                            execute(null);
                            break;
                        }
                    default: break;
                }
            }
            catch (NullReferenceException){ }  
        }
    }
}
