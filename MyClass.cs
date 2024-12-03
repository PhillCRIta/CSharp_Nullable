internal class MyClass
{
	public int Id { get; set; }
	public string? Name_NULLABLE { get; set; }
	public string AnotherString { get; set; }  //get compiler warning if remain null after the finish of construction phase
	public string SettedString { get; set; } = "Greetings!";
	public bool IsTrue { get; set; }
	public bool DoSomething() { return true; }
}
