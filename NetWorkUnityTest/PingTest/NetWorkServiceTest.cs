using FluentAssertions;
using FluentAssertions.Extensions;
using NetWorkUnity.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetWorkUnityTest.PingTest
{
    public class NetWorkServiceTest
    {
        private readonly NetWorkService _pingService;
        public NetWorkServiceTest()
        {
            _pingService = new NetWorkService();
        }

        [Fact]
        public void NetWorkService_SendPing_ReturnsString()
        {
            //Arrange   
             
            //Act 
            var result = _pingService.SendPing();
            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success : Ping Sent !");
            result.Should().Contain("Success", Exactly.Once());
           

        }
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        [InlineData(3,3,6)]
        public void NetWorkService_PingTimeOut_ReturnsInt(int a , int b,int expected)
        {
            //Arrange 
           
            //Act 
            var res = _pingService.PingTimeOut(a, b);
            //Assert
            res.Should().Be(expected);
            res.Should().NotBeInRange(-1000, 0);
            res.Should().BeGreaterThan(1);
        }

        [Fact]
        public void NetWorkService_LastPingDate_ReturnsDate()
        {
            //Arrange   

            //Act 
            var result = _pingService.LastPingDate();
            //Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void NetWorkService_GetPingOptions_ReturnsObject()
        {
            //Arrange   
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1

            };
            //Act 
            var result = _pingService.GetPingOptions();
            //Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);   
            result.Ttl.Should().Be(1);
        }

    }
}
