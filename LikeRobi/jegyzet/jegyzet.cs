//using statement:
using (MyResource myRes = new MyResource())
{
    myRes.DoSomething();
}
{ // lényegében az using ezt csinálja, 
  //  meghívja az objektum dispose függvényét,felszabadítja a memóriát
    MyResource myRes = new MyResource();
    try
    {
        myRes.DoSomething();
    }
    finally
    {
        // Check for a null resource.
        if (myRes!= null)
            // Call the object's Dispose method.
            ((IDisposable)myRes).Dispose();
    }
}