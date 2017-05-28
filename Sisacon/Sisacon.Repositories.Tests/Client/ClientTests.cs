using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Infra.Repositories;

namespace Sisacon.Repositories.Tests.Client
{
    /// <summary>
    /// Summary description for ClientTests
    /// </summary>
    [TestClass]
    public class ClientTests
    {
        private readonly IClientRepository _clientRepository;

        public ClientTests()
        {
            _clientRepository = new ClientRepository();
        }

        [TestMethod]
        public void GetCount()
        {
            int itensQuantity = _clientRepository.GetCount(2);

            Assert.IsTrue(itensQuantity > 0);
        }
    }
}
