using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTool.Untity
{
    public class DockerUrl
    {
           public string DockerTest = "http://localhost:8787/DockerTest";
           public string UsersList = "http://localhost:8787/UsersList";
           public string DockerUsersList = "http://localhost:8787/UsersList";
           public string DeleteUser = "http://localhost:8787/DeleteUser";
           public string GolangTwoSum = "http://localhost:7788/TwoSum";
           public string GolangChannlTest = "http://localhost:8787/ChannlTest";
           public string CQRS_UserDelete = "http://localhost:7777/UserCommand/UserDelete";
           public string CQRS_Create = "http://localhost:7777/UserCommand/UserCreate";
           public string CQRS_UserList = "http://localhost:8888/UserQuery/UserList";
    }
}
