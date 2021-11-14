using Activity6DAL;
using Activity6DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity6BL
{
    public class BL
    {
        public int SaveDataIntoDept(DTO newdto)
        {
            try
            {
                DAL dal = new DAL();
                int result = dal.InsertIntoDept(newdto);
                return result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
