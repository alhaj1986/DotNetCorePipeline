using System;

public class Business
{
    public bool MethodToTest(int option)
    {
        switch (option)
        {
            case 0:
                return true;
            case 1:
                return false;
            case 2:
                throw new ApplicationException("some exception occured");
        }

        throw new ApplicationException("some other exception occured");
    }
}