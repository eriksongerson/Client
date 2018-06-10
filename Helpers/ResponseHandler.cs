using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Client.Models;

namespace Client.Helpers
{
    public class ResponseHandler
    {
        public delegate void Execute(object sender);

        public void Handle(string stringRequest, Execute execute)
        {
            Response response = JsonConvert.DeserializeObject<Response>(stringRequest);
            try
            {
                switch (response.response)
                {
                    case "connect" :
                        {
                            execute(null);
                            break;
                        }
                    case "disconnect" :
                        {
                            execute(null);
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
                    case "getGroups":
                        {
                            List<Group> groups = JsonConvert.DeserializeObject<List<Group>>(response.body);
                            execute(groups);
                            break;
                        }
                    case "answer" :
                        {
                            execute(null);
                            break;
                        }
                    case "done" :
                        {
                            execute(null);
                            break;
                        }
                    case "problem":
                        {
                            execute(null);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (NullReferenceException){ }  
        }
    }
}
