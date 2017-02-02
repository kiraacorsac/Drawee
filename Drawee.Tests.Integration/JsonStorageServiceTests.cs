using System;
using System.Diagnostics;
using Drawee.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawee.Tests.Integration
{
    [TestClass]
    public class JsonStorageServiceTests
    {
        [TestMethod]
        public void InitStorage()
        {
            var task = JsonStorageService.Instance.InitStorageAsync();
            task.Wait();
            Trace.WriteLine(task.Result);
        }
    }
}
