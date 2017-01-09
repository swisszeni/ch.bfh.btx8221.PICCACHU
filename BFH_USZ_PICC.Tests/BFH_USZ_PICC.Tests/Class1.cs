using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BFH_USZ_PICC.Tests
{
    public class TestsAreGood
    {
        [Fact]
        public void ThisShouldPass()
        {
            Assert.True(true);
        }

        [Fact]
        public async Task ThisShouldFail()
        {
            await Task.Run(() => { throw new Exception("boom"); });
        }
    }
}
