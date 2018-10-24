using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RepresentativeDAO
/// </summary>
public class RepresentativeDAO
{
    public RepresentativeDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
* JW's codes starts
*/
    public static Representative RetrieveRepByEmpID(int empID)
    {
        Model entities = new Model();
        return entities.Representatives.Where(x => x.Employee_ID == empID && x.Status == "Active").FirstOrDefault();
    }

    public static void CreateNewRep(int id, DateTime startDate, string status)
    {
        Model entities = new Model();
        Representative rep = new Representative();
        rep.Employee_ID = id;
        rep.Start_date = startDate;
        rep.Status = status;

        entities.Representatives.Add(rep);
        entities.SaveChanges();
    }

    public static void UpdateRepEndDate(Representative rep)
    {
        Model entities = new Model();
        rep.End_date = DateTime.Now;
        rep.Status = "Expired";
        entities.SaveChanges();
    }


    /*
 * JW's codes ends
 */
}