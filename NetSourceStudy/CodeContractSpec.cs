using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSourceStudy
{
    public class CodeContractSpec
    {
        [Test]
        public void ShouldRequire()
        {
            var x = 100;
            Contract.Requires(x > 100);
        }
    }
}
