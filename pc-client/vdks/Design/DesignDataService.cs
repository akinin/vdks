using System;
using vdks.Model;

namespace vdks.Design
{
    public class DesignDataService 
    {
        public void GetData(Action<PhoneNumber, Exception> callback)
        {
            

            var item = new PhoneNumber(new byte[]{9,2,1,1,2,3,1,2,1,2});
            
        }
    }
}