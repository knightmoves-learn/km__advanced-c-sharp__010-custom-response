using System.Text;
using System.Text.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

[TestCaseOrderer("HomeEnergyApi.Tests.Extensions.PriorityOrderer", "HomeEnergyApi.Tests")]
public class Test
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public Test(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory, TestPriority(1)]
    [InlineData("/Homes")]
    public async Task HomeEnergyApiReturnsSuccessfulHTTPResponseCodeOnGETHomes(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);

        Assert.True(response.IsSuccessStatusCode, $"HomeEnergyApi did not return successful HTTP Response Code on GET request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");
    }

    [Theory, TestPriority(2)]
    [InlineData("/Homes/HackAPI")]
    public async Task HackAPIEndpointReturns500StatusCode(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);

        Assert.True((int)response.StatusCode == 500, $"HomeEnergyApi did not return HTTP Response Code 500 on GET request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");
    }    
    
    [Theory, TestPriority(3)]
    [InlineData("/Homes/HackAPI")]
    public async Task HackAPIEndpointReturnsInternalServerError(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);
        var responseContent = await response.Content.ReadAsStringAsync();

        bool hasInternalServerError = responseContent.Contains("\"error\":\"Internal Server Error\"");

        Assert.True(hasInternalServerError, $"HomeEnergyApi did not return an error of \"Internal Server Error\" on GET request at {url};\n Content received : {responseContent}");
    }    
    
    [Theory, TestPriority(4)]
    [InlineData("/Homes/HackAPI")]
    public async Task HackAPIEndpointReturnsDontHackMeMessage(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);
        var responseContent = await response.Content.ReadAsStringAsync();

        bool hasInternalServerError = responseContent.Contains("\"message\":\"Please don't try to hack me...\"");

        Assert.True(hasInternalServerError, $"HomeEnergyApi did not return a message of \"Please don't try to hack me...\" on GET request at {url};\n Content received : {responseContent}");
    }
}
