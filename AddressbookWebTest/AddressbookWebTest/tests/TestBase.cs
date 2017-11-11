using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            //в начале теста обязательный переход на домашнюю страницу
            //так как неизвестно в каком порядке будут проходить тесты
            //обязательный переход есть только при инициализации ApplicationManager
            //при логаут/логин возврат на старую страницу (например groups)
            app.Navigator.GoToHomePage();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return builder.ToString();
        }


    }
}
