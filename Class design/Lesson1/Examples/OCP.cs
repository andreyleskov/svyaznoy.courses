abstract class Importer
{
	public abstract void ImportData();
}

static class ImporterFactory
{
	public static Importer Create(string fileName)
	{
    	Contract.Requires(!string.IsNullOrEmpty(fileName));
    	Contract.Ensures(Contract.Result<Importer>() != null);

    	var extension = Path.GetExtension(fileName);
    	switch (extension)
    	{
        	case "json":
            	return new JsonImporter();
        	case "xls":
        	case "xlsx":
            	return new XlsImporter();
        	default:
            	throw new InvalidOperationException(
                 "Extension is not supported");
    	}
	}
}
