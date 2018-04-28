using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Client.Models;

namespace Client.Helpers
{
    public static class ResponseHandler
    {

        public delegate void Execute(object sender);

        public static void Handle(string stringRequest, Execute execute)
        {
            Response response = JsonConvert.DeserializeObject<Response>(stringRequest);

            switch (response.response)
            {
                case "connect" :
                    {
                        break;
                    }
                case "disconnect" :
                    {
                        break;
                    }
                case "getSubjects" :
                    {
                        List<Subject> subjects = JsonConvert.DeserializeObject<List<Subject>>(response.body);
                        execute(subjects);
                        break;
                    }
                case "getThemes" :
                    {
                        List<Theme> themes = JsonConvert.DeserializeObject<List<Theme>>(response.body);
                        execute(themes);
                        break;
                    }
                case "getQuestions" :
                    {
                        List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(response.body);
                        execute(questions);
                        break;
                    }
                case "answer" :
                    {
                        break;
                    }
                case "done" :
                    {
                        break;
                    }
                default:
                    break;
            }

        }

    }
}
