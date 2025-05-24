using tpmodul12_2211104013_aorin;
using Xunit;

namespace unitTest_tpdmodul12_2211104013
{
    public class UnitTest1
    {
        [Fact]
        public void TestNegatif()
        {
            Assert.Equal("Negatif", BilanganHelper.CariTandaBilangan(-5));
        }

        [Fact]
        public void TestPositif()
        {
            Assert.Equal("Positif", BilanganHelper.CariTandaBilangan(10));
        }

        [Fact]
        public void TestNol()
        {
            Assert.Equal("Nol", BilanganHelper.CariTandaBilangan(0));
        }
    }
}
