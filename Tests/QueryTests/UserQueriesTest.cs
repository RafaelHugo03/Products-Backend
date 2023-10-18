using Domain.Entities;
using Domain.Queries;

namespace Tests.QueryTests
{
    [TestClass]
    public class UserQueriesTest
    {
        private readonly List<User> users;

        public UserQueriesTest()
        {
            users = new List<User>();
            users.Add(new User(Guid.NewGuid(), DateTime.Now, "Rafael", "rafael@outlook.com", "33344455501"));
            users.Add(new User(Guid.NewGuid(), DateTime.Now, "Joao", "joao@outlook.com", "11122233345"));
            users.Add(new User(Guid.NewGuid(), DateTime.Now, "Pedro", "pedro@outlook.com", "77788899910"));
        }

        [TestMethod]
        public void Dado_um_cpf_deve_retornar_um_usuario_com_cpf_igual()
        {
            var cpf = "77788899910";

            var user = users.AsQueryable().Where(UserQueries.GetByCpf(cpf)).FirstOrDefault();

            Assert.AreEqual(cpf, user.Cpf);
        }

        [TestMethod]
        public void Dado_um_email_deve_retornar_um_usuario_com_email_igual()
        {
            var email = "rafael@outlook.com";

            var user = users.AsQueryable().Where(UserQueries.GetByEmail(email)).FirstOrDefault();

            Assert.AreEqual(email, user.Email);
        }
    }
}