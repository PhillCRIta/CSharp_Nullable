### Please note before start reading
In this article I describe my personal tests about a particular topic; it have the purpose of personal use. Those articles describe some limit case studies about some functionality not used or rarely used during my daily job. The examples are taken from the web and personalized by me. ENJOY. 🏄

# Nullable
In C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from Object. \
So basically OBJECT is the base class for all the data types in C#. Before assigning its values, it needs type conversion. \
When a variable of a value type is converted to object, it’s called boxing. \
When a variable of type object is converted to a value type, it’s called unboxing.\
Its type name is System.Object. 

CASE 1 - compiler gives an error
int aa = null; >> IS NOT POSSIBILE ASSIGN TO VALUE TYPE A NULL VALUE \
string aaa = null; >> is possibile set to null a reference type  variab

CASE 2 - from C#2.0 is possibile to wrap a value type inside a NULLABLE type \
C#2.0 introduce Nullable typr \
Nullable\<int> NULLABLE_INT = null; >> boxing int into a nullable type

CASE 3 - from C#8.0 \
Is possibile to assign null value for Reference Type variables, but (from C#8.0) if you don't disable the manage of nullable reference type in the configuration project \
**\<Nullable>enable\</Nullable>** \
the compiler shows a squiggly line warning under the null value, to indicate possible NullReferenceException, you can also use \
**\<WarningsAsErrors>Nullable\</WarningsAsErrors>** \
to force the warning squiggly line to error

To disable the squiggly line you must disable the Nullable manage \
**\<Nullable>disable</Nullable>** \
or you can tell to the compiler if a reference type variable admits a null value for that variable like this case
**MyClass? D = null;** \
the D variable admits a null value

For the reference type the compiler cannot know if a nullable variable is null or not; by default the compiler consider the non-nullable variabile as set variables.
In the example C.Id is considered set, if isn't set take a default value, 0 for int in this case
C.Name_NULLABLE appairs with the squiggly line because is nullable, C.AnotherString is considered set the compiler assume the non-nullable variable, set before the end of constructing phase.

# Operator about Nullable
Following there are a operator useful when treat a nullable ojbect or it's going to manage possible null exception
- NULL-COLAESCING-ASSIGNMENT >> 	C.Name_NULLABLE **??=** "greetings two";
- NULL-CONDITIONAL-OPERATOR >>  Console.WriteLine(C.AnotherString **?.** ToString());
- NULL-COALESCING OPERATOR >> int A1 = NULLABLE_INT **??** 7;
- NULL-FORGIVING OPERATOR >> string name = E.Name_NULLABLE **!**;
- TERNARY OPERATOR >> string a = (1 == 1) ? "TRUE" : "FALSE";