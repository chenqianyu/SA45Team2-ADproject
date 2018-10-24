using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CollectionPointController
/// </summary>
public class CollectionPointController
{
    //CollectionPointDAO colDAO;
    //DepartmentDAO depDAO;
    public CollectionPointController()
    {
       
    }

   public static void UpdateCollectionPoint(Department dept, CollectionPoint collect)
    {
        DepartmentDAO.UpdateCollectionPoint(dept, collect);
    }

    public static Department RetrieveDeptByDepID(string id)
    {
        return DepartmentDAO.RetrieveDeptByDepID(id);
    }

    public static CollectionPoint RetrieveCollectPointByID(int id)
    {
        return CollectionPointDAO.RetrieveCollectPointByID(id);
    }

    public static CollectionPoint RetrieveCollectionPointByDescription(string description)
    {
        return CollectionPointDAO.RetrieveCollectionPointByDescription(description);
    }

    public static List<CollectionPoint> RetrieveCollectionPointtList()
    {
        return CollectionPointDAO.RetrieveCollectionPointtList();
    }
}