using System;
using TestQuizz.Models;
using TestQuizz.Models.AuthApp.Models;
using Xunit;

namespace XUnitTestProject1
{
    public class UserTest
    {
        User user = new User
        {
            Id = 1,
            Password = "1",
            UserName = "TestUser",
            Access = new bool[7]
        };
        UserContext cnt;
        public UserTest(UserContext cntx)
        {
            cnt = cntx;
        }

        [Fact]
        public void StringTest()
        {
            Assert.Equal("False;False;False;False;False;False;False", user.InternalAccess);
        }
        [Fact]
        public void ArrTest()
        {
            Assert.Equal(new bool[7], user.Access);
        }
        [Fact]
        public void DbTest()
        {
            //var res = cnt.Users.
        }
    }
}
