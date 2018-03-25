_We'll create a simple project and set up a test. Use case: `adder`._


0. Install NUnit Framework (only once per machine)
```
dotnet new -i NUnit3.DotNetNew.Template
```

1. Create a new console project
```bash
dotnet new console -o MyProject
```

2. Create a new test project in a desired directory (`-n`)
```bash
dotnet new nunit -n MyProjectTest
```

3. Go to `MyProjectTest/` and add a reference to `MyProject`
```bash
$ cd MyProjectTest/
$ MyTestProject/> dotnet add reference ../MyProject/MyProject.csproj
```

4. Create `Adder.cs` in `MyProject/`
```csharp
namespace adder {
    public class Adder {
        public int add(int a, int b) {
            return a + b;
        } 
    }
}
```

5. Create `AdderTest.cs` in `MyProjectTest/`
```csharp
using NUnit.Framework;
using adder;

namespace adderTest {
    public class AdderTest {
        [Test]
        public void addTest() {
            Adder adder = new Adder();
            Assert.AreEqual(5, adder.add(2, 3));
        }
    }
}
```

6. Run tests
```bash
$ MyProjectTest/> dotnet test
```