using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPF;

namespace CPFTest
{
    [TestClass]
    public class CpfTest
    {
        [DataTestMethod]
        [DataRow("111.444.777-35",true)]
        [DataRow("111.111.111-11", false)]
        [DataRow("111.111", false)]
        public void CheckValidadeCpf(string cpf, bool expectedValue)
        {
            Cpf CpfVar = new Cpf();
            var result = CpfVar.IsCpfValid(cpf);
            Assert.AreEqual(expectedValue, result);
        }
    }
}