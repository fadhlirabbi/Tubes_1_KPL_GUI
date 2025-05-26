//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Threading.Tasks;
//using API.Services;
//using API.Controllers;

//namespace test1
//{
//    [TestClass]
//    public class LoginRegisterAutomataTests
//    {
//        [TestMethod]
//        public async Task Login_Berhasil()
//        {
//            var mockController = new FakeLoginRegisterController(true);
//            var service = new UserService(mockController);

//            var success = await service.TryLoginAsync("user", "pass");

//            Assert.IsTrue(success);
//            Assert.AreEqual(UserService.State.LoggedIn, service.CurrentState);
//        }

//        [TestMethod]
//        public async Task Login_Gagal()
//        {
//            var mockController = new FakeLoginRegisterController(false);
//            var service = new UserService(mockController);

//            var success = await service.TryLoginAsync("user", "wrongpass");

//            Assert.IsFalse(success);
//            Assert.AreEqual(UserService.State.LoggedOut, service.CurrentState);
//        }


//        private class FakeLoginRegisterController : LoginRegisterController
//        {
//            private readonly bool _loginResult;

//            public FakeLoginRegisterController(bool loginResult)
//                : base(new HttpClient()) 
//            {
//                _loginResult = loginResult;
//            }

//            public override Task<bool> TryLoginAsync(string username, string password)
//            {
//                return Task.FromResult(_loginResult);
//            }

//            public override Task LogoutAsync(string username)
//            {
//                return Task.CompletedTask;
//            }

//            public override Task RegisterAsync()
//            {
//                return Task.CompletedTask;
//            }

//            public override Task RegisterAsync(string username, string password)
//            {
//                return Task.CompletedTask;
//            }
//        }
//    }
//}
