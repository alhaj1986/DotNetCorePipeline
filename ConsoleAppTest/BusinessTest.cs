using System;
using Xunit;

public class BusinessTest
{
    [Fact]
    public void test_should_pass()
    {
        var business = new Business();

        bool result = business.MethodToTest(0);

        Assert.True(result);
    }

    [Fact]
    public void test_should_fail()
    {
        var business = new Business();

        bool result = business.MethodToTest(1);

        Assert.False(result);
    }

    [Fact]
    public void test_should_throw_exception()
    {
        var business = new Business();

        var exception = Assert.Throws<ApplicationException>(() =>
        {
            business.MethodToTest(2);
        });
        
        Assert.Equal("some exception occured", exception.Message);
    }
}