using Xunit;
public class ApplicationTests
{
    private Program program = new Program();
    [Fact]
    public void TwoIsInFactTwo()
    {
        Assert.Equal(2, program.Two);
    }
    [Fact]
    public void LetsFail()
    {
        Assert.Equal(1, program.Two);
    }
}
