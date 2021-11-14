using Activity6BL;
using Activity6DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Activity6WEBAPI.Controllers
{
    
    public class Activity6Controller : ApiController
    {
        [HttpPost]
        public HttpResponseMessage ChangeDepartmentName(DTO newdto)
        {
            try
            {
                if (newdto != null)
                {
                    BL bl = new BL();
                    int result = bl.SaveDataIntoDept(newdto);
                    
                    if (result == -1)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "DepartmentId Doesn't EXISTS Which Was Given");

                    }
                    if (result == -2)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "DepartmentName Should Be Morethan 3 And Less Than 15");

                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "DepartmentName Changed successfully");

                    }

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Check all input values for department");
                }



            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
