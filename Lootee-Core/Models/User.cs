using Lootee_Core.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lootee_Core.Models
{
    public class User
    {
        public int id { get; set; }
        public string? username { get; set; }
        public string? secret { get; set; }
        public int hp { get; set; }
        public int money { get; set; }


        /// <summary>
        /// login a user using username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static async Task<User?> Login(string username, string secret)
        {
            var login = new Requests.User.Login 
            { 
                Username = username, 
                Secret = secret 
            };

            var loginResult = await login.Extract().Submit<dynamic>($"{Lootee_Core.Globals.BaseUrl}/user/login");

            if (loginResult.response.StatusCode != global::System.Net.HttpStatusCode.OK)
                return null;

            Lootee_Core.Globals.Token = loginResult.result!.token;
            return await Get();
        }

        /// <summary>
        /// register a user using username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static async Task<User?> Register(string username, string secret)
        {
            var register = new Requests.User.Register
            {
                Username = username,
                Secret = secret
            };

            var registerResult = await register.Extract().Submit<dynamic>($"{Lootee_Core.Globals.BaseUrl}/user/register");

            if (registerResult.response.StatusCode != global::System.Net.HttpStatusCode.OK)
                return null;

            return await User.Login(username, secret);
        }

        /// <summary>
        /// update user info
        /// </summary>
        /// <returns></returns>
        public async Task Update()
        {
            var get = new Requests.User.Get();
            var getResult = await get.Extract().Submit<User>($"{Lootee_Core.Globals.BaseUrl}/user/");
            if (getResult.response.StatusCode != global::System.Net.HttpStatusCode.OK)
                return;

            if (getResult.result == null)
                return;

            this.id = getResult.result!.id;
            this.secret = getResult.result!.secret;
            this.hp = getResult.result!.hp;
            this.username = getResult.result!.username;
            this.money = getResult.result!.money;
        }
      
        /// <summary>
        /// loads current user
        /// </summary>
        /// <returns></returns>
        private static async Task<User?> Get()
        {
            var get = new Requests.User.Get();
            var getResult = await get.Extract().Submit<User>($"{Lootee_Core.Globals.BaseUrl}/user/");
            if (getResult.response.StatusCode != global::System.Net.HttpStatusCode.OK)
                return null;
            return getResult.result;
        }
    }
}
