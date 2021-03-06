﻿using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sangmado.Inka.Security.UnitTests
{
    [TestClass]
    public class TestSHA512withRSA
    {
        public static readonly string RSAPrivateKeyXmlString = @"
<RSAKeyValue>
    <Modulus>p24kbDosK8dM47JCQubNAVptF2RyA/PPKzQcnAO4zFDtBQzvr69H7bPb+zSsvVHt7SrP2kXuK3lSxA5onArpMWx3zGX+G2jqh6XXxFFH1QOIL7Hmffzp9BLdfvm0DsO2ZLbecPv1BivyC6+Q/Epo23yAXkrllqY3EWHxk2CzqTs=</Modulus>
    <Exponent>AQAB</Exponent>
    <P>2IGeP2ijuQvVRXFyIBYvuankRFcb9vlYrA8mYSDlJQ7SAuAFwugsMOc/t2dkdkhEr8O19REN7i9abMTzLGZbaQ==</P>
    <Q>xfjGvQrMaLXeA5xUGpoqfEXW9G2S/g871v3a9/muoWE2MOp9ETbWDHiNc00vYrt/MgHP3vwYBnv6jfYJw3v/Aw==</Q>
    <DP>RdB+Q/otGUWcjxkG8RvWZetHxVXFmb1L/6ee+6EM4wdFZ1Hv6arOXTKklDKN7apeI8NbUFwgftbcNMjJlV6oSQ==</DP>
    <DQ>f4WDRuw4xU45B2xghI4/xbMbBnG6mKppalA1Bzyu70b2KEYzb6457OiOfPIADwIlqamfI8yREUQ1HdKZcXFizw==</DQ>
    <InverseQ>nGtF0Z/mXxOs/yD/c+XRTvjPs/EJWzPUolet59n2l+txX4AR/vZuDUOAZ7kKUEMprbd+cMwNEdy3LgBsCDgkkQ==</InverseQ>
    <D>QV2c1qv3ZrgOaq7Dc78LtkWJZaKPaL+c1+8mZDqHwSyu/FPKl7pEyKZ5cZ9k+RytWPRn5X17uHlLOMOvT4xq8YDoN6Faw/eqFw6KxaooRYdSx9YqvtsCv/4zlXhHs16CQ8fg1g+zXCGd8s6IBjaPEyITZEMxyP1n4owhIaa18KE=</D>
</RSAKeyValue>
";
        public static readonly string RSAPublicKeyXmlString = @"
<RSAKeyValue>
    <Modulus>p24kbDosK8dM47JCQubNAVptF2RyA/PPKzQcnAO4zFDtBQzvr69H7bPb+zSsvVHt7SrP2kXuK3lSxA5onArpMWx3zGX+G2jqh6XXxFFH1QOIL7Hmffzp9BLdfvm0DsO2ZLbecPv1BivyC6+Q/Epo23yAXkrllqY3EWHxk2CzqTs=</Modulus>
    <Exponent>AQAB</Exponent>
</RSAKeyValue>
";

        [TestMethod]
        public void Test_SHA512withRSA_Sign_Verify()
        {
            string content = @"Hello World";
            byte[] buffer = Encoding.UTF8.GetBytes(content);

            string signature = SHA512withRSA.Sign(RSAPrivateKeyXmlString, buffer);
            bool verified = SHA512withRSA.Verify(RSAPublicKeyXmlString, buffer, signature);

            Assert.IsTrue(verified);
        }
    }
}
