using System.Diagnostics;

/*ABSTRACT
 * In C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from Object. 
 * So basically it is the base class for all the data types in C#. Before assigning values, it needs type conversion. 
 * When a variable of a value type is converted to object, it’s called boxing. 
 * When a variable of type object is converted to a value type, it’s called unboxing.
 * Its type name is System.Object. 
 **/
//Boxing converts a Value Type variable into a Reference Type variable
//UNBoxing converts a Reference Type variable into a Value Type variable

/*
int num = 23; // 23 will assigned to num
Object Obj = num; // Boxing
int num = 23;         // value type is int and assigned value 23
Object Obj = num;    // Boxing
int i = (int)Obj;    // Unboxing
*/


//CASE 1
//compiler gives an error
//int aa = null; //IS NOT POSSIBILE ASSIGN TO VALUE TYPE A NULL VALUE
//Errore (attivo)	CS0037	Non è possibile convertire Null in 'int' perché è un tipo valore che non ammette i valori Null	003_Nullable	
//string aaa = null; //is possibile set to null a reference type  variable

//CASE 2
//from C#2.0 is possibile to wrap a value type inside a NULLABLE type
//C#2.0 introduce Nullable typr
Nullable<int> NULLABLE_INT = null;
Console.WriteLine("Default value of nullable of T: " + NULLABLE_INT.GetValueOrDefault());
Console.WriteLine("Variable has a value? " + NULLABLE_INT.HasValue);
NULLABLE_INT = 5;
//in short format
int? B = null;
B = 5;
//Nullable<string> s = null;//COMPILER GIVES AN ERROR, IS NOT POSSIBILE USE THE NULLABLE TYPE TO WRAP A REFERENCE TYPE.
//CS0453 Il tipo 'string' deve essere un tipo valore che non ammette i valori Null per poter essere usato come parametro 'T' nel metodo o nel tipo generico 'Nullable<T>'	003_Nullable	

//CASE 3
//is possibile to assign null value for Reference Type variables,
//but (from C#8.0) if you don't disable the manage of nullable reference type in the configuration project
//<Nullable>enable</Nullable>
//the compiler shows a squiggly line warning under the null value, to indicate possible NullReferenceException
//you can also use  <WarningsAsErrors>Nullable</WarningsAsErrors> to force the warning squiggly line to error
string C1 = null;
MyClass C = null;
object x = null;
//to disable the squiggly line you must disable the Nullable manage <Nullable>disable</Nullable>
//or you can tell to the compiler if a reference type variable admits a null value for that variable
//like this case
MyClass? D = null;
//the D variable admits a null value

//CASE 3.A, example manage the variable C and D
C = new();
//in this case C is instantiate
if (C != null)
{
	//for the reference type the compiler cannot know if a nullable variable is null or not
	//by default the compiler consider the non-nullable variabile as set variables
	//in the following example C.Id is considered set, if isn't set take a default value , 0 for int in this case
	//C.Name_NULLABLE appairs with the squiggly line because is nullable
	//C.AnotherString is considered set
	//the compiler assume the non-nullable variable, set before the end of constructing phase
	int i1 = C.Id;
	string p = C.Name_NULLABLE; //P in this case is null because the Name_NULLName_NULLABLEABLE is null
								//you must use the NULL-COLAESCING operator to set in case of null of Name_NULLABLE
								//like this 
	string p1 = C.Name_NULLABLE ?? "or other somthing";
	//with NULL-COLAESCING-ASSIGNMENT operator, assign to the left variabile the value of righ, if left variabile is null
	C.Name_NULLABLE ??= "greetings two";
	//in case of method, if variable is null it throws an NullReferenceException
	Console.WriteLine(C.SettedString.ToString());//in this case ToString method work correctly because the string is setted
												 //Console.WriteLine(C.Name_NULLABLE.ToString());  
	/*
	in this case during the runtime , the program throws an error of NullReference
	and the compiler shows a green squiggly line to show a potentian Null object/variable
	because a Name_NULLABLE is set by question mark 
	*/
	//also in this case you get a NullReferenceException, without a squiggly green line, because this line appears inside the class
	//Console.WriteLine(C.AnotherString.ToString());
	//for prevent an error during run time, you must use the NULL-CONDITIONAL-OPERATOR
	//if the left part of expression is null returns null
	Console.WriteLine(C.AnotherString?.ToString());
	//you can use NULL-CONDITIONAL-OPERATOR and NULL-COLAESCING together
	Console.WriteLine(C.AnotherString?.ToString() ?? "does return nothing");
}
//in this case D is NULL
if (D != null)
{
	int p11 = D.Id;
	string p111 = D.Name_NULLABLE;
	Console.WriteLine(D.Name_NULLABLE);
}

//NULL-FORGIVING OPERATOR
MyClass E = new();
//with the exclamation mark you tell a compiler that you assume your responsability and know that the variable is not null securly.
//and then the squiggly green line disappears
//but you be much carefull because in this case E is istantiated,
//but Name_NULLABLE is not instantiated and throws NullReferenceException
string name = E.Name_NULLABLE!;
//also in this case the compile ignore the warning green squiggly line 
//but in fact Name_NULLABLE remain null and throws an NullReferenceException
//GIVES AN ERROR Console.WriteLine(E.Name_NULLABLE!.ToString());
//in this last example the compiler doesn't throw and excelption because SettedString is not null inside a class
Console.WriteLine(E!.SettedString.ToString());



//TERNARY OPERATOR
//question mark operator
//classical ternary operator
string a = (1 == 1) ? "TRUE" : "FALSE";


//?? double question mark operator - NULL-COALESCING OPERATOR
//like a SQL Coalesce operator
//you can use the null-coalescing operator with nullable variables
int A1 = NULLABLE_INT ?? 7; //in this case is used a nullable explicit wrapping
int B1 = B ?? 7;            //in this case is used a questin mark varaiable notation





Debug.WriteLine("");