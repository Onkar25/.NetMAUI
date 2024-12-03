using Org.Apache.Commons.Collections4;

namespace NativeLibraryBinding
{
    public interface IBoundedMap
    {
        public static int BAR = 1;
    }

    public interface IBoundedMapInvoker
    {
        //public IGet.EntrySet();
    }

    public class NativeClass
	{
        [Obsolete]
        ArrayStack arrayStack = new ArrayStack();
		public NativeClass()
		{
			
		}

        [Obsolete]
        public void GetData()
		{
			arrayStack.Add(new String("Onkar"));
            arrayStack.Add(new String("Prasad"));
            arrayStack.Add(new String("Murkar"));

			Console.WriteLine("Need to print : " + arrayStack);
        }
	}
}

