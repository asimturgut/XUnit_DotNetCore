https://xunit.net/docs/shared-context#collection-fixture

sprout class:
when you need to add new code to legayc code
you should use sprout method :) split and manage it !!!

Arrange:
Create an instane of your test subject. Load Any Data etc... setup phase

Act:

Make some calls


Assert:

Compate to output....

[Fact] => This is Test Method.
xUnit uses the [Fact] attribute to denote a parameterless unit test,
which tests invariants in your code.

[Trait("Category","Fibo")]=> This Makes Group. Trait(name,value);
search box : trait:"Fibo"

*************************************************************************************
Class Fixtures:
When to use: when you want to create a single test context and share it among all the tests in the class,
and have it cleaned up after all the tests in the class have finished.
IClassFixture<SharedObjects>

public class DatabaseFixture : IDisposable
{
    public DatabaseFixture()
    {
        Db = new SqlConnection("MyConnectionString");

        // ... initialize data in the test database ...
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }

    public SqlConnection Db { get; private set; }
}

public class MyDatabaseTests : IClassFixture<DatabaseFixture>
{
    DatabaseFixture fixture;

    public MyDatabaseTests(DatabaseFixture fixture)
    {
        this.fixture = fixture;
    }

    // ... write tests, using fixture.Db to get access to the SQL Server ...
}

*************************************************************************************
Collection Fixtures:
When to use: when you want to create a single test context and share it among tests in several test classes, 
and have it cleaned up after all the tests in the test classes have finished.
public class DatabaseFixture : IDisposable
{
    public DatabaseFixture()
    {
        Db = new SqlConnection("MyConnectionString");

        // ... initialize data in the test database ...
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }

    public SqlConnection Db { get; private set; }
}

[CollectionDefinition("Database collection")]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}

[Collection("Database collection")]
public class DatabaseTestClass1
{
    DatabaseFixture fixture;

    public DatabaseTestClass1(DatabaseFixture fixture)
    {
        this.fixture = fixture;
    }
}

[Collection("Database collection")]
public class DatabaseTestClass2
{
    // ...
}


*************************************************************************************
In contrast, the [Theory] attribute denotes a parameterised test that is true for a subset of data.
That data can be supplied in a number of ways, but the most common is with an [InlineData] attribute.

[Theory]
[InlineData(1, 2, 3)]
[InlineData(-4, -6, -10)]
[InlineData(-2, 2, 0)]
[InlineData(int.MinValue, -1, int.MaxValue)]
public void CanAddTheory(int value1, int value2, int expected)
{
    var calculator = new Calculator();

    var result = calculator.Add(value1, value2);

    Assert.Equal(expected, result);
}


If the values you need to pass to your [Theory] test aren't constants,
then you can use an alternative attribute, [ClassData], to provide the parameters.
This attribute takes a Type which xUnit will use to obtain the data:

[Theory]
[ClassData(typeof(CalculatorTestData))]
public void CanAddTheoryClassData(int value1, int value2, int expected)
{
    var calculator = new Calculator();

    var result = calculator.Add(value1, value2);

    Assert.Equal(expected, result);
}

We've specified a type of CalculatorTestData in the [ClassData] attribute.
This class must implement IEnumerable<object[]>, 
where each item returned is an array of objects to use as the method parameters.
We could rewrite the data from the [InlineData] attribute using this approach:

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 1, 2, 3 };
        yield return new object[] { -4, -6, -10 };
        yield return new object[] { -2, 2, 0 };
        yield return new object[] { int.MinValue, -1, int.MaxValue };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

The [MemberData] attribute can be used to fetch data for a [Theory] from a static property 
or method of a type.This attribute has quite a lot options, so I'll just run through some of them here.

[Theory]
    [MemberData(nameof(GetData), parameters: 3)]
    public void CanAddTheoryMemberDataMethod(int value1, int value2, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(value1, value2);

        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> GetData(int numTests)
    {
        var allData = new List<object[]>
        {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue },
        };

        return allData.Take(numTests);
    }

	public class CalculatorTests
{
    [Theory]
    [MemberData(nameof(Data), MemberType= typeof(CalculatorData))]
    public void CanAddTheoryMemberDataMethod(int value1, int value2, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(value1, value2);

        Assert.Equal(expected, result);
    }
}

public class CalculatorData
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue },
        };
}
*************************************************************************************
