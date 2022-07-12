using FluentAssertions;
using GraphQLAutomationTest.Base;
using GraphQLProductApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GraphQLAutomationTest.Test
{
    public class BasicTest
    {
        private readonly IRestFactory _restFactory;
        private readonly string? _token;

        public BasicTest(IRestFactory restFactory)
        {
            _restFactory = restFactory;
            _token = GetToken();
        }

        private string? GetToken()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetOperationTest()
        {
            var response = await _restFactory.Create()
                .WithRequest("Product/GetProductById/1")
                .WithHeader("Authorization", $"Bearer {_token}")
                .WithGet<Product>();
            //Assert
            response?.Name.Should().Be("Keyboard");
        }



    }
}
