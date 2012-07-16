public class RandomTask : Task
{
	private string _property;	
	[TaskAttribute("property", Required = true)]
	[StringValidator(AllowEmpty = false)]
	public string Property
	{
		get { return _property; }
		set { _property = value; }
	}
	
	private string _numeric;	
	[TaskAttribute("numeric", Required = true)]
	[StringValidator(AllowEmpty = false)]
	public string Numeric
	{
		get { return _numeric; }
		set { _numeric = value; }
	}
	
	private string _length;	
	[TaskAttribute("length", Required = true)]
	[StringValidator(AllowEmpty = false)]
	public string Length
	{
		get { return _length; }
		set { _length = value; }
	}
	
	protected override void ExecuteTask()
	{
		try
		{
			int length = int.Parse(this.Length);
			bool isNumeric = this.Numeric.ToLower() == "true";
			bool isReadable = this.Readable.ToLower() == "true";
			
			string random = GetRandomString(length, isNumeric, isReadable);
			
			Properties[this.Property] = random;
			
			project.Log(Level.Info, "Generated random string: " + random);			
		}
		catch (Exception e)
		{
			project.Log(Level.Error, e.ToString());
		}
	}
	
	private const string ALPHA_NUMERICS = "0123456789abcdefjhijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	private const string ALPHA_NUMERICS_READABLE = "346789ABCDEFGHJKLMNPQRTUVWXY";
	private const string NUMERICS = "0123456789";
	
	private string GetRandomString(int length, bool isNumeric, bool isReadable)
	{
		if (length < 1)
		{
			throw new ArgumentOutOfRangeException("length must be greater than 0");
		}

		StringBuilder builder = new StringBuilder();

		for (int i = 0; i < length; i++)
		{
			if (isNumeric)
			{
				builder.Append(NUMERICS[random.Next(0, NUMERICS.Length - 1)]);
			}
			else if (isReadable)
			{
				builder.Append(ALPHA_NUMERICS_READABLE[random.Next(0, ALPHA_NUMERICS_READABLE.Length - 1)]);
			}
			else
			{
				builder.Append(ALPHA_NUMERICS[random.Next(0, ALPHA_NUMERICS.Length - 1)]);
			}
		}

		return builder.ToString();
	}
}