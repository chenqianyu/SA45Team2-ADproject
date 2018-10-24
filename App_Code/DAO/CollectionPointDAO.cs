using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CollectionPointDAO
/// </summary>
public class CollectionPointDAO
{
    
    public CollectionPointDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
* JW's codes starts
*/
    public static List<CollectionPoint> RetrieveCollectionPointtList()
    {
        Model entities = new Model();
        return entities.CollectionPoints.ToList();
    }

    public static CollectionPoint RetrieveCollectPointByID(int id)
    {
        Model entities = new Model();
        return entities.CollectionPoints.Where(x => x.CollectionPoint_ID == id).First();
    }

    public static CollectionPoint RetrieveCollectionPointByDescription(string description)
    {
        Model entities = new Model();
        return entities.CollectionPoints.Where(x => x.Description == description).First();
    }
    /*
* JW's codes ends
*/
}