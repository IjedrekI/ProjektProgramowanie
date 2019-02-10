using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void CheckIfWorkerExist()
        {
            Worker worker = new Infrastructure.Entities.Worker();
        }
        
    }
}
